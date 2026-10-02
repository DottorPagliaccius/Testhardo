using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using Testhardo.Services;

namespace Testhardo;

public record ServiceCalledEventArgs(string Verb, string Url, ServiceResponse Response, TimeSpan ElapsedTime, int? Index = null, int? Total = null);

public partial class RunResultControl : UserControl
{
    private int _completedCount;
    private ServiceResponse? _lastResponse;

    private CancellationTokenSource _cancellationTokenSource = new();

    private readonly IApiService _apiService;
    private StoryAction? _storyAction;

    public event EventHandler<ServiceResponse>? Completed;
    public event EventHandler<ServiceCalledEventArgs>? ServiceCalled;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsRunning { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsCompleted { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsCompletedInError { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ServiceResponse? Response { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StoryAction? StoryAction
    {
        get => _storyAction;
        set
        {
            if (value != null)
            {
                TitleLabel.Text = $"{value.Verb} - {value.RelativeUrl}";
                ToolTipManager.SetToolTip(TitleLabel, value.BaseUrl + value.RelativeUrl);
                _storyAction = value;
            }
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Statistics? Statistics { get; private set; }

    public RunResultControl(IApiService apiService)
    {
        InitializeComponent();

        foreach (Control control in Controls)
        {
            control.MouseDown += (s, e) => OnMouseDown(e);
            control.Click += (s, e) => OnClick(e);
            control.Cursor = Cursors.Hand;
        }

        _apiService = apiService;
    }

    public async Task StartAsync()
    {
        if (StoryAction == null)
            throw new InvalidOperationException("StoryAction is not set");

        if (StoryAction.Operation.RequestBody != null && !StoryAction.Operation.RequestBody.Validate(out var error))
            throw new InvalidOperationException($"Invalid request body: {error}");

        if (StoryAction.Operation.Parameters.Count != 0 && StoryAction.Operation.Parameters.Any(x => !x.IsValid))
            throw new InvalidOperationException($"Invalid parameters: {string.Join(", ", StoryAction.Operation.Parameters.Where(x => !x.IsValid).Select(x => x.Name))}");

        _cancellationTokenSource = new CancellationTokenSource();

        var cancellationToken = _cancellationTokenSource.Token;

        _completedCount = 0;
        _lastResponse = null;

        var requestsCount = StoryAction.Options.RequestsCount;
        var timeout = TimeSpan.FromSeconds(StoryAction.Options.TimeoutInSeconds);
        var verb = HttpMethod.Parse(StoryAction.Verb);
        var url = StoryAction.BaseUrl + StoryAction.RelativeUrl;
        var requestJson = StoryAction.Operation.RequestBody?.Value;
        var degreeOfParallelism = StoryAction.Options.DegreeOfParallelism;

        if (StoryAction.Operation.Parameters.Count != 0)
        {
            var queryParameters = StoryAction.Operation.Parameters.Where(x => x.In == "query" && !string.IsNullOrEmpty(x.Value)).ToList();

            if (queryParameters.Count > 0)
            {
                var queryString = string.Join("&", queryParameters.Select(x => $"{x.Name}={Uri.EscapeDataString(x.Value!)}"));
                url += "?" + queryString;
            }

            var urlParameters = StoryAction.Operation.Parameters.Where(x => x.In == "path" && !string.IsNullOrEmpty(x.Value)).ToList();

            foreach (var param in urlParameters)
            {
                url = url.Replace($"{{{param.Name}}}", Uri.EscapeDataString(param.Value!));
            }
        }

        IsRunning = true;
        RunProgressBar.Maximum = requestsCount;
        RunProgressBar.Value = 0;

        var timings = new ConcurrentBag<double>();
        var responses = new ConcurrentQueue<(TimeSpan Elapsed, int Index, ServiceResponse Response)>();
        var totalStopwatch = Stopwatch.StartNew();

        var uiUpdateTask = UpdateUIAsync(requestsCount, timings, totalStopwatch, cancellationToken);

        var channel = Channel.CreateUnbounded<(TimeSpan Elapsed, int Index, ServiceResponse Response)>(new UnboundedChannelOptions { SingleReader = true, SingleWriter = false });
        var readFromChannelTask = ReadFromChannelAsync(channel, verb, url, requestsCount, cancellationToken);

        try
        {
            var throttler = new SemaphoreSlim(degreeOfParallelism);

            var tasks = new Task[requestsCount];

            for (var i = 0; i < requestsCount; i++)
            {
                try
                {
                    await throttler.WaitAsync(cancellationToken);

                    tasks[i] = ExecuteRequestAsync(verb, url, requestJson, timeout, i + 1, throttler, channel, timings, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                }
            }

            await Task.WhenAll(tasks);

            totalStopwatch.Stop();

            await uiUpdateTask;

            channel.Writer.Complete();

            await readFromChannelTask;
        }
        finally
        {
            Response = _lastResponse;

            IsCompleted = true;

            if (Response?.Exception != null)
                IsCompletedInError = true;

            IsRunning = false;

            UpdateProgressBar(_completedCount);
            UpdateStatistics([.. timings], totalStopwatch.Elapsed);

            if (InvokeRequired)
                BeginInvoke(() => Completed?.Invoke(this, Response!));
            else
                Completed?.Invoke(this, Response!);
        }
    }

    private async Task ReadFromChannelAsync(Channel<(TimeSpan Elapsed, int Index, ServiceResponse Response)> channel, HttpMethod verb, string url, int requestsCount, CancellationToken cancellationToken)
    {
        await foreach (var item in channel.Reader.ReadAllAsync(cancellationToken))
            FireServiceCalledEvent(verb.ToString(), url, item.Response, item.Elapsed, item.Index, requestsCount);
    }

    private async Task UpdateUIAsync(int requestsCount, ConcurrentBag<double> timings, Stopwatch totalStopwatch, CancellationToken cancellationToken)
    {
        try
        {
            using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(500));

            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                UpdateStatistics([.. timings], totalStopwatch.Elapsed);

                var current = Volatile.Read(ref _completedCount);

                UpdateProgressBar(current);

                if (current >= requestsCount)
                    break;
            }
        }
        catch (OperationCanceledException)
        {
        }
    }

    private async Task ExecuteRequestAsync(HttpMethod verb, string url, string? requestJson, TimeSpan timeout, int index, SemaphoreSlim throttler, Channel<(TimeSpan Elapsed, int Index, ServiceResponse Response)> responses, ConcurrentBag<double> timings, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _apiService.SendAsync(verb, url, requestJson, timeout, cancellationToken).ConfigureAwait(false);

            _lastResponse = response;

            timings.Add(response.ResponseTime.TotalMilliseconds);

            Interlocked.Increment(ref _completedCount);

            await responses.Writer.WriteAsync((response.ResponseTime, index, response), cancellationToken);
        }
        catch (OperationCanceledException)
        {
        }
        finally
        {
            throttler.Release();
        }
    }

    private void UpdateProgressBar(int value)
    {
        if (!InvokeRequired)
            RunProgressBar.Value = Math.Min(value, RunProgressBar.Maximum);
        else
            BeginInvoke(() => RunProgressBar.Value = Math.Min(value, RunProgressBar.Maximum));
    }

    private void FireServiceCalledEvent(string verb, string url, ServiceResponse serviceResponse, TimeSpan elapsedTime, int? index = null, int? total = null)
    {
        if (InvokeRequired)
            BeginInvoke(() => ServiceCalled?.Invoke(this, new ServiceCalledEventArgs(verb, url, serviceResponse, elapsedTime, index, total)));
        else
            ServiceCalled?.Invoke(this, new ServiceCalledEventArgs(verb, url, serviceResponse, elapsedTime, index, total));
    }

    public void Reset()
    {
        IsRunning = false;
        IsCompleted = false;
        IsCompletedInError = false;
        Response = null;
        RunProgressBar.Value = 0;
    }

    public void Stop()
    {
        _cancellationTokenSource.Cancel();
    }

    private static double Percentile(double[] sortedValues, double percentile)
    {
        if (sortedValues.Length == 0)
            return 0;

        var position = (percentile / 100.0) * (sortedValues.Length + 1);
        var index = (int)position - 1;

        if (index < 0)
            return sortedValues[0];

        if (index >= sortedValues.Length - 1)
            return sortedValues[^1];

        var fraction = position - Math.Floor(position);

        return sortedValues[index] + (fraction * (sortedValues[index + 1] - sortedValues[index]));
    }

    private void UpdateStatistics(double[] timings, TimeSpan totalElapsed)
    {
        if (timings.Length == 0 || totalElapsed == TimeSpan.Zero)
        {
            Statistics = null;
            return;
        }

        Array.Sort(timings);

        var average = timings.Average();
        var variance = timings.Average(x => Math.Pow(x - average, 2));
        var standardDeviation = Math.Sqrt(variance);

        Statistics = new Statistics
        {
            Count = timings.Length,
            Min = timings[0],
            Max = timings[^1],
            Average = average,
            Median = timings.Length % 2 == 0 ? (timings[(timings.Length / 2) - 1] + timings[timings.Length / 2]) / 2.0 : timings[timings.Length / 2],
            StandardDeviation = standardDeviation,
            Percentile50 = Percentile(timings, 50),
            Percentile75 = Percentile(timings, 75),
            Percentile90 = Percentile(timings, 90),
            Percentile95 = Percentile(timings, 95),
            Percentile99 = Percentile(timings, 99),
            TotalDuration = totalElapsed,
            Throughput = timings.Length / totalElapsed.TotalSeconds
        };
    }
}

public class Statistics
{
    public int Count { get; set; }
    public double Min { get; set; }
    public double Max { get; set; }
    public double Average { get; set; }
    public double StandardDeviation { get; set; }
    public double Percentile50 { get; set; }
    public double Percentile75 { get; set; }
    public double Percentile90 { get; set; }
    public double Percentile95 { get; set; }
    public double Percentile99 { get; set; }
    public double Median { get; set; }
    public double Throughput { get; set; }
    public TimeSpan TotalDuration { get; set; }
}