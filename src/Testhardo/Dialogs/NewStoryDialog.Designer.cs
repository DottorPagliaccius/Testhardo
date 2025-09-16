namespace Testhardo;

partial class NewStoryDialog
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
        OkButton = new ReaLTaiizor.Controls.MaterialButton();
        ExitButton = new ReaLTaiizor.Controls.MaterialButton();
        NameTextBox = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
        ErrorLabel = new ReaLTaiizor.Controls.MaterialLabel();
        SuspendLayout();
        // 
        // OkButton
        // 
        OkButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        OkButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        OkButton.Cursor = Cursors.Hand;
        OkButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
        OkButton.Depth = 0;
        OkButton.HighEmphasis = true;
        OkButton.Icon = null;
        OkButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
        OkButton.Location = new Point(534, 81);
        OkButton.Margin = new Padding(4, 6, 4, 6);
        OkButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        OkButton.Name = "OkButton";
        OkButton.NoAccentTextColor = Color.Empty;
        OkButton.Size = new Size(64, 36);
        OkButton.TabIndex = 3;
        OkButton.Text = "Ok";
        OkButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
        OkButton.UseAccentColor = false;
        OkButton.UseVisualStyleBackColor = true;
        OkButton.Click += OkButton_Click;
        // 
        // ExitButton
        // 
        ExitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        ExitButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ExitButton.Cursor = Cursors.Hand;
        ExitButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
        ExitButton.Depth = 0;
        ExitButton.HighEmphasis = true;
        ExitButton.Icon = null;
        ExitButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
        ExitButton.Location = new Point(437, 81);
        ExitButton.Margin = new Padding(4, 6, 4, 6);
        ExitButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        ExitButton.Name = "ExitButton";
        ExitButton.NoAccentTextColor = Color.Empty;
        ExitButton.Size = new Size(77, 36);
        ExitButton.TabIndex = 2;
        ExitButton.Text = "cancel";
        ExitButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
        ExitButton.UseAccentColor = true;
        ExitButton.UseVisualStyleBackColor = true;
        ExitButton.Click += CancelButton_Click;
        // 
        // NameTextBox
        // 
        NameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        NameTextBox.AnimateReadOnly = false;
        NameTextBox.AutoCompleteMode = AutoCompleteMode.None;
        NameTextBox.AutoCompleteSource = AutoCompleteSource.None;
        NameTextBox.BackgroundImageLayout = ImageLayout.None;
        NameTextBox.CharacterCasing = CharacterCasing.Normal;
        NameTextBox.Cursor = Cursors.IBeam;
        NameTextBox.Depth = 0;
        NameTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
        NameTextBox.HideSelection = true;
        NameTextBox.LeadingIcon = null;
        NameTextBox.Location = new Point(6, 21);
        NameTextBox.MaxLength = 32767;
        NameTextBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
        NameTextBox.Name = "NameTextBox";
        NameTextBox.PasswordChar = '\0';
        NameTextBox.PrefixSuffixText = null;
        NameTextBox.ReadOnly = false;
        NameTextBox.RightToLeft = RightToLeft.No;
        NameTextBox.SelectedText = "";
        NameTextBox.SelectionLength = 0;
        NameTextBox.SelectionStart = 0;
        NameTextBox.ShortcutsEnabled = true;
        NameTextBox.Size = new Size(592, 48);
        NameTextBox.TabIndex = 1;
        NameTextBox.TabStop = false;
        NameTextBox.TextAlign = HorizontalAlignment.Left;
        NameTextBox.TrailingIcon = null;
        NameTextBox.UseAccent = false;
        NameTextBox.UseSystemPasswordChar = false;
        // 
        // ErrorLabel
        // 
        ErrorLabel.Depth = 0;
        ErrorLabel.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
        ErrorLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Caption;
        ErrorLabel.Location = new Point(6, 81);
        ErrorLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        ErrorLabel.Name = "ErrorLabel";
        ErrorLabel.Size = new Size(404, 37);
        ErrorLabel.TabIndex = 2;
        ErrorLabel.UseAccent = true;
        // 
        // NewStoryDialog
        // 
        AcceptButton = OkButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(605, 126);
        ControlBox = false;
        Controls.Add(ErrorLabel);
        Controls.Add(NameTextBox);
        Controls.Add(ExitButton);
        Controls.Add(OkButton);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "NewStoryDialog";
        ShowIcon = false;
        ShowInTaskbar = false;
        SizeGripStyle = SizeGripStyle.Hide;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Import";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ReaLTaiizor.Controls.MaterialButton OkButton;
    private ReaLTaiizor.Controls.MaterialButton ExitButton;
    private ReaLTaiizor.Controls.MaterialTextBoxEdit NameTextBox;
    private ReaLTaiizor.Controls.MaterialLabel ErrorLabel;
}