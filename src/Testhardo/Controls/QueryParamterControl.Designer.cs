namespace Testhardo;

partial class QueryParameterControl
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
        NameLabel = new ReaLTaiizor.Controls.MaterialLabel();
        TypelLabel = new ReaLTaiizor.Controls.MaterialLabel();
        ValueTextBox = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
        AsteriskLabel = new ReaLTaiizor.Controls.MaterialLabel();
        SuspendLayout();
        // 
        // NameLabel
        // 
        NameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        NameLabel.AutoEllipsis = true;
        NameLabel.Depth = 0;
        NameLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        NameLabel.Location = new Point(13, 11);
        NameLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        NameLabel.Name = "NameLabel";
        NameLabel.Size = new Size(150, 19);
        NameLabel.TabIndex = 0;
        NameLabel.Text = "Name";
        // 
        // TypelLabel
        // 
        TypelLabel.AutoSize = true;
        TypelLabel.Depth = 0;
        TypelLabel.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
        TypelLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Caption;
        TypelLabel.Location = new Point(3, 30);
        TypelLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        TypelLabel.Name = "TypelLabel";
        TypelLabel.Size = new Size(27, 14);
        TypelLabel.TabIndex = 1;
        TypelLabel.Text = "Type";
        // 
        // ValueTextBox
        // 
        ValueTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        ValueTextBox.AnimateReadOnly = false;
        ValueTextBox.AutoCompleteMode = AutoCompleteMode.None;
        ValueTextBox.AutoCompleteSource = AutoCompleteSource.None;
        ValueTextBox.BackgroundImageLayout = ImageLayout.None;
        ValueTextBox.CharacterCasing = CharacterCasing.Normal;
        ValueTextBox.Depth = 0;
        ValueTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
        ValueTextBox.HideSelection = true;
        ValueTextBox.LeadingIcon = null;
        ValueTextBox.Location = new Point(169, 11);
        ValueTextBox.MaxLength = 32767;
        ValueTextBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
        ValueTextBox.Name = "ValueTextBox";
        ValueTextBox.PasswordChar = '\0';
        ValueTextBox.PrefixSuffixText = null;
        ValueTextBox.ReadOnly = false;
        ValueTextBox.RightToLeft = RightToLeft.No;
        ValueTextBox.SelectedText = "";
        ValueTextBox.SelectionLength = 0;
        ValueTextBox.SelectionStart = 0;
        ValueTextBox.ShortcutsEnabled = true;
        ValueTextBox.Size = new Size(208, 36);
        ValueTextBox.TabIndex = 2;
        ValueTextBox.TabStop = false;
        ValueTextBox.TextAlign = HorizontalAlignment.Left;
        ValueTextBox.TrailingIcon = null;
        ValueTextBox.UseSystemPasswordChar = false;
        ValueTextBox.UseTallSize = false;
        ValueTextBox.Leave += ValueTextBox_Leave;
        // 
        // AsteriskLabel
        // 
        AsteriskLabel.AutoSize = true;
        AsteriskLabel.Depth = 0;
        AsteriskLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        AsteriskLabel.HighEmphasis = true;
        AsteriskLabel.Location = new Point(3, 11);
        AsteriskLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        AsteriskLabel.Name = "AsteriskLabel";
        AsteriskLabel.Size = new Size(8, 19);
        AsteriskLabel.TabIndex = 3;
        AsteriskLabel.Text = "*";
        AsteriskLabel.UseAccent = true;
        // 
        // QueryParameterControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(AsteriskLabel);
        Controls.Add(ValueTextBox);
        Controls.Add(TypelLabel);
        Controls.Add(NameLabel);
        Name = "QueryParameterControl";
        Size = new Size(380, 63);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ReaLTaiizor.Controls.MaterialLabel NameLabel;
    private ReaLTaiizor.Controls.MaterialLabel TypelLabel;
    private ReaLTaiizor.Controls.MaterialTextBoxEdit ValueTextBox;
    private ReaLTaiizor.Controls.MaterialLabel AsteriskLabel;
}
