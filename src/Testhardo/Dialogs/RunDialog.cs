using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Threading.Tasks;
using Testhardo.Services;

namespace Testhardo;

public partial class RunDialog : MaterialForm
{
    private CancellationTokenSource _cancellationTokenSource = new();
    private ConcurrentDictionary<StoryAction, ServiceResponse> _responses = new();

    private readonly IApiService _apiService;
    private readonly IServiceProvider _serviceProvider;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Story? StoryToRun { get; set; }

    public RunDialog(IApiService apiService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _apiService = apiService;
        _serviceProvider = serviceProvider;
    }

    private async void RunDialog_Load(object sender, EventArgs e)
    {
        LoadStoryActions();

        await StartNextAsync();
    }

    private async Task StartNextAsync()
    {
        var nextControl = RunPanel.Controls.OfType<RunResultControl>().FirstOrDefault(x => !x.IsCompleted);

        if (nextControl != null)
        {
            await nextControl.StartAsync();
        }
        else
        {
            StopButton.Enabled = false;
            RunButton.Enabled = true;
        }
    }

    private void LoadStoryActions()
    {
        if (StoryToRun == null)
            return;

        foreach (var action in StoryToRun.Actions)
        {
            var runResultControl = _serviceProvider.GetRequiredService<RunResultControl>();

            runResultControl.StoryAction = action.Value;

            runResultControl.Completed += async (_, e) => await StartNextAsync();

            RunPanel.Controls.Add(runResultControl);
        }
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void RunButton_Click(object sender, EventArgs e)
    {
        RunButton.Enabled = false;

        foreach (var control in RunPanel.Controls.OfType<RunResultControl>())
        {
            control.Reset();
        }

        foreach (var control in RunPanel.Controls.OfType<RunResultControl>())
        {
            await control.StartAsync();
        }

        StopButton.Enabled = false;
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
        foreach (var control in RunPanel.Controls.OfType<RunResultControl>().Where(x => !x.IsCompleted))
        {
            control.Stop();
        }
    }
}
