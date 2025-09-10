namespace Testhardo;

partial class ImportDialog
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
        ImportButton = new ReaLTaiizor.Controls.MaterialButton();
        ExitButton = new ReaLTaiizor.Controls.MaterialButton();
        SwaggerUrlTextBox = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
        ErrorLabel = new ReaLTaiizor.Controls.MaterialLabel();
        SuspendLayout();
        // 
        // ImportButton
        // 
        ImportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        ImportButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ImportButton.Cursor = Cursors.Hand;
        ImportButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
        ImportButton.Depth = 0;
        ImportButton.Enabled = false;
        ImportButton.HighEmphasis = true;
        ImportButton.Icon = null;
        ImportButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
        ImportButton.Location = new Point(742, 81);
        ImportButton.Margin = new Padding(4, 6, 4, 6);
        ImportButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        ImportButton.Name = "ImportButton";
        ImportButton.NoAccentTextColor = Color.Empty;
        ImportButton.Size = new Size(76, 36);
        ImportButton.TabIndex = 3;
        ImportButton.Text = "Import";
        ImportButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
        ImportButton.UseAccentColor = false;
        ImportButton.UseVisualStyleBackColor = true;
        ImportButton.Click += ImportButton_Click;
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
        ExitButton.Location = new Point(657, 81);
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
        // SwaggerUrlTextBox
        // 
        SwaggerUrlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        SwaggerUrlTextBox.AnimateReadOnly = false;
        SwaggerUrlTextBox.AutoCompleteMode = AutoCompleteMode.None;
        SwaggerUrlTextBox.AutoCompleteSource = AutoCompleteSource.None;
        SwaggerUrlTextBox.BackgroundImageLayout = ImageLayout.None;
        SwaggerUrlTextBox.CharacterCasing = CharacterCasing.Normal;
        SwaggerUrlTextBox.Cursor = Cursors.IBeam;
        SwaggerUrlTextBox.Depth = 0;
        SwaggerUrlTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
        SwaggerUrlTextBox.HideSelection = true;
        SwaggerUrlTextBox.Hint = "Paste Swagger JSON url, es: http://localhost/MyAPI/swagger/v1/swagger.json";
        SwaggerUrlTextBox.LeadingIcon = null;
        SwaggerUrlTextBox.Location = new Point(6, 21);
        SwaggerUrlTextBox.MaxLength = 32767;
        SwaggerUrlTextBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
        SwaggerUrlTextBox.Name = "SwaggerUrlTextBox";
        SwaggerUrlTextBox.PasswordChar = '\0';
        SwaggerUrlTextBox.PrefixSuffixText = null;
        SwaggerUrlTextBox.ReadOnly = false;
        SwaggerUrlTextBox.RightToLeft = RightToLeft.No;
        SwaggerUrlTextBox.SelectedText = "";
        SwaggerUrlTextBox.SelectionLength = 0;
        SwaggerUrlTextBox.SelectionStart = 0;
        SwaggerUrlTextBox.ShortcutsEnabled = true;
        SwaggerUrlTextBox.Size = new Size(812, 48);
        SwaggerUrlTextBox.TabIndex = 1;
        SwaggerUrlTextBox.TabStop = false;
        SwaggerUrlTextBox.TextAlign = HorizontalAlignment.Left;
        SwaggerUrlTextBox.TrailingIcon = null;
        SwaggerUrlTextBox.UseAccent = false;
        SwaggerUrlTextBox.UseSystemPasswordChar = false;
        SwaggerUrlTextBox.TextChanged += SwaggerUrlTextBox_TextChanged;
        // 
        // ErrorLabel
        // 
        ErrorLabel.Depth = 0;
        ErrorLabel.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
        ErrorLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Caption;
        ErrorLabel.Location = new Point(6, 81);
        ErrorLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
        ErrorLabel.Name = "ErrorLabel";
        ErrorLabel.Size = new Size(644, 37);
        ErrorLabel.TabIndex = 2;
        ErrorLabel.UseAccent = true;
        // 
        // ImportDialog
        // 
        AcceptButton = ImportButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(825, 126);
        ControlBox = false;
        Controls.Add(ErrorLabel);
        Controls.Add(SwaggerUrlTextBox);
        Controls.Add(ExitButton);
        Controls.Add(ImportButton);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ImportDialog";
        ShowIcon = false;
        ShowInTaskbar = false;
        SizeGripStyle = SizeGripStyle.Hide;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Import";
        Load += ImportDialog_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ReaLTaiizor.Controls.MaterialButton ImportButton;
    private ReaLTaiizor.Controls.MaterialButton ExitButton;
    private ReaLTaiizor.Controls.MaterialTextBoxEdit SwaggerUrlTextBox;
    private ReaLTaiizor.Controls.MaterialLabel ErrorLabel;
}