using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using Testhardo.Services;

namespace Testhardo;

public record ServiceCalledEventArgs(string Verb, string Url, ServiceResponse Response, TimeSpan ElapsedTime, int? Index = null, int? Total = null);

public partial class RunResultControl : UserControl
{
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

        _cancellationTokenSource = new CancellationTokenSource();

        var cancellationToken = _cancellationTokenSource.Token;

        var requestsCount = StoryAction.Options.RequestsCount;
        var timeout = TimeSpan.FromSeconds(StoryAction.Options.TimeoutInSeconds);
        var verb = HttpMethod.Parse(StoryAction.Verb);
        var url = StoryAction.BaseUrl + StoryAction.RelativeUrl;
        var requestJson = StoryAction.RequestBody;
        var degreeOfParallelism = StoryAction.Options.DegreeOfParallelism;

        IsRunning = true;
        RunProgressBar.Maximum = requestsCount;
        RunProgressBar.Value = 0;

        var timings = new ConcurrentBag<double>();
        var responses = new ConcurrentQueue<(TimeSpan Elapsed, int Index, ServiceResponse Response)>();
        var totalStopwatch = Stopwatch.StartNew();
        var completedCount = 0;

        var uiUpdateTask = Task.Run(async () =>
        {
            using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(500));

            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                var current = completedCount;

                UpdatetStatistics([.. timings], totalStopwatch.Elapsed);
                UpdateProgressBar(current);

                var batch = new List<(TimeSpan Elapsed, int Index, ServiceResponse Response)>();

                while (responses.TryDequeue(out var response))
                {
                    batch.Add(response);

                    if (batch.Count >= 10)
                        break;
                }

                foreach (var item in batch)
                {
                    FireServiceCalledEvent(verb.ToString(), url, item.Response, item.Elapsed, item.Index, requestsCount);
                }

                if (current >= requestsCount)
                    break;
            }
        }, cancellationToken);

        try
        {
            var throttler = new SemaphoreSlim(degreeOfParallelism);
            var tasks = new Task[requestsCount];

            for (var i = 0; i < requestsCount; i++)
            {
                var index = i + 1;
                await throttler.WaitAsync(cancellationToken);

                tasks[i] = Task.Run(async () =>
                {
                    try
                    {
                        if (cancellationToken.IsCancellationRequested)
                            return;

                        var stopwatch = Stopwatch.StartNew();

                        var response = await _apiService.SendAsync(verb, url, requestJson, timeout, cancellationToken);

                        stopwatch.Stop();

                        responses.Enqueue((stopwatch.Elapsed, index, response));

                        timings.Add(stopwatch.Elapsed.TotalMilliseconds);

                        Interlocked.Increment(ref completedCount);
                    }
                    finally
                    {
                        throttler.Release();
                    }
                }, cancellationToken);
            }

            await Task.WhenAll(tasks);
            await uiUpdateTask;
        }
        finally
        {
            totalStopwatch.Stop();

            Response = responses.LastOrDefault().Response;

            IsCompleted = true;
            if (Response?.Exception != null)
                IsCompletedInError = true;

            IsRunning = false;

            UpdateProgressBar(completedCount);
            UpdatetStatistics([.. timings], totalStopwatch.Elapsed);

            if (InvokeRequired)
                BeginInvoke(() => Completed?.Invoke(this, Response!));
            else
                Completed?.Invoke(this, Response!);
        }
    }

    private void UpdateProgressBar(int value)
    {
        if (!InvokeRequired)
        {
            RunProgressBar.Value = Math.Min(value, RunProgressBar.Maximum);
        }
        else
        {
            BeginInvoke(() => RunProgressBar.Value = Math.Min(value, RunProgressBar.Maximum));
        }
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

    private void UpdatetStatistics(double[] timings, TimeSpan totalElapsed)
    {
        if (timings.Length == 0 || totalElapsed == TimeSpan.Zero)
        {
            Statistics = null;
            return;
        }

        Array.Sort(timings);

        Statistics = new Statistics
        {
            Count = timings.Length,
            Min = timings[0],
            Max = timings[^1],
            Average = timings.Average(),
            Median = timings.Length % 2 == 0 ? (timings[(timings.Length / 2) - 1] + timings[timings.Length / 2]) / 2.0 : timings[timings.Length / 2],
            StandardDeviation = Math.Sqrt(timings.Average(x => Math.Pow(x - timings.Average(), 2))),
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
