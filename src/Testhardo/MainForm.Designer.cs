namespace Testhardo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MethodsPanel = new FlowLayoutPanel();
            ImportButton = new ReaLTaiizor.Controls.MaterialButton();
            ActionFilterTextBox = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            ToolTipManager = new ReaLTaiizor.Controls.PoisonToolTip();
            FilterButton = new ReaLTaiizor.Controls.MaterialButton();
            TagFilterComboBox = new ReaLTaiizor.Controls.MaterialComboBox();
            MainPanel = new Panel();
            LeftSplitter = new Splitter();
            PlanPanel = new Panel();
            StoryPanel = new FlowLayoutPanel();
            RunPanel = new Panel();
            RightSplitter = new Splitter();
            MainPanel.SuspendLayout();
            PlanPanel.SuspendLayout();
            RunPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MethodsPanel
            // 
            MethodsPanel.AutoScroll = true;
            MethodsPanel.Dock = DockStyle.Left;
            MethodsPanel.FlowDirection = FlowDirection.TopDown;
            MethodsPanel.Location = new Point(0, 0);
            MethodsPanel.Name = "MethodsPanel";
            MethodsPanel.Size = new Size(567, 444);
            MethodsPanel.TabIndex = 3;
            MethodsPanel.WrapContents = false;
            // 
            // ImportButton
            // 
            ImportButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ImportButton.Cursor = Cursors.Hand;
            ImportButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            ImportButton.Depth = 0;
            ImportButton.HighEmphasis = true;
            ImportButton.Icon = null;
            ImportButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            ImportButton.Location = new Point(7, 92);
            ImportButton.Margin = new Padding(4, 6, 4, 6);
            ImportButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ImportButton.Name = "ImportButton";
            ImportButton.NoAccentTextColor = Color.Empty;
            ImportButton.Size = new Size(76, 36);
            ImportButton.TabIndex = 1;
            ImportButton.Text = "Import";
            ImportButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            ImportButton.UseAccentColor = false;
            ImportButton.UseVisualStyleBackColor = true;
            ImportButton.Click += ImportButton_Click;
            // 
            // ActionFilterTextBox
            // 
            ActionFilterTextBox.AnimateReadOnly = false;
            ActionFilterTextBox.AutoCompleteMode = AutoCompleteMode.None;
            ActionFilterTextBox.AutoCompleteSource = AutoCompleteSource.None;
            ActionFilterTextBox.BackgroundImageLayout = ImageLayout.None;
            ActionFilterTextBox.CharacterCasing = CharacterCasing.Normal;
            ActionFilterTextBox.Depth = 0;
            ActionFilterTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ActionFilterTextBox.HideSelection = true;
            ActionFilterTextBox.Hint = "Filter by name";
            ActionFilterTextBox.LeadingIcon = null;
            ActionFilterTextBox.Location = new Point(7, 137);
            ActionFilterTextBox.MaxLength = 32767;
            ActionFilterTextBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            ActionFilterTextBox.Name = "ActionFilterTextBox";
            ActionFilterTextBox.PasswordChar = '\0';
            ActionFilterTextBox.PrefixSuffixText = null;
            ActionFilterTextBox.ReadOnly = false;
            ActionFilterTextBox.RightToLeft = RightToLeft.No;
            ActionFilterTextBox.SelectedText = "";
            ActionFilterTextBox.SelectionLength = 0;
            ActionFilterTextBox.SelectionStart = 0;
            ActionFilterTextBox.ShortcutsEnabled = true;
            ActionFilterTextBox.Size = new Size(265, 48);
            ActionFilterTextBox.TabIndex = 2;
            ActionFilterTextBox.TabStop = false;
            ActionFilterTextBox.TextAlign = HorizontalAlignment.Left;
            ActionFilterTextBox.TrailingIcon = null;
            ActionFilterTextBox.UseAccent = false;
            ActionFilterTextBox.UseSystemPasswordChar = false;
            // 
            // ToolTipManager
            // 
            ToolTipManager.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Green;
            ToolTipManager.StyleManager = null;
            ToolTipManager.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            // 
            // FilterButton
            // 
            FilterButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FilterButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            FilterButton.Depth = 0;
            FilterButton.HighEmphasis = true;
            FilterButton.Icon = null;
            FilterButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            FilterButton.Location = new Point(554, 148);
            FilterButton.Margin = new Padding(4, 6, 4, 6);
            FilterButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            FilterButton.Name = "FilterButton";
            FilterButton.NoAccentTextColor = Color.Empty;
            FilterButton.Size = new Size(68, 36);
            FilterButton.TabIndex = 4;
            FilterButton.Text = "Filter";
            FilterButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            FilterButton.UseAccentColor = false;
            FilterButton.UseVisualStyleBackColor = true;
            FilterButton.Click += FilterButton_Click;
            // 
            // TagFilterComboBox
            // 
            TagFilterComboBox.AutoResize = false;
            TagFilterComboBox.BackColor = Color.FromArgb(255, 255, 255);
            TagFilterComboBox.Depth = 0;
            TagFilterComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            TagFilterComboBox.DropDownHeight = 174;
            TagFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TagFilterComboBox.DropDownWidth = 121;
            TagFilterComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            TagFilterComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            TagFilterComboBox.FormattingEnabled = true;
            TagFilterComboBox.Hint = "Filter by tag";
            TagFilterComboBox.IntegralHeight = false;
            TagFilterComboBox.ItemHeight = 43;
            TagFilterComboBox.Location = new Point(278, 135);
            TagFilterComboBox.MaxDropDownItems = 4;
            TagFilterComboBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            TagFilterComboBox.Name = "TagFilterComboBox";
            TagFilterComboBox.Size = new Size(269, 49);
            TagFilterComboBox.Sorted = true;
            TagFilterComboBox.StartIndex = 0;
            TagFilterComboBox.TabIndex = 3;
            TagFilterComboBox.UseAccent = false;
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainPanel.Controls.Add(LeftSplitter);
            MainPanel.Controls.Add(PlanPanel);
            MainPanel.Controls.Add(RunPanel);
            MainPanel.Controls.Add(MethodsPanel);
            MainPanel.Location = new Point(7, 191);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1310, 444);
            MainPanel.TabIndex = 5;
            // 
            // LeftSplitter
            // 
            LeftSplitter.Location = new Point(567, 0);
            LeftSplitter.Name = "LeftSplitter";
            LeftSplitter.Size = new Size(10, 444);
            LeftSplitter.TabIndex = 6;
            LeftSplitter.TabStop = false;
            // 
            // PlanPanel
            // 
            PlanPanel.Controls.Add(StoryPanel);
            PlanPanel.Dock = DockStyle.Fill;
            PlanPanel.Location = new Point(567, 0);
            PlanPanel.Name = "PlanPanel";
            PlanPanel.Size = new Size(381, 444);
            PlanPanel.TabIndex = 5;
            // 
            // StoryPanel
            // 
            StoryPanel.AllowDrop = true;
            StoryPanel.AutoScroll = true;
            StoryPanel.BackgroundImageLayout = ImageLayout.Center;
            StoryPanel.Dock = DockStyle.Fill;
            StoryPanel.FlowDirection = FlowDirection.TopDown;
            StoryPanel.Location = new Point(0, 0);
            StoryPanel.Name = "StoryPanel";
            StoryPanel.Size = new Size(381, 444);
            StoryPanel.TabIndex = 0;
            StoryPanel.WrapContents = false;
            StoryPanel.DragDrop += StoryPanel_DragDrop;
            StoryPanel.DragEnter += StoryPanel_DragEnter;
            // 
            // RunPanel
            // 
            RunPanel.Controls.Add(RightSplitter);
            RunPanel.Dock = DockStyle.Right;
            RunPanel.Location = new Point(948, 0);
            RunPanel.Name = "RunPanel";
            RunPanel.Size = new Size(362, 444);
            RunPanel.TabIndex = 4;
            // 
            // RightSplitter
            // 
            RightSplitter.Location = new Point(0, 0);
            RightSplitter.Name = "RightSplitter";
            RightSplitter.Size = new Size(10, 444);
            RightSplitter.TabIndex = 7;
            RightSplitter.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 640);
            Controls.Add(MainPanel);
            Controls.Add(TagFilterComboBox);
            Controls.Add(FilterButton);
            Controls.Add(ActionFilterTextBox);
            Controls.Add(ImportButton);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Testhardo!";
            TransparencyKey = Color.Fuchsia;
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            MainPanel.ResumeLayout(false);
            PlanPanel.ResumeLayout(false);
            RunPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel MethodsPanel;
        private ReaLTaiizor.Controls.MaterialButton ImportButton;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit ActionFilterTextBox;
        private ReaLTaiizor.Controls.PoisonToolTip ToolTipManager;
        private ReaLTaiizor.Controls.MaterialButton FilterButton;
        private ReaLTaiizor.Controls.MaterialComboBox TagFilterComboBox;
        private Panel MainPanel;
        private Panel RunPanel;
        private Panel PlanPanel;
        private Splitter LeftSplitter;
        private Splitter RightSplitter;
        private FlowLayoutPanel StoryPanel;
    }
}
