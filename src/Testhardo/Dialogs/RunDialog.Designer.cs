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
        RunPanel = new FlowLayoutPanel();
        LogRichTextBox = new ReaLTaiizor.Controls.MetroRichTextBox();
        ResourcePanel = new Panel();
        RunButton = new ReaLTaiizor.Controls.MaterialButton();
        StopButton = new ReaLTaiizor.Controls.MaterialButton();
        ExitButton = new ReaLTaiizor.Controls.MaterialButton();
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
        LogRichTextBox.AutoWordSelection = false;
        LogRichTextBox.BorderColor = Color.FromArgb(155, 155, 155);
        LogRichTextBox.DisabledBackColor = Color.FromArgb(204, 204, 204);
        LogRichTextBox.DisabledBorderColor = Color.FromArgb(155, 155, 155);
        LogRichTextBox.DisabledForeColor = Color.FromArgb(136, 136, 136);
        LogRichTextBox.Font = new Font("Microsoft Sans Serif", 10F);
        LogRichTextBox.HoverColor = Color.FromArgb(102, 102, 102);
        LogRichTextBox.IsDerivedStyle = true;
        LogRichTextBox.Lines = null;
        LogRichTextBox.Location = new Point(492, 27);
        LogRichTextBox.MaxLength = 32767;
        LogRichTextBox.Name = "LogRichTextBox";
        LogRichTextBox.ReadOnly = false;
        LogRichTextBox.Size = new Size(535, 472);
        LogRichTextBox.Style = ReaLTaiizor.Enum.Metro.Style.Light;
        LogRichTextBox.StyleManager = null;
        LogRichTextBox.TabIndex = 1;
        LogRichTextBox.ThemeAuthor = "Taiizor";
        LogRichTextBox.ThemeName = "MetroLight";
        LogRichTextBox.WordWrap = false;
        // 
        // ResourcePanel
        // 
        ResourcePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        ResourcePanel.Location = new Point(1033, 27);
        ResourcePanel.Name = "ResourcePanel";
        ResourcePanel.Size = new Size(389, 424);
        ResourcePanel.TabIndex = 2;
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
        RunButton.TabIndex = 4;
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
        StopButton.Enabled = false;
        StopButton.HighEmphasis = true;
        StopButton.Icon = null;
        StopButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
        StopButton.Location = new Point(1211, 460);
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
        ExitButton.Location = new Point(1033, 463);
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
        Controls.Add(ResourcePanel);
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
        Load += RunDialog_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private FlowLayoutPanel RunPanel;
    private ReaLTaiizor.Controls.MetroRichTextBox LogRichTextBox;
    private Panel ResourcePanel;
    private ReaLTaiizor.Controls.MaterialButton RunButton;
    private ReaLTaiizor.Controls.MaterialButton StopButton;
    private ReaLTaiizor.Controls.MaterialButton ExitButton;
}