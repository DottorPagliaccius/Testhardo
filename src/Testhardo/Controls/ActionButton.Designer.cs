namespace Testhardo;

partial class ActionButton
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
        MainButton = new ReaLTaiizor.Controls.MaterialButton();
        VerbLabel = new Label();
        ToolTipManager = new ReaLTaiizor.Controls.PoisonToolTip();
        SuspendLayout();
        // 
        // MainButton
        // 
        MainButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        MainButton.AutoEllipsis = true;
        MainButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        MainButton.Cursor = Cursors.Hand;
        MainButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
        MainButton.Depth = 0;
        MainButton.HighEmphasis = true;
        MainButton.Icon = null;
        MainButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
        MainButton.Location = new Point(7, 7);
        MainButton.Margin = new Padding(0);
        MainButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        MainButton.Name = "MainButton";
        MainButton.NoAccentTextColor = Color.Empty;
        MainButton.Size = new Size(74, 36);
        MainButton.TabIndex = 0;
        MainButton.Text = "ACTION";
        MainButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
        MainButton.UseAccentColor = false;
        MainButton.UseVisualStyleBackColor = true;
        // 
        // VerbLabel
        // 
        VerbLabel.AutoSize = true;
        VerbLabel.BackColor = Color.Red;
        VerbLabel.BorderStyle = BorderStyle.FixedSingle;
        VerbLabel.Font = new Font("Roboto Condensed Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        VerbLabel.ForeColor = Color.White;
        VerbLabel.Location = new Point(0, 0);
        VerbLabel.Margin = new Padding(0);
        VerbLabel.Name = "VerbLabel";
        VerbLabel.Padding = new Padding(2);
        VerbLabel.Size = new Size(40, 20);
        VerbLabel.TabIndex = 1;
        VerbLabel.Text = "VERB";
        VerbLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ToolTipManager
        // 
        ToolTipManager.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
        ToolTipManager.StyleManager = null;
        ToolTipManager.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
        // 
        // ActionButton
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        BackColor = Color.Transparent;
        Controls.Add(VerbLabel);
        Controls.Add(MainButton);
        Margin = new Padding(0);
        Name = "ActionButton";
        Padding = new Padding(7, 7, 1, 1);
        Size = new Size(82, 44);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ReaLTaiizor.Controls.MaterialButton MainButton;
    private Label VerbLabel;
    private ReaLTaiizor.Controls.PoisonToolTip ToolTipManager;
}
