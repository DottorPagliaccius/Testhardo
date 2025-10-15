namespace Testhardo;

partial class RunDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        RunPanel = new FlowLayoutPanel();
        LogRichTextBox = new ReaLTaiizor.Controls.MaterialRichTextBox();
        StatisticsPanel = new Panel();
        MethodLabel = new ReaLTaiizor.Controls.MaterialLabel();
        P90Label = new ReaLTaiizor.Controls.MaterialLabel();
        P75Label = new ReaLTaiizor.Controls.MaterialLabel();
        P50Label = new ReaLTaiizor.Controls.MaterialLabel();
        ThroughputLabel = new ReaLTaiizor.Controls.MaterialLabel();
        P99Label = new ReaLTaiizor.Controls.MaterialLabel();
        P95Label = new ReaLTaiizor.Controls.MaterialLabel();
        StdDevLabel = new ReaLTaiizor.Controls.MaterialLabel();
        CountLabel = new ReaLTaiizor.Controls.MaterialLabel();
        MedianLabel = new ReaLTaiizor.Controls.MaterialLabel();
        MaxLabel = new ReaLTaiizor.Controls.MaterialLabel();
        MinLabel = new ReaLTaiizor.Controls.MaterialLabel();
        AverageLabel = new ReaLTaiizor.Controls.MaterialLabel();
        TotalLabel = new ReaLTaiizor.Controls.MaterialLabel();
        RunButton = new ReaLTaiizor.Controls.MaterialButton();
        StopButton = new ReaLTaiizor.Controls.MaterialButton();
        ExitButton = new ReaLTaiizor.Controls.MaterialButton();
        ToolTipManager = new ToolTip(components);
        StatisticsPanel.SuspendLayout();
        SuspendLayout();
        // 
        // RunPanel
        // 
        RunPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        RunPanel.AutoScroll = true;
        RunPanel.Location = new Point(6, 27);
        RunPanel.Name = "RunPanel";
        RunPanel.Size = new Size(480, 472);
        RunPanel.TabIndex = 0;
        // 
        // LogRichTextBox
        // 
        LogRichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        LogRichTextBox.AutoWordSelection = true;
        LogRichTextBox.BackColor = Color.FromArgb(255, 255, 255);
        LogRichTextBox.BorderStyle = BorderStyle.None;
        LogRichTextBox.Depth = 0;
        LogRichTextBox.Font = new Font("Microsoft Sans Serif", 10F);
        LogRichTextBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
        LogRichTextBox.Hint = "";
        LogRichTextBox.Location = new Point(492, 27);
        LogRichTextBox.MaxLength = 32767;
        LogRichTextBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        LogRichTextBox.Name = "LogRichTextBox";
        LogRichTextBox.ReadOnly = true;
        LogRichTextBox.Size = new Size(535, 472);
        LogRichTextBox.TabIndex = 1;
        LogRichTextBox.Text = "";
        LogRichTextBox.WordWrap = false;
        // 
        // StatisticsPanel
        // 
        StatisticsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        StatisticsPanel.Controls.Add(MethodLabel);
        StatisticsPanel.Controls.Add(P90Label);
        StatisticsPanel.Controls.Add(P75Label);
        StatisticsPanel.Controls.Add(P50Label);
        StatisticsPanel.Controls.Add(ThroughputLabel);
        StatisticsPanel.Controls.Add(P99Label);
        StatisticsPanel.Controls.Add(P95Label);
        StatisticsPanel.Controls.Add(StdDevLabel);
        StatisticsPanel.Controls.Add(CountLabel);
        StatisticsPanel.Controls.Add(MedianLabel);
        StatisticsPanel.Controls.Add(MaxLabel);
        StatisticsPanel.Controls.Add(MinLabel);
        StatisticsPanel.Controls.Add(AverageLabel);
        StatisticsPanel.Controls.Add(TotalLabel);
        StatisticsPanel.Location = new Point(1033, 27);
        StatisticsPanel.Name = "StatisticsPanel";
        StatisticsPanel.Size = new Size(389, 424);
        StatisticsPanel.TabIndex = 2;
        StatisticsPanel.Visible = false;
        // 
        // MethodLabel
        // 
        MethodLabel.AutoEllipsis = true;
        MethodLabel.AutoSize = true;
        MethodLabel.Depth = 0;
        MethodLabel.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
        MethodLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
        MethodLabel.Location = new Point(12, 10);
        MethodLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        MethodLabel.Name = "MethodLabel";
        MethodLabel.Size = new Size(79, 24);
        MethodLabel.TabIndex = 13;
        MethodLabel.Text = "[method]";
        // 
        // P90Label
        // 
        P90Label.AutoSize = true;
        P90Label.Depth = 0;
        P90Label.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        P90Label.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        P90Label.Location = new Point(12, 196);
        P90Label.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        P90Label.Name = "P90Label";
        P90Label.Size = new Size(30, 17);
        P90Label.TabIndex = 12;
        P90Label.Text = "P90:";
        ToolTipManager.SetToolTip(P90Label, "P90 (90th percentile): 90% of requests completed at or below this response time. Shows the experience of slower users");
        // 
        // P75Label
        // 
        P75Label.AutoSize = true;
        P75Label.Depth = 0;
        P75Label.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        P75Label.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        P75Label.Location = new Point(12, 179);
        P75Label.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        P75Label.Name = "P75Label";
        P75Label.Size = new Size(30, 17);
        P75Label.TabIndex = 11;
        P75Label.Text = "P75:";
        ToolTipManager.SetToolTip(P75Label, "P75 (75th percentile): 75% of requests completed at or below this response time. Good indicator of typical performance for most users");
        // 
        // P50Label
        // 
        P50Label.AutoSize = true;
        P50Label.Depth = 0;
        P50Label.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        P50Label.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        P50Label.Location = new Point(12, 162);
        P50Label.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        P50Label.Name = "P50Label";
        P50Label.Size = new Size(30, 17);
        P50Label.TabIndex = 10;
        P50Label.Text = "P50:";
        ToolTipManager.SetToolTip(P50Label, "P50 (50th percentile): 50% of requests completed at or below this response time. This usually matches the median");
        // 
        // ThroughputLabel
        // 
        ThroughputLabel.AutoSize = true;
        ThroughputLabel.Depth = 0;
        ThroughputLabel.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        ThroughputLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        ThroughputLabel.Location = new Point(12, 248);
        ThroughputLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        ThroughputLabel.Name = "ThroughputLabel";
        ThroughputLabel.Size = new Size(80, 17);
        ThroughputLabel.TabIndex = 9;
        ThroughputLabel.Text = "Throughput:";
        ToolTipManager.SetToolTip(ThroughputLabel, "Nnumber of requests successfully processed per second. Higher values indicate better load handling");
        // 
        // P99Label
        // 
        P99Label.AutoSize = true;
        P99Label.Depth = 0;
        P99Label.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        P99Label.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        P99Label.Location = new Point(12, 230);
        P99Label.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        P99Label.Name = "P99Label";
        P99Label.Size = new Size(30, 17);
        P99Label.TabIndex = 8;
        P99Label.Text = "P99:";
        ToolTipManager.SetToolTip(P99Label, "P99 (99th percentile): 99% of requests completed at or below this response time. Captures rare but important slow requests (tail latency)");
        // 
        // P95Label
        // 
        P95Label.AutoSize = true;
        P95Label.Depth = 0;
        P95Label.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        P95Label.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        P95Label.Location = new Point(12, 213);
        P95Label.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        P95Label.Name = "P95Label";
        P95Label.Size = new Size(30, 17);
        P95Label.TabIndex = 7;
        P95Label.Text = "P95:";
        ToolTipManager.SetToolTip(P95Label, "P95 (95th percentile): 95% of requests completed at or below this response time. A common performance SLA benchmark");
        // 
        // StdDevLabel
        // 
        StdDevLabel.AutoSize = true;
        StdDevLabel.Depth = 0;
        StdDevLabel.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        StdDevLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        StdDevLabel.Location = new Point(12, 145);
        StdDevLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        StdDevLabel.Name = "StdDevLabel";
        StdDevLabel.Size = new Size(53, 17);
        StdDevLabel.TabIndex = 6;
        StdDevLabel.Text = "Std Dev:";
        ToolTipManager.SetToolTip(StdDevLabel, "Standard deviation — shows how much response times vary from the average. A low value means stable performance, a high value means inconsistency");
        // 
        // CountLabel
        // 
        CountLabel.AutoSize = true;
        CountLabel.Depth = 0;
        CountLabel.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        CountLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        CountLabel.Location = new Point(12, 43);
        CountLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        CountLabel.Name = "CountLabel";
        CountLabel.Size = new Size(65, 17);
        CountLabel.TabIndex = 5;
        CountLabel.Text = "Requests:";
        ToolTipManager.SetToolTip(CountLabel, "Total number of requests executed during the test");
        // 
        // MedianLabel
        // 
        MedianLabel.AutoSize = true;
        MedianLabel.Depth = 0;
        MedianLabel.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        MedianLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        MedianLabel.Location = new Point(12, 128);
        MedianLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        MedianLabel.Name = "MedianLabel";
        MedianLabel.Size = new Size(53, 17);
        MedianLabel.TabIndex = 4;
        MedianLabel.Text = "Median:";
        ToolTipManager.SetToolTip(MedianLabel, "Median response time — half of the requests completed faster than this value");
        // 
        // MaxLabel
        // 
        MaxLabel.AutoSize = true;
        MaxLabel.Depth = 0;
        MaxLabel.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        MaxLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        MaxLabel.Location = new Point(12, 111);
        MaxLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        MaxLabel.Name = "MaxLabel";
        MaxLabel.Size = new Size(32, 17);
        MaxLabel.TabIndex = 3;
        MaxLabel.Text = "Max:";
        ToolTipManager.SetToolTip(MaxLabel, "Maximum response time — the slowest request observed");
        // 
        // MinLabel
        // 
        MinLabel.AutoSize = true;
        MinLabel.Depth = 0;
        MinLabel.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        MinLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        MinLabel.Location = new Point(12, 94);
        MinLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        MinLabel.Name = "MinLabel";
        MinLabel.Size = new Size(29, 17);
        MinLabel.TabIndex = 2;
        MinLabel.Text = "Min:";
        ToolTipManager.SetToolTip(MinLabel, "Minimum response time — the fastest request observed.");
        // 
        // AverageLabel
        // 
        AverageLabel.AutoSize = true;
        AverageLabel.Depth = 0;
        AverageLabel.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        AverageLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        AverageLabel.Location = new Point(12, 77);
        AverageLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        AverageLabel.Name = "AverageLabel";
        AverageLabel.Size = new Size(58, 17);
        AverageLabel.TabIndex = 1;
        AverageLabel.Text = "Average:";
        ToolTipManager.SetToolTip(AverageLabel, "Average (mean) response time across all requests");
        // 
        // TotalLabel
        // 
        TotalLabel.AutoSize = true;
        TotalLabel.Depth = 0;
        TotalLabel.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        TotalLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Button;
        TotalLabel.Location = new Point(12, 60);
        TotalLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        TotalLabel.Name = "TotalLabel";
        TotalLabel.Size = new Size(39, 17);
        TotalLabel.TabIndex = 0;
        TotalLabel.Text = "Total:";
        ToolTipManager.SetToolTip(TotalLabel, "Total time taken to complete all requests (sum of individual durations)");
        // 
        // RunButton
        // 
        RunButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        RunButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        RunButton.Cursor = Cursors.Hand;
        RunButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
        RunButton.Depth = 0;
        RunButton.Enabled = false;
        RunButton.HighEmphasis = true;
        RunButton.Icon = null;
        RunButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
        RunButton.Location = new Point(1358, 460);
        RunButton.Margin = new Padding(4, 6, 4, 6);
        RunButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        RunButton.Name = "RunButton";
        RunButton.NoAccentTextColor = Color.Empty;
        RunButton.Size = new Size(64, 36);
        RunButton.TabIndex = 6;
        RunButton.Text = "Run";
        RunButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
        RunButton.UseAccentColor = false;
        RunButton.UseVisualStyleBackColor = true;
        RunButton.Click += RunButton_Click;
        // 
        // StopButton
        // 
        StopButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        StopButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        StopButton.Cursor = Cursors.Hand;
        StopButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
        StopButton.Depth = 0;
        StopButton.HighEmphasis = true;
        StopButton.Icon = null;
        StopButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
        StopButton.Location = new Point(1034, 460);
        StopButton.Margin = new Padding(4, 6, 4, 6);
        StopButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        StopButton.Name = "StopButton";
        StopButton.NoAccentTextColor = Color.Empty;
        StopButton.Size = new Size(64, 36);
        StopButton.TabIndex = 5;
        StopButton.Text = "Stop";
        StopButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
        StopButton.UseAccentColor = false;
        StopButton.UseVisualStyleBackColor = true;
        StopButton.Click += StopButton_Click;
        // 
        // ExitButton
        // 
        ExitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        ExitButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ExitButton.Cursor = Cursors.Hand;
        ExitButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
        ExitButton.Depth = 0;
        ExitButton.Enabled = false;
        ExitButton.HighEmphasis = true;
        ExitButton.Icon = null;
        ExitButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
        ExitButton.Location = new Point(1195, 463);
        ExitButton.Margin = new Padding(4, 6, 4, 6);
        ExitButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        ExitButton.Name = "ExitButton";
        ExitButton.NoAccentTextColor = Color.Empty;
        ExitButton.Size = new Size(64, 36);
        ExitButton.TabIndex = 6;
        ExitButton.Text = "X";
        ExitButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
        ExitButton.UseAccentColor = false;
        ExitButton.UseVisualStyleBackColor = true;
        ExitButton.Visible = false;
        ExitButton.Click += ExitButton_Click;
        // 
        // RunDialog
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = ExitButton;
        ClientSize = new Size(1428, 505);
        Controls.Add(ExitButton);
        Controls.Add(StopButton);
        Controls.Add(RunButton);
        Controls.Add(StatisticsPanel);
        Controls.Add(LogRichTextBox);
        Controls.Add(RunPanel);
        FormStyle = ReaLTaiizor.Enum.Material.FormStyles.ActionBar_None;
        MaximizeBox = false;
        Name = "RunDialog";
        Padding = new Padding(3, 24, 3, 3);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "RunDialog";
        FormClosing += RunDialog_FormClosing;
        Load += RunDialog_Load;
        StatisticsPanel.ResumeLayout(false);
        StatisticsPanel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private FlowLayoutPanel RunPanel;
    private ReaLTaiizor.Controls.MaterialRichTextBox LogRichTextBox;
    private Panel StatisticsPanel;
    private ReaLTaiizor.Controls.MaterialButton RunButton;
    private ReaLTaiizor.Controls.MaterialButton StopButton;
    private ReaLTaiizor.Controls.MaterialButton ExitButton;
    private ReaLTaiizor.Controls.MaterialLabel MaxLabel;
    private ReaLTaiizor.Controls.MaterialLabel MinLabel;
    private ReaLTaiizor.Controls.MaterialLabel AverageLabel;
    private ReaLTaiizor.Controls.MaterialLabel TotalLabel;
    private ReaLTaiizor.Controls.MaterialLabel CountLabel;
    private ReaLTaiizor.Controls.MaterialLabel MedianLabel;
    private ReaLTaiizor.Controls.MaterialLabel StdDevLabel;
    private ReaLTaiizor.Controls.MaterialLabel P99Label;
    private ReaLTaiizor.Controls.MaterialLabel P95Label;
    private ReaLTaiizor.Controls.MaterialLabel ThroughputLabel;
    private ReaLTaiizor.Controls.MaterialLabel P75Label;
    private ReaLTaiizor.Controls.MaterialLabel P50Label;
    private ReaLTaiizor.Controls.MaterialLabel P90Label;
    private ToolTip ToolTipManager;
    private ReaLTaiizor.Controls.MaterialLabel MethodLabel;
}