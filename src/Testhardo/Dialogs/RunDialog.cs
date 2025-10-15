using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;
using System.ComponentModel;
using Testhardo.Services;

namespace Testhardo;

public partial class RunDialog : MaterialForm
{
    private readonly IServiceProvider _serviceProvider;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Story? StoryToRun { get; set; }

    public RunDialog(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
    }

    private async void RunDialog_Load(object sender, EventArgs e)
    {
        LoadStoryActions();

        await Task.Delay(500);

        _ = StartNextAsync();
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
            runResultControl.Width = RunPanel.Width - 10;

            runResultControl.Completed += async (_, __) => await StartNextAsync();
            runResultControl.Click += (_, __) => ShowStatistics(action.Value.RelativeUrl, runResultControl.Statistics);
            runResultControl.ServiceCalled += (_, e) =>
            {
                ShowStatistics(action.Value.RelativeUrl, runResultControl.Statistics);
                Log(e.Verb, e.Url, e.Response, e.ElapsedTime, e.Index, e.Total);
            };

            RunPanel.Controls.Add(runResultControl);
        }
    }

    private void ShowStatistics(string methodName, Statistics? statistics)
    {
        if (statistics == null)
        {
            StatisticsPanel.Visible = false;
            return;
        }

        MethodLabel.Text = methodName;
        CountLabel.Text = $"Requests: {statistics.Count}";
        TotalLabel.Text = $"Total: {statistics.TotalDuration.TotalMilliseconds:N0} ms";
        AverageLabel.Text = $"Average: {statistics.Average:N0} ms";
        MedianLabel.Text = $"Median: {statistics.Median:N0} ms";
        MinLabel.Text = $"Min: {statistics.Min:N0} ms";
        MaxLabel.Text = $"Max: {statistics.Max:N0} ms";
        StdDevLabel.Text = $"StdDev: {statistics.StandardDeviation:N0} ms";
        P50Label.Text = $"P50: {statistics.Percentile50:N0} ms";
        P75Label.Text = $"P75: {statistics.Percentile75:N0} ms";
        P90Label.Text = $"P90: {statistics.Percentile90:N0} ms";
        P95Label.Text = $"P95: {statistics.Percentile95:N0} ms";
        P99Label.Text = $"P99: {statistics.Percentile99:N0} ms";
        ThroughputLabel.Text = $"Throughput: {statistics.Throughput:N0} req/s";

        StatisticsPanel.Visible = true;
    }

    private void Log(string verb, string url, ServiceResponse response, TimeSpan elapsedTime, int? index, int? total)
    {
        LogRichTextBox.SelectionStart = LogRichTextBox.TextLength;
        LogRichTextBox.SelectionLength = 0;

        LogRichTextBox.SelectionColor = Color.White;
        LogRichTextBox.SelectionBackColor = Utility.GetActionColor(verb);
        LogRichTextBox.AppendText($" {verb} ");
        LogRichTextBox.SelectionBackColor = LogRichTextBox.BackColor;
        LogRichTextBox.SelectionColor = LogRichTextBox.ForeColor;
        LogRichTextBox.AppendText($" {url} ");

        if (index != null)
            LogRichTextBox.AppendText($" {index}/{total} ");

        LogRichTextBox.SelectionBackColor = response.Exception != null || response.StatusCode >= 400 ? Color.Red : Color.Green;
        LogRichTextBox.SelectionColor = Color.White;
        LogRichTextBox.AppendText(response.Exception?.Message ?? response?.StatusCode.ToString() ?? "!!");
        LogRichTextBox.SelectionBackColor = LogRichTextBox.BackColor;
        LogRichTextBox.SelectionColor = LogRichTextBox.ForeColor;
        LogRichTextBox.AppendText($"  ({elapsedTime.TotalMilliseconds:N0} ms)");
        LogRichTextBox.ScrollToCaret();
        LogRichTextBox.AppendText(Environment.NewLine);
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void RunButton_Click(object sender, EventArgs e)
    {
        RunButton.Enabled = false;
        LogRichTextBox.Clear();

        foreach (var control in RunPanel.Controls.OfType<RunResultControl>())
        {
            control.Reset();
        }

        var runControl = RunPanel.Controls.OfType<RunResultControl>().FirstOrDefault(x => !x.IsCompleted);

        if (runControl != null)
            await runControl.StartAsync();

        StopButton.Enabled = false;
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
        foreach (var control in RunPanel.Controls.OfType<RunResultControl>().Where(x => !x.IsCompleted))
        {
            control.Stop();
        }
    }

    private void RunDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        StopButton_Click(sender, e);
    }
}
