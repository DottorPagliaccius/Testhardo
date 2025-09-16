using ReaLTaiizor.Colors;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using Testhardo.Services;
using static Testhardo.OpenApiDocument;

namespace Testhardo;

public partial class MainForm : MaterialForm
{
    private Cursor? _bitmapCursor;

    private readonly MaterialSkinManager _materialSkinManager;
    private readonly IStoryManager _storyManager;
    private readonly IApiService _apiService;

    private Story? _currentStory;
    private StoryAction? _currentStoryAction;

    public MainForm(IStoryManager storyManager, IApiService apiService)
    {
        InitializeComponent();

        _materialSkinManager = MaterialSkinManager.Instance;
        _materialSkinManager.EnforceBackcolorOnAllComponents = true;
        _materialSkinManager.AddFormToManage(this);
        _materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        _materialSkinManager.ColorScheme = new MaterialColorScheme(MaterialPrimary.Green600, MaterialPrimary.Green700, MaterialPrimary.Green200, MaterialAccent.Red100, MaterialTextShade.LIGHT);

        _storyManager = storyManager;
        _apiService = apiService;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        LoadStories();
    }

    class StoryItem
    {
        public required Guid Id { get; set; }
        public required string Description { get; set; }

        public override string ToString() => Description;
    }

    private void LoadStories()
    {
        var stories = _storyManager.GetStories();

        if (stories.Count == 0)
            return;

        var wasEmpty = StoriesComboBox.Items.Count == 0;

        var list = stories.Select(x => new StoryItem { Id = x.Key, Description = x.Value }).ToList();

        StoriesComboBox.DisplayMember = nameof(StoryItem.Description);
        StoriesComboBox.ValueMember = nameof(StoryItem.Id);
        StoriesComboBox.DataSource = list;

        if (wasEmpty)
        {
            StoriesComboBox.SelectedIndex = 0;

            StoriesComboBox_SelectedIndexChanged(this, EventArgs.Empty);
        }
    }

    private void StoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (StoriesComboBox.SelectedValue == null)
            return;

        _currentStory = _storyManager.GetStory((Guid)StoriesComboBox.SelectedValue);

