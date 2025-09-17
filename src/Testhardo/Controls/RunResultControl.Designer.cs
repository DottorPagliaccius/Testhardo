namespace Testhardo;

partial class RunResultControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        RunProgressBar = new ReaLTaiizor.Controls.MaterialProgressBar();
        TitleLabel = new ReaLTaiizor.Controls.MaterialLabel();
        SuspendLayout();
        // 
        // RunProgressBar
        // 
        RunProgressBar.Depth = 0;
        RunProgressBar.Dock = DockStyle.Right;
        RunProgressBar.Location = new Point(421, 0);
        RunProgressBar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        RunProgressBar.Name = "RunProgressBar";
        RunProgressBar.Size = new Size(191, 64);
        RunProgressBar.Step = 1;
        RunProgressBar.TabIndex = 0;
        RunProgressBar.UseAccentColor = false;
        // 
        // TitleLabel
        // 
        TitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        TitleLabel.AutoEllipsis = true;
        TitleLabel.Depth = 0;
        TitleLabel.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
        TitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Body2;
        TitleLabel.Location = new Point(10, 0);
        TitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        TitleLabel.Name = "TitleLabel";
        TitleLabel.Size = new Size(412, 64);
        TitleLabel.TabIndex = 1;
        TitleLabel.Text = "http://address/method";
        TitleLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // RunResultControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(TitleLabel);
        Controls.Add(RunProgressBar);
        Name = "RunResultControl";
        Size = new Size(612, 64);
        ResumeLayout(false);
    }

    #endregion

    private ReaLTaiizor.Controls.MaterialProgressBar RunProgressBar;
    private ReaLTaiizor.Controls.MaterialLabel TitleLabel;
}
