using System.ComponentModel;
using Testhardo.Services;

namespace Testhardo;

public partial class RunResultControl : UserControl
{
    private CancellationTokenSource _cancellationTokenSource = new();

    private readonly IApiService _apiService;

    public event EventHandler<ServiceResponse>? Completed;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsRunning { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsCompleted { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsCompletedInError { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ServiceResponse? Response { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StoryAction? StoryAction { get; set; }

    public RunResultControl(IApiService apiService)
    {
        InitializeComponent();

        _apiService = apiService;
    }

    public async Task StartAsync()
    {
        if (StoryAction == null)
            throw new InvalidOperationException("StoryAction is not set");

        _cancellationTokenSource = new CancellationTokenSource();

        var cancellationToken = _cancellationTokenSource.Token;

        var count = StoryAction.Options.Count;
        var timeout = TimeSpan.FromSeconds(StoryAction.Options.TimeoutInSeconds);
        var mode = StoryAction.Options.ExecutionMode;
        var verb = StoryAction.Verb;

        var url = StoryAction.BaseUrl + StoryAction.RelativeUrl;

        IsRunning = true;
        RunProgressBar.Maximum = count;
        RunProgressBar.Value = 0;

        try
        {
            switch (mode)
            {
                case StoryActionOptions.Mode.Parallel:

                    await Parallel.ForAsync(1, count + 1, cancellationToken, async (_, innerCancellationToken) =>
                    {
                        Response = await CallApiAsync(verb, url, timeout, StoryAction.RequestBody, innerCancellationToken);

                        Progress();
                    });
                    break;

                case StoryActionOptions.Mode.Sequential:

                    for (int i = 1; i <= count; i++)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            break;

                        Response = await CallApiAsync(verb, url, timeout, StoryAction.RequestBody, cancellationToken);

                        Progress();
                    }
                    break;
            }
        }
        finally
        {
            IsCompleted = true;

            if (Response?.Exception != null)
                IsCompletedInError = true;

            IsRunning = false;

            Completed?.Invoke(this, Response!);
        }
    }

    private void Progress()
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => RunProgressBar.Value++);
            return;
        }

        RunProgressBar.Value++;
    }

    private async Task<ServiceResponse> CallApiAsync(string verb, string url, TimeSpan timeout, string? jsonRequest, CancellationToken cancellationToken) => verb switch
    {
        HttpVerbs.Get => await _apiService.GetAsync(url, timeout, cancellationToken),
        HttpVerbs.Post => string.IsNullOrEmpty(jsonRequest) ? GetMissingRequestResponse() : await _apiService.PostAsync(url, jsonRequest, timeout, cancellationToken),
        HttpVerbs.Put => string.IsNullOrEmpty(jsonRequest) ? GetMissingRequestResponse() : await _apiService.PutAsync(url, jsonRequest, timeout, cancellationToken),
        HttpVerbs.Patch => string.IsNullOrEmpty(jsonRequest) ? GetMissingRequestResponse() : await _apiService.PatchAsync(url, jsonRequest, timeout, cancellationToken),
        HttpVerbs.Delete => await _apiService.DeleteAsync(url, timeout, cancellationToken),
        _ => throw new InvalidOperationException($"Verb {verb} not supported"),
    };

    private static ServiceResponse GetMissingRequestResponse() => new() { Exception = new InvalidOperationException("Missing request body") };

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
}