        LoadStory();
    }

    private void LoadStory()
    {
        if (_currentStory == null)
            return;

        StoryPanel.Controls.Clear();

        foreach (var storyAction in _currentStory.Actions.Values)
        {
            AddThenSeparator();

            var actionButton = new ActionButton(storyAction.RelativeUrl, storyAction.Verb, storyAction.BaseUrl, storyAction.Id) { Margin = new Padding(7) };

            actionButton.Click += ActionButton_Click;

            StoryPanel.Controls.Add(actionButton);
        }
    }

    private void ImportButton_Click(object sender, EventArgs e)
    {
        using var importDialog = new ImportDialog();

        _materialSkinManager.AddFormToManage(importDialog);

        var result = importDialog.ShowDialog();

        if (result == DialogResult.OK && importDialog.OpenApiDocument != null && importDialog.BaseUrl != null)
        {
            try
            {
                Enabled = false;
                Cursor = Cursors.WaitCursor;
                MethodsPanel.SuspendLayout();

                var baseUrl = importDialog.BaseUrl;

                foreach (var path in importDialog.OpenApiDocument.Paths)
                {
                    var actionName = path.Key;
                    var verbs = path.Value;

                    if (verbs.Get != null)
                    {
                        AddMethod(baseUrl, actionName, verbs.Get, HttpVerbs.Get);
                    }

                    if (verbs.Post != null)
                    {
                        AddMethod(baseUrl, actionName, verbs.Post, HttpVerbs.Post);
                    }

                    if (verbs.Put != null)
                    {
                        AddMethod(baseUrl, actionName, verbs.Put, HttpVerbs.Put);
                    }

                    if (verbs.Delete != null)
                    {
                        AddMethod(baseUrl, actionName, verbs.Delete, HttpVerbs.Delete);
                    }
                }

                TagFilterComboBox.Items.Clear();
                TagFilterComboBox.Items.AddRange([.. importDialog.OpenApiDocument.Tags]);
            }
            finally
            {
                MethodsPanel.ResumeLayout();
                Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }

    private void AddMethod(string baseUrl, string actionName, OpenApiDocument.Operation operation, string httpVerb)
    {
        var button = new ActionButton(actionName, httpVerb, baseUrl)
        {
            Operation = operation,
            Cursor = Cursors.SizeAll
        };

        button.MouseDown += ActionButton_MouseDown;
        button.GiveFeedback += ActionButton_GiveFeedback;

        MethodsPanel.Controls.Add(button);
    }

    private void Filter(string? actionName, string? tag)
    {
        if (string.IsNullOrEmpty(actionName) && string.IsNullOrEmpty(tag))
        {
            foreach (var control in MethodsPanel.Controls.OfType<MaterialButton>())
            {
                control.Visible = true;
            }
        }
        else
        {
            foreach (var control in MethodsPanel.Controls.OfType<ActionButton>())
            {
                var actionNameFound = string.IsNullOrEmpty(actionName) || control.Text.Contains(actionName, StringComparison.OrdinalIgnoreCase);

                var tagFound = string.IsNullOrEmpty(tag) || control.Operation?.Tags.Any(x => x.Contains(tag, StringComparison.OrdinalIgnoreCase)) == true;

                control.Visible = actionNameFound && tagFound;
            }
        }
    }

    private void FilterButton_Click(object sender, EventArgs e)
    {
        Enabled = false;
        Cursor = Cursors.WaitCursor;

        try
        {
            Filter(ActionFilterTextBox.Text, TagFilterComboBox.Text);
        }
        finally
        {
            Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private void ActionButton_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left || sender is not ActionButton dragSourceButton)
            return;

        var bitmap = new Bitmap(dragSourceButton.Width, dragSourceButton.Height);

        dragSourceButton.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));

        _bitmapCursor = new Cursor(bitmap.GetHicon());

        dragSourceButton.DoDragDrop(dragSourceButton, DragDropEffects.Copy);
    }

    private void ActionButton_GiveFeedback(object? sender, GiveFeedbackEventArgs e)
    {
        e.UseDefaultCursors = false;

        if (_bitmapCursor != null)
            Cursor.Current = _bitmapCursor;
    }

    private void StoryPanel_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data?.GetDataPresent(typeof(ActionButton)) == true)
            e.Effect = DragDropEffects.Copy;
    }

    private void StoryPanel_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            if (e.Data?.GetDataPresent(typeof(ActionButton)) == true)
            {
                if (e.Data.GetData(typeof(ActionButton)) is not ActionButton original || original.Operation == null)
                    return;

                AddNewMethodToStory(original.MethodName, original.Verb, original.BaseUrl, original.Operation);
            }
        }
        finally
        {
            _bitmapCursor?.Dispose();
            _bitmapCursor = null;
        }
    }

    private void AddNewMethodToStory(string name, string verb, string baseUrl, Operation operation)
    {
        if (_currentStory == null)
        {
            _currentStory = new Story
            {
                Id = Guid.NewGuid(),
                Description = _storyManager.GetUniqueName()
            };

            _storyManager.SaveStory(_currentStory);

            LoadStories();
        }

        AddThenSeparator();

        var actionButton = new ActionButton(name, verb, baseUrl) { Margin = new Padding(7) };

        actionButton.Click += ActionButton_Click;

        StoryPanel.Controls.Add(actionButton);

        CreateStoryAction(actionButton.Id, name, verb, baseUrl, operation);

        _storyManager.SaveStory(_currentStory);
    }

    private void CreateStoryAction(Guid id, string name, string verb, string baseUrl, Operation operation)
    {
        if (_currentStory == null)
            return;

        var storyAction = new StoryAction
        {
            Id = id,
            Verb = verb,
            BaseUrl = baseUrl,
            RelativeUrl = name
        };

        foreach (var response in operation.Responses)
        {
            storyAction.Responses.Add(int.Parse(response.Key), response.Value.Description); //TODO
        }

        foreach (var parameter in operation.Parameters)
        {
            //storyAction.Parameters.Add(new StoryActionParameter(parameter.Name, parameter.Type)); //TODO
        }

        _currentStory.Actions.Add(_currentStory.Actions.Count, storyAction);

        _storyManager.SaveStory(_currentStory);
    }

    private void AddThenSeparator()
    {
        if (StoryPanel.Controls.Count > 0)
        {
            var thenLabel = new Label
            {
                Text = "THEN",
                ForeColor = Color.White,
                BackColor = Color.Red,
                AutoSize = true,
                Font = new Font("Roboto Condensed Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(7)
            };

            StoryPanel.Controls.Add(thenLabel);
        }
    }

    private void ActionButton_Click(object? sender, EventArgs e)
    {
        if (sender is not ActionButton actionButton)
            return;

        foreach (var control in StoryPanel.Controls.OfType<ActionButton>())
        {
            control.SetUnselected();
        }

        actionButton.SetSelected();

        _currentStoryAction = _currentStory?.GetAction(actionButton.Id);

        LoadOptions();
    }

    private void LoadOptions()
    {
        if (_currentStory == null || _currentStoryAction == null)
            return;

        RunButton.Visible = true;

        LoadOptions(_currentStoryAction.Options);
        LoadParameters(_currentStoryAction.Parameters);
        LoadRequestBody(_currentStoryAction.RequestBody);
        LoadResponses(_currentStoryAction.Responses);

        if (!OptionsPanel.Visible)
            OptionsPanel.Visible = true;
    }

    private void LoadOptions(StoryActionOptions options)
    {
        if (options.ExecutionMode == StoryActionOptions.Mode.Sequential)
        {
            SequentialRadioButton.Checked = true;
        }
        else
        {
            ParallelRadioButton.Checked = true;
        }

        //EnabledCheckBox.Checked = options.Enabled;
        CallsCountTextBox.Text = options.Count.ToString();
        TimeoutTextBox.Text = options.TimeoutInSeconds.ToString();
    }

    private void LoadParameters(List<StoryActionParameter> parameters)
    {
        ParametersListView.Items.Clear();

        foreach (var parameter in parameters)
        {
            var item = new ListViewItem(parameter.Name)
            {
                Tag = parameter
            };

            var value = parameter.Type switch
            {
                Type stringType when stringType == typeof(string) => stringType.ToString(),
                Type intType when intType == typeof(int) => int.TryParse(parameter.Value, out var parsedValue) ? parsedValue : int.Parse(parameter.Value),
                Type boolType when boolType == typeof(bool) => (object)(parameter.Value == bool.TrueString),
                _ => null,
            };

            item.SubItems.Add(value?.ToString() ?? string.Empty);

            ParametersListView.Items.Add(item);
        }
    }

    private void LoadRequestBody(string? requestBody)
    {
        if (string.IsNullOrEmpty(requestBody))
            return;

        RequestRichTextBox.Text = requestBody;
        RequestRichTextBox.Enabled = true;
    }

    private void LoadResponses(Dictionary<int, string> responses)
    {
        if (responses.Count == 0)
            return;

        HttpCodesComboBox.DataSource = responses.Keys.ToList();
        HttpCodesComboBox.SelectedIndex = 0;
        HttpCodesComboBox.Tag = responses;
    }

    private void HttpCodesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (HttpCodesComboBox.SelectedIndex == -1 ||
            HttpCodesComboBox.Tag is not Dictionary<int, string> ||
            HttpCodesComboBox.SelectedValue is not int code)
        {
            return;
        }

        var responses = (Dictionary<int, string>)HttpCodesComboBox.Tag!;

        if (responses.TryGetValue(code, out var response))
            ResponseRichTextBox.Text = response;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Control | Keys.I))
        {
            ImportButton_Click(this, EventArgs.Empty);

            return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void NewStoryButton_Click(object sender, EventArgs e)
    {
        var uniqueName = _storyManager.GetUniqueName();

        using var newStoryDialog = new NewStoryDialog(uniqueName);

        _materialSkinManager.AddFormToManage(newStoryDialog);

        var dialogResult = newStoryDialog.ShowDialog();

        if (dialogResult != DialogResult.OK)
            return;

        _currentStory = new Story
        {
            Id = Guid.NewGuid(),
            Description = uniqueName
        };

        _storyManager.SaveStory(_currentStory);

        StoryPanel.Controls.Clear();

        LoadStories();
    }

    private void ParallelRadioButton_MouseClick(object sender, MouseEventArgs e)
    {
        if (_currentStory == null || _currentStoryAction == null)
            return;

        _currentStoryAction.Options.ExecutionMode = ParallelRadioButton.Checked ? StoryActionOptions.Mode.Parallel : StoryActionOptions.Mode.Sequential;

        _storyManager.SaveStory(_currentStory);
    }

    private void SequentialRadioButton_MouseClick(object sender, MouseEventArgs e)
    {
        if (_currentStory == null || _currentStoryAction == null)
            return;

        _currentStoryAction.Options.ExecutionMode = ParallelRadioButton.Checked ? StoryActionOptions.Mode.Parallel : StoryActionOptions.Mode.Sequential;

        _storyManager.SaveStory(_currentStory);
    }

    private void CallsCountTextBox_TextChanged(object sender, EventArgs e)
    {
        if (_currentStory == null || _currentStoryAction == null || !int.TryParse(CallsCountTextBox.Text, out var value) || value <= 0)
            return;

        _currentStoryAction.Options.Count = value;

        _storyManager.SaveStory(_currentStory);
    }

    private void TimeoutTextBox_TextChanged(object sender, EventArgs e)
    {
        if (_currentStory == null || _currentStoryAction == null || !int.TryParse(TimeoutTextBox.Text, out var value) || value <= 0)
            return;

        _currentStoryAction.Options.TimeoutInSeconds = value;

        _storyManager.SaveStory(_currentStory);
    }

    private void RunButton_Click(object sender, EventArgs e)
    {
        //TODO
    }
}

public static class HttpVerbs
{
    public const string Get = "GET";
    public const string Post = "POST";
    public const string Put = "PUT";
    public const string Delete = "DELETE";
}

public class Method
{
    public required string BaseUrl { get; set; }
    public required string Name { get; set; }
    public required string Verb { get; set; }
    public required Operation Operation { get; set; }
}

public class Action
{
    public required string BaseUrl { get; set; }
    public required string Name { get; set; }
    public required string Verb { get; set; }
}