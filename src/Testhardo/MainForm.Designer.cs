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
            var controlRenderer1 = new ReaLTaiizor.ControlRenderer();
            var msColorTable1 = new ReaLTaiizor.MSColorTable();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MethodsPanel = new FlowLayoutPanel();
            ImportButton = new ReaLTaiizor.Controls.MaterialButton();
            ActionFilterTextBox = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            ToolTipManager = new ReaLTaiizor.Controls.PoisonToolTip();
            FilterButton = new ReaLTaiizor.Controls.MaterialButton();
            TagFilterComboBox = new ReaLTaiizor.Controls.MaterialComboBox();
            MainPanel = new Panel();
            FirstSplitContainer = new SplitContainer();
            MethodsParentPanel = new Panel();
            MethodsTitleLabel = new ReaLTaiizor.Controls.MaterialLabel();
            SecondSplitContainer = new SplitContainer();
            StoryParentPanel = new Panel();
            StoriesComboBox = new ReaLTaiizor.Controls.MaterialComboBox();
            NewStoryButton = new ReaLTaiizor.Controls.MaterialButton();
            StoryTitlelLabel = new ReaLTaiizor.Controls.MaterialLabel();
            StoryPanel = new FlowLayoutPanel();
            OptionsParentPanel = new Panel();
            RunButton = new ReaLTaiizor.Controls.MaterialButton();
            OptionsPanel = new Panel();
            materialTabSelector1 = new ReaLTaiizor.Controls.MaterialTabSelector();
            DetailsTabControl = new ReaLTaiizor.Controls.MaterialTabControl();
            ParametersTabPage = new TabPage();
            ParametersListView = new ReaLTaiizor.Controls.MaterialListView();
            ParametersNameColumnHeader = new ColumnHeader();
            ParameterValueColumnHeader = new ColumnHeader();
            RequestsTabPage = new TabPage();
            RequestRichTextBox = new ReaLTaiizor.Controls.MaterialRichTextBox();
            ResponsesTabPage = new TabPage();
            ResponseRichTextBox = new ReaLTaiizor.Controls.MaterialRichTextBox();
            HttpCodesComboBox = new ReaLTaiizor.Controls.MaterialComboBox();
            ParallelismTextBox = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            ParallelismLabel = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            CallsCountTextBox = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            OptionsTitleLabel = new ReaLTaiizor.Controls.MaterialLabel();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            ActonButtonContextMenu = new ReaLTaiizor.Controls.FormContextMenuStrip();
            RemoveMenuItem = new ToolStripMenuItem();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FirstSplitContainer).BeginInit();
            FirstSplitContainer.Panel1.SuspendLayout();
            FirstSplitContainer.Panel2.SuspendLayout();
            FirstSplitContainer.SuspendLayout();
            MethodsParentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SecondSplitContainer).BeginInit();
            SecondSplitContainer.Panel1.SuspendLayout();
            SecondSplitContainer.Panel2.SuspendLayout();
            SecondSplitContainer.SuspendLayout();
            StoryParentPanel.SuspendLayout();
            OptionsParentPanel.SuspendLayout();
            OptionsPanel.SuspendLayout();
            DetailsTabControl.SuspendLayout();
            ParametersTabPage.SuspendLayout();
            RequestsTabPage.SuspendLayout();
            ResponsesTabPage.SuspendLayout();
            ActonButtonContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // MethodsPanel
            // 
            MethodsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MethodsPanel.AutoScroll = true;
            MethodsPanel.BorderStyle = BorderStyle.FixedSingle;
            MethodsPanel.FlowDirection = FlowDirection.TopDown;
            MethodsPanel.Location = new Point(4, 111);
            MethodsPanel.Name = "MethodsPanel";
            MethodsPanel.Size = new Size(489, 457);
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
            ImportButton.Location = new Point(4, 3);
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
            ActionFilterTextBox.Location = new Point(4, 69);
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
            ActionFilterTextBox.Size = new Size(196, 36);
            ActionFilterTextBox.TabIndex = 2;
            ActionFilterTextBox.TabStop = false;
            ActionFilterTextBox.TextAlign = HorizontalAlignment.Left;
            ActionFilterTextBox.TrailingIcon = null;
            ActionFilterTextBox.UseAccent = false;
            ActionFilterTextBox.UseSystemPasswordChar = false;
            ActionFilterTextBox.UseTallSize = false;
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
            FilterButton.Location = new Point(409, 66);
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
            TagFilterComboBox.DropDownHeight = 118;
            TagFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TagFilterComboBox.DropDownWidth = 121;
            TagFilterComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            TagFilterComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            TagFilterComboBox.FormattingEnabled = true;
            TagFilterComboBox.Hint = "Filter by tag";
            TagFilterComboBox.IntegralHeight = false;
            TagFilterComboBox.ItemHeight = 29;
            TagFilterComboBox.Location = new Point(206, 69);
            TagFilterComboBox.MaxDropDownItems = 4;
            TagFilterComboBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            TagFilterComboBox.Name = "TagFilterComboBox";
            TagFilterComboBox.Size = new Size(196, 35);
            TagFilterComboBox.Sorted = true;
            TagFilterComboBox.StartIndex = 0;
            TagFilterComboBox.TabIndex = 3;
            TagFilterComboBox.UseAccent = false;
            TagFilterComboBox.UseTallSize = false;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(FirstSplitContainer);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(3, 64);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1317, 573);
            MainPanel.TabIndex = 5;
            // 
            // FirstSplitContainer
            // 
            FirstSplitContainer.Dock = DockStyle.Fill;
            FirstSplitContainer.Location = new Point(0, 0);
            FirstSplitContainer.Name = "FirstSplitContainer";
            // 
            // FirstSplitContainer.Panel1
            // 
            FirstSplitContainer.Panel1.Controls.Add(MethodsParentPanel);
            FirstSplitContainer.Panel1MinSize = 498;
            // 
            // FirstSplitContainer.Panel2
            // 
            FirstSplitContainer.Panel2.Controls.Add(SecondSplitContainer);
            FirstSplitContainer.Size = new Size(1317, 573);
            FirstSplitContainer.SplitterDistance = 498;
            FirstSplitContainer.TabIndex = 8;
            // 
            // MethodsParentPanel
            // 
            MethodsParentPanel.BorderStyle = BorderStyle.FixedSingle;
            MethodsParentPanel.Controls.Add(ImportButton);
            MethodsParentPanel.Controls.Add(ActionFilterTextBox);
            MethodsParentPanel.Controls.Add(MethodsPanel);
            MethodsParentPanel.Controls.Add(TagFilterComboBox);
            MethodsParentPanel.Controls.Add(FilterButton);
            MethodsParentPanel.Controls.Add(MethodsTitleLabel);
            MethodsParentPanel.Dock = DockStyle.Fill;
            MethodsParentPanel.Location = new Point(0, 0);
            MethodsParentPanel.MinimumSize = new Size(489, 568);
            MethodsParentPanel.Name = "MethodsParentPanel";
            MethodsParentPanel.Size = new Size(498, 573);
            MethodsParentPanel.TabIndex = 6;
            // 
            // MethodsTitleLabel
            // 
            MethodsTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MethodsTitleLabel.Depth = 0;
            MethodsTitleLabel.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            MethodsTitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H4;
            MethodsTitleLabel.Location = new Point(4, 6);
            MethodsTitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            MethodsTitleLabel.Name = "MethodsTitleLabel";
            MethodsTitleLabel.Size = new Size(489, 39);
            MethodsTitleLabel.TabIndex = 5;
            MethodsTitleLabel.Text = "Methods";
            MethodsTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecondSplitContainer
            // 
            SecondSplitContainer.Dock = DockStyle.Fill;
            SecondSplitContainer.Location = new Point(0, 0);
            SecondSplitContainer.Name = "SecondSplitContainer";
            // 
            // SecondSplitContainer.Panel1
            // 
            SecondSplitContainer.Panel1.Controls.Add(StoryParentPanel);
            SecondSplitContainer.Panel1MinSize = 400;
            // 
            // SecondSplitContainer.Panel2
            // 
            SecondSplitContainer.Panel2.Controls.Add(OptionsParentPanel);
            SecondSplitContainer.Panel2MinSize = 400;
            SecondSplitContainer.Size = new Size(815, 573);
            SecondSplitContainer.SplitterDistance = 400;
            SecondSplitContainer.TabIndex = 7;
            // 
            // StoryParentPanel
            // 
            StoryParentPanel.Controls.Add(StoriesComboBox);
            StoryParentPanel.Controls.Add(NewStoryButton);
            StoryParentPanel.Controls.Add(StoryTitlelLabel);
            StoryParentPanel.Controls.Add(StoryPanel);
            StoryParentPanel.Dock = DockStyle.Fill;
            StoryParentPanel.Location = new Point(0, 0);
            StoryParentPanel.Name = "StoryParentPanel";
            StoryParentPanel.Size = new Size(400, 573);
            StoryParentPanel.TabIndex = 5;
            // 
            // StoriesComboBox
            // 
            StoriesComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StoriesComboBox.AutoResize = false;
            StoriesComboBox.BackColor = Color.FromArgb(255, 255, 255);
            StoriesComboBox.Depth = 0;
            StoriesComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            StoriesComboBox.DropDownHeight = 118;
            StoriesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StoriesComboBox.DropDownWidth = 121;
            StoriesComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            StoriesComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            StoriesComboBox.FormattingEnabled = true;
            StoriesComboBox.IntegralHeight = false;
            StoriesComboBox.ItemHeight = 29;
            StoriesComboBox.Location = new Point(201, 71);
            StoriesComboBox.MaxDropDownItems = 4;
            StoriesComboBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            StoriesComboBox.Name = "StoriesComboBox";
            StoriesComboBox.Size = new Size(196, 35);
            StoriesComboBox.Sorted = true;
            StoriesComboBox.StartIndex = 0;
            StoriesComboBox.TabIndex = 5;
            StoriesComboBox.UseAccent = false;
            StoriesComboBox.UseTallSize = false;
            StoriesComboBox.SelectionChangeCommitted += StoriesComboBox_SelectedIndexChanged;
            // 
            // NewStoryButton
            // 
            NewStoryButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            NewStoryButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            NewStoryButton.Depth = 0;
            NewStoryButton.HighEmphasis = true;
            NewStoryButton.Icon = null;
            NewStoryButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            NewStoryButton.Location = new Point(6, 67);
            NewStoryButton.Margin = new Padding(4, 6, 4, 6);
            NewStoryButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            NewStoryButton.Name = "NewStoryButton";
            NewStoryButton.NoAccentTextColor = Color.Empty;
            NewStoryButton.Size = new Size(64, 36);
            NewStoryButton.TabIndex = 4;
            NewStoryButton.Text = "new";
            NewStoryButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            NewStoryButton.UseAccentColor = false;
            NewStoryButton.UseVisualStyleBackColor = true;
            NewStoryButton.Click += NewStoryButton_Click;
            // 
            // StoryTitlelLabel
            // 
            StoryTitlelLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StoryTitlelLabel.Depth = 0;
            StoryTitlelLabel.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            StoryTitlelLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H4;
            StoryTitlelLabel.Location = new Point(6, 6);
            StoryTitlelLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            StoryTitlelLabel.Name = "StoryTitlelLabel";
            StoryTitlelLabel.Size = new Size(391, 39);
            StoryTitlelLabel.TabIndex = 3;
            StoryTitlelLabel.Text = "Story";
            StoryTitlelLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StoryPanel
            // 
            StoryPanel.AllowDrop = true;
            StoryPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StoryPanel.AutoScroll = true;
            StoryPanel.BackgroundImageLayout = ImageLayout.Center;
            StoryPanel.BorderStyle = BorderStyle.FixedSingle;
            StoryPanel.FlowDirection = FlowDirection.TopDown;
            StoryPanel.Location = new Point(3, 112);
            StoryPanel.Name = "StoryPanel";
            StoryPanel.Size = new Size(397, 458);
            StoryPanel.TabIndex = 0;
            StoryPanel.WrapContents = false;
            StoryPanel.DragDrop += StoryPanel_DragDrop;
            StoryPanel.DragEnter += StoryPanel_DragEnter;
            // 
            // OptionsParentPanel
            // 
            OptionsParentPanel.BorderStyle = BorderStyle.FixedSingle;
            OptionsParentPanel.Controls.Add(RunButton);
            OptionsParentPanel.Controls.Add(OptionsPanel);
            OptionsParentPanel.Controls.Add(OptionsTitleLabel);
            OptionsParentPanel.Dock = DockStyle.Fill;
            OptionsParentPanel.Location = new Point(0, 0);
            OptionsParentPanel.Name = "OptionsParentPanel";
            OptionsParentPanel.Size = new Size(411, 573);
            OptionsParentPanel.TabIndex = 4;
            // 
            // RunButton
            // 
            RunButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RunButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            RunButton.Cursor = Cursors.Hand;
            RunButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            RunButton.Depth = 0;
            RunButton.HighEmphasis = true;
            RunButton.Icon = null;
            RunButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            RunButton.Location = new Point(346, 70);
            RunButton.Margin = new Padding(4, 6, 4, 6);
            RunButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            RunButton.Name = "RunButton";
            RunButton.NoAccentTextColor = Color.Empty;
            RunButton.Size = new Size(64, 36);
            RunButton.TabIndex = 12;
            RunButton.Text = "run";
            RunButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            RunButton.UseAccentColor = false;
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // OptionsPanel
            // 
            OptionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OptionsPanel.BorderStyle = BorderStyle.FixedSingle;
            OptionsPanel.Controls.Add(materialTabSelector1);
            OptionsPanel.Controls.Add(ParallelismTextBox);
            OptionsPanel.Controls.Add(ParallelismLabel);
            OptionsPanel.Controls.Add(DetailsTabControl);
            OptionsPanel.Controls.Add(materialLabel1);
            OptionsPanel.Controls.Add(CallsCountTextBox);
            OptionsPanel.Location = new Point(3, 111);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(406, 461);
            OptionsPanel.TabIndex = 9;
            OptionsPanel.Visible = false;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialTabSelector1.BaseTabControl = DetailsTabControl;
            materialTabSelector1.CharacterCasing = ReaLTaiizor.Controls.MaterialTabSelector.CustomCharacterCasing.Upper;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.HeadAlignment = ReaLTaiizor.Controls.MaterialTabSelector.Alignment.Center;
            materialTabSelector1.Location = new Point(3, 110);
            materialTabSelector1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(397, 37);
            materialTabSelector1.TabIndex = 8;
            materialTabSelector1.Text = "ActionlTabSelector";
            // 
            // DetailsTabControl
            // 
            DetailsTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DetailsTabControl.Controls.Add(ParametersTabPage);
            DetailsTabControl.Controls.Add(RequestsTabPage);
            DetailsTabControl.Controls.Add(ResponsesTabPage);
            DetailsTabControl.Depth = 0;
            DetailsTabControl.Location = new Point(3, 153);
            DetailsTabControl.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            DetailsTabControl.Multiline = true;
            DetailsTabControl.Name = "DetailsTabControl";
            DetailsTabControl.SelectedIndex = 0;
            DetailsTabControl.Size = new Size(399, 303);
            DetailsTabControl.SizeMode = TabSizeMode.FillToRight;
            DetailsTabControl.TabIndex = 4;
            // 
            // ParametersTabPage
            // 
            ParametersTabPage.Controls.Add(ParametersListView);
            ParametersTabPage.Location = new Point(4, 24);
            ParametersTabPage.Name = "ParametersTabPage";
            ParametersTabPage.Padding = new Padding(3);
            ParametersTabPage.Size = new Size(391, 275);
            ParametersTabPage.TabIndex = 2;
            ParametersTabPage.Text = "Parameters";
            ParametersTabPage.UseVisualStyleBackColor = true;
            // 
            // ParametersListView
            // 
            ParametersListView.AutoSizeTable = false;
            ParametersListView.BackColor = Color.FromArgb(255, 255, 255);
            ParametersListView.BorderStyle = BorderStyle.None;
            ParametersListView.Columns.AddRange(new ColumnHeader[] { ParametersNameColumnHeader, ParameterValueColumnHeader });
            ParametersListView.Depth = 0;
            ParametersListView.Dock = DockStyle.Fill;
            ParametersListView.FullRowSelect = true;
            ParametersListView.Location = new Point(3, 3);
            ParametersListView.MinimumSize = new Size(200, 100);
            ParametersListView.MouseLocation = new Point(-1, -1);
            ParametersListView.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            ParametersListView.Name = "ParametersListView";
            ParametersListView.OwnerDraw = true;
            ParametersListView.Size = new Size(385, 269);
            ParametersListView.TabIndex = 0;
            ParametersListView.UseCompatibleStateImageBehavior = false;
            ParametersListView.View = View.Details;
            // 
            // ParametersNameColumnHeader
            // 
            ParametersNameColumnHeader.Text = "";
            // 
            // ParameterValueColumnHeader
            // 
            ParameterValueColumnHeader.Text = "";
            // 
            // RequestsTabPage
            // 
            RequestsTabPage.AutoScroll = true;
            RequestsTabPage.Controls.Add(RequestRichTextBox);
            RequestsTabPage.Location = new Point(4, 24);
            RequestsTabPage.Name = "RequestsTabPage";
            RequestsTabPage.Padding = new Padding(3);
            RequestsTabPage.Size = new Size(391, 275);
            RequestsTabPage.TabIndex = 0;
            RequestsTabPage.Text = "Request";
            RequestsTabPage.UseVisualStyleBackColor = true;
            // 
            // RequestRichTextBox
            // 
            RequestRichTextBox.BackColor = Color.FromArgb(255, 255, 255);
            RequestRichTextBox.BorderStyle = BorderStyle.None;
            RequestRichTextBox.Depth = 0;
            RequestRichTextBox.Dock = DockStyle.Fill;
            RequestRichTextBox.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            RequestRichTextBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            RequestRichTextBox.Hint = "";
            RequestRichTextBox.Location = new Point(3, 3);
            RequestRichTextBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            RequestRichTextBox.Name = "RequestRichTextBox";
            RequestRichTextBox.Size = new Size(385, 269);
            RequestRichTextBox.TabIndex = 0;
            RequestRichTextBox.Text = "";
            // 
            // ResponsesTabPage
            // 
            ResponsesTabPage.Controls.Add(ResponseRichTextBox);
            ResponsesTabPage.Controls.Add(HttpCodesComboBox);
            ResponsesTabPage.Location = new Point(4, 24);
            ResponsesTabPage.Name = "ResponsesTabPage";
            ResponsesTabPage.Padding = new Padding(3);
            ResponsesTabPage.Size = new Size(391, 275);
            ResponsesTabPage.TabIndex = 1;
            ResponsesTabPage.Text = "Responses";
            ResponsesTabPage.UseVisualStyleBackColor = true;
            // 
            // ResponseRichTextBox
            // 
            ResponseRichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResponseRichTextBox.BackColor = Color.FromArgb(255, 255, 255);
            ResponseRichTextBox.BorderStyle = BorderStyle.None;
            ResponseRichTextBox.Depth = 0;
            ResponseRichTextBox.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            ResponseRichTextBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            ResponseRichTextBox.Hint = "";
            ResponseRichTextBox.Location = new Point(3, 47);
            ResponseRichTextBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ResponseRichTextBox.Name = "ResponseRichTextBox";
            ResponseRichTextBox.Size = new Size(387, 289);
            ResponseRichTextBox.TabIndex = 5;
            ResponseRichTextBox.Text = "";
            // 
            // HttpCodesComboBox
            // 
            HttpCodesComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            HttpCodesComboBox.AutoResize = false;
            HttpCodesComboBox.BackColor = Color.FromArgb(255, 255, 255);
            HttpCodesComboBox.Depth = 0;
            HttpCodesComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            HttpCodesComboBox.DropDownHeight = 118;
            HttpCodesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            HttpCodesComboBox.DropDownWidth = 121;
            HttpCodesComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            HttpCodesComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            HttpCodesComboBox.FormattingEnabled = true;
            HttpCodesComboBox.IntegralHeight = false;
            HttpCodesComboBox.ItemHeight = 29;
            HttpCodesComboBox.Location = new Point(7, 6);
            HttpCodesComboBox.MaxDropDownItems = 4;
            HttpCodesComboBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            HttpCodesComboBox.Name = "HttpCodesComboBox";
            HttpCodesComboBox.Size = new Size(380, 35);
            HttpCodesComboBox.Sorted = true;
            HttpCodesComboBox.StartIndex = 0;
            HttpCodesComboBox.TabIndex = 4;
            HttpCodesComboBox.UseAccent = false;
            HttpCodesComboBox.UseTallSize = false;
            // 
            // ParallelismTextBox
            // 
            ParallelismTextBox.AnimateReadOnly = false;
            ParallelismTextBox.AutoCompleteMode = AutoCompleteMode.None;
            ParallelismTextBox.AutoCompleteSource = AutoCompleteSource.None;
            ParallelismTextBox.BackgroundImageLayout = ImageLayout.None;
            ParallelismTextBox.CharacterCasing = CharacterCasing.Normal;
            ParallelismTextBox.Depth = 0;
            ParallelismTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ParallelismTextBox.HelperText = "calls count";
            ParallelismTextBox.HideSelection = true;
            ParallelismTextBox.LeadingIcon = null;
            ParallelismTextBox.Location = new Point(271, 56);
            ParallelismTextBox.MaxLength = 32767;
            ParallelismTextBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            ParallelismTextBox.Name = "ParallelismTextBox";
            ParallelismTextBox.PasswordChar = '\0';
            ParallelismTextBox.PrefixSuffixText = null;
            ParallelismTextBox.ReadOnly = false;
            ParallelismTextBox.RightToLeft = RightToLeft.No;
            ParallelismTextBox.SelectedText = "";
            ParallelismTextBox.SelectionLength = 0;
            ParallelismTextBox.SelectionStart = 0;
            ParallelismTextBox.ShortcutsEnabled = true;
            ParallelismTextBox.Size = new Size(76, 36);
            ParallelismTextBox.TabIndex = 6;
            ParallelismTextBox.TabStop = false;
            ParallelismTextBox.Text = "10";
            ParallelismTextBox.TextAlign = HorizontalAlignment.Right;
            ParallelismTextBox.TrailingIcon = null;
            ParallelismTextBox.UseSystemPasswordChar = false;
            ParallelismTextBox.UseTallSize = false;
            ParallelismTextBox.TextChanged += Parallelism_TextChanged;
            // 
            // ParallelismLabel
            // 
            ParallelismLabel.AutoSize = true;
            ParallelismLabel.Depth = 0;
            ParallelismLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            ParallelismLabel.Location = new Point(185, 73);
            ParallelismLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ParallelismLabel.Name = "ParallelismLabel";
            ParallelismLabel.Size = new Size(80, 19);
            ParallelismLabel.TabIndex = 5;
            ParallelismLabel.Text = "Parallelism";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(14, 73);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(43, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Count";
            // 
            // CallsCountTextBox
            // 
            CallsCountTextBox.AnimateReadOnly = false;
            CallsCountTextBox.AutoCompleteMode = AutoCompleteMode.None;
            CallsCountTextBox.AutoCompleteSource = AutoCompleteSource.None;
            CallsCountTextBox.BackgroundImageLayout = ImageLayout.None;
            CallsCountTextBox.CharacterCasing = CharacterCasing.Normal;
            CallsCountTextBox.Depth = 0;
            CallsCountTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            CallsCountTextBox.HelperText = "calls count";
            CallsCountTextBox.HideSelection = true;
            CallsCountTextBox.LeadingIcon = null;
            CallsCountTextBox.Location = new Point(63, 56);
            CallsCountTextBox.MaxLength = 32767;
            CallsCountTextBox.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            CallsCountTextBox.Name = "CallsCountTextBox";
            CallsCountTextBox.PasswordChar = '\0';
            CallsCountTextBox.PrefixSuffixText = null;
            CallsCountTextBox.ReadOnly = false;
            CallsCountTextBox.RightToLeft = RightToLeft.No;
            CallsCountTextBox.SelectedText = "";
            CallsCountTextBox.SelectionLength = 0;
            CallsCountTextBox.SelectionStart = 0;
            CallsCountTextBox.ShortcutsEnabled = true;
            CallsCountTextBox.Size = new Size(76, 36);
            CallsCountTextBox.TabIndex = 0;
            CallsCountTextBox.TabStop = false;
            CallsCountTextBox.Text = "1";
            CallsCountTextBox.TextAlign = HorizontalAlignment.Right;
            CallsCountTextBox.TrailingIcon = null;
            CallsCountTextBox.UseSystemPasswordChar = false;
            CallsCountTextBox.UseTallSize = false;
            CallsCountTextBox.TextChanged += CallsCountTextBox_TextChanged;
            // 
            // OptionsTitleLabel
            // 
            OptionsTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            OptionsTitleLabel.Depth = 0;
            OptionsTitleLabel.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            OptionsTitleLabel.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H4;
            OptionsTitleLabel.Location = new Point(2, 6);
            OptionsTitleLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            OptionsTitleLabel.Name = "OptionsTitleLabel";
            OptionsTitleLabel.Size = new Size(405, 39);
            OptionsTitleLabel.TabIndex = 8;
            OptionsTitleLabel.Text = "Options";
            OptionsTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(0, 0);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(200, 100);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "tabPage3";
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(0, 0);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(200, 100);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "tabPage4";
            // 
            // ActonButtonContextMenu
            // 
            ActonButtonContextMenu.Items.AddRange(new ToolStripItem[] { RemoveMenuItem });
            ActonButtonContextMenu.Name = "ActonButtonContextMenu";
            controlRenderer1.ColorTable = msColorTable1;
            controlRenderer1.RoundedEdges = true;
            ActonButtonContextMenu.Renderer = controlRenderer1;
            ActonButtonContextMenu.Size = new Size(114, 26);
            // 
            // RemoveMenuItem
            // 
            RemoveMenuItem.Font = new Font("Roboto Condensed Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RemoveMenuItem.ForeColor = Color.FromArgb(80, 80, 80);
            RemoveMenuItem.Image = (Image)resources.GetObject("RemoveMenuItem.Image");
            RemoveMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            RemoveMenuItem.Name = "RemoveMenuItem";
            RemoveMenuItem.Size = new Size(113, 22);
            RemoveMenuItem.Text = "&Remove";
            RemoveMenuItem.Click += RemoveMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 640);
            Controls.Add(MainPanel);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1323, 640);
            Name = "MainForm";
            Text = "Testhardo!";
            TransparencyKey = Color.Fuchsia;
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            MainPanel.ResumeLayout(false);
            FirstSplitContainer.Panel1.ResumeLayout(false);
            FirstSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FirstSplitContainer).EndInit();
            FirstSplitContainer.ResumeLayout(false);
            MethodsParentPanel.ResumeLayout(false);
            MethodsParentPanel.PerformLayout();
            SecondSplitContainer.Panel1.ResumeLayout(false);
            SecondSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SecondSplitContainer).EndInit();
            SecondSplitContainer.ResumeLayout(false);
            StoryParentPanel.ResumeLayout(false);
            StoryParentPanel.PerformLayout();
            OptionsParentPanel.ResumeLayout(false);
            OptionsParentPanel.PerformLayout();
            OptionsPanel.ResumeLayout(false);
            OptionsPanel.PerformLayout();
            DetailsTabControl.ResumeLayout(false);
            ParametersTabPage.ResumeLayout(false);
            RequestsTabPage.ResumeLayout(false);
            ResponsesTabPage.ResumeLayout(false);
            ActonButtonContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel MethodsPanel;
        private ReaLTaiizor.Controls.MaterialButton ImportButton;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit ActionFilterTextBox;
        private ReaLTaiizor.Controls.PoisonToolTip ToolTipManager;
        private ReaLTaiizor.Controls.MaterialButton FilterButton;
        private ReaLTaiizor.Controls.MaterialComboBox TagFilterComboBox;
        private Panel MainPanel;
        private Panel OptionsParentPanel;
        private Panel StoryParentPanel;
        private FlowLayoutPanel StoryPanel;
        private Panel MethodsParentPanel;
        private ReaLTaiizor.Controls.MaterialLabel StoryTitlelLabel;
        private ReaLTaiizor.Controls.MaterialLabel OptionsTitleLabel;
        private ReaLTaiizor.Controls.MaterialLabel MethodsTitleLabel;
        private SplitContainer SecondSplitContainer;
        private SplitContainer FirstSplitContainer;
        private Panel OptionsPanel;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit CallsCountTextBox;
        private ReaLTaiizor.Controls.MaterialRadioButton ParallelRadioButton;
        private ReaLTaiizor.Controls.MaterialRadioButton SequentialRadioButton;
        private ReaLTaiizor.Controls.MaterialTabControl DetailsTabControl;
        private TabPage RequestsTabPage;
        private TabPage ResponsesTabPage;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit ParallelismTextBox;
        private ReaLTaiizor.Controls.MaterialLabel ParallelismLabel;
        private ReaLTaiizor.Controls.MaterialRichTextBox RequestRichTextBox;
        private TabPage ParametersTabPage;
        private ReaLTaiizor.Controls.MaterialComboBox HttpCodesComboBox;
        private ReaLTaiizor.Controls.MaterialRichTextBox ResponseRichTextBox;
        private ReaLTaiizor.Controls.MaterialListView ParametersListView;
        private ColumnHeader ParametersNameColumnHeader;
        private ColumnHeader ParameterValueColumnHeader;
        private ReaLTaiizor.Controls.MaterialButton NewStoryButton;
        private ReaLTaiizor.Controls.MaterialComboBox StoriesComboBox;
        private ReaLTaiizor.Controls.MaterialTabSelector materialTabSelector1;
        private ReaLTaiizor.Controls.MaterialButton RunButton;
        private ReaLTaiizor.Controls.FormContextMenuStrip ActonButtonContextMenu;
        private ToolStripMenuItem RemoveMenuItem;
    }
}
