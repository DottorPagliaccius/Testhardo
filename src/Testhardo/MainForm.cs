using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Colors;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;

namespace Testhardo;

public partial class MainForm : MaterialForm
{
    private Cursor? _bitmapCursor;

    private readonly MaterialSkinManager _materialSkinManager;
    private readonly IStoryManager _storyManager;
    private readonly IServiceProvider _serviceProvider;
    private Story? _currentStory;
    private StoryAction? _currentStoryAction;

    //private ActionButton? _lastActionButtonContextMenuSource;

    public MainForm(IStoryManager storyManager, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _materialSkinManager = MaterialSkinManager.Instance;
        _materialSkinManager.EnforceBackcolorOnAllComponents = true;
        _materialSkinManager.AddFormToManage(this);
        _materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        _materialSkinManager.ColorScheme = new MaterialColorScheme(MaterialPrimary.Green600, MaterialPrimary.Green700, MaterialPrimary.Green200, MaterialAccent.Red100, MaterialTextShade.LIGHT);

        _storyManager = storyManager;
        _serviceProvider = serviceProvider;
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

            var actionButton = new ActionButton(storyAction.Operation, storyAction.BaseUrl) { Margin = new Padding(7) };

            actionButton.Click += ActionButton_Click;
            actionButton.ContextMenuStrip = ActonButtonContextMenu;

            StoryPanel.Controls.Add(actionButton);
        }
    }

    private void ImportButton_Click(object sender, EventArgs e)
    {
        using var importDialog = _serviceProvider.GetRequiredService<ImportDialog>();

        _materialSkinManager.AddFormToManage(importDialog);

        var result = importDialog.ShowDialog();

        if (result == DialogResult.OK && importDialog.Operations.Any() && importDialog.BaseUrl != null)
        {
            try
            {
                Enabled = false;
                Cursor = Cursors.WaitCursor;
                MethodsPanel.SuspendLayout();

                var baseUrl = importDialog.BaseUrl;

                foreach (var operation in importDialog.Operations)
                {
                    AddMethod(operation, baseUrl);
                }

                TagFilterComboBox.Items.Clear();
                //TagFilterComboBox.Items.AddRange([.. importDialog.Operations.Tags]);
            }
            finally
            {
                MethodsPanel.ResumeLayout();
                Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }

    private void AddMethod(OpenApiOperation operation, string baseUrl)
    {
        var button = new ActionButton(operation, baseUrl)
        {
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
                //var actionNameFound = string.IsNullOrEmpty(actionName) || control.Text.Contains(actionName, StringComparison.OrdinalIgnoreCase);
                //
                //var tagFound = string.IsNullOrEmpty(tag) || control.Operation?.Tags.Any(x => x.Contains(tag, StringComparison.OrdinalIgnoreCase)) == true;
                //
                //control.Visible = actionNameFound && tagFound;
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

    private void AddNewMethodToStory(string name, string verb, string baseUrl, OpenApiOperation operation)
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

        var actionButton = new ActionButton(operation, baseUrl) { Margin = new Padding(7) };

        actionButton.Click += ActionButton_Click;

        StoryPanel.Controls.Add(actionButton);

        CreateStoryAction(actionButton.Id, baseUrl, operation);

        _storyManager.SaveStory(_currentStory);
    }

    private void CreateStoryAction(string id, string baseUrl, OpenApiOperation operation)
    {
        if (_currentStory == null)
            return;

        var storyAction = new StoryAction
        {
            Id = id,
            Verb = operation.Method,
            BaseUrl = baseUrl,
            RelativeUrl = operation.Path.Replace(baseUrl, string.Empty),
            Operation = operation
        };

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
        LoadParameters(_currentStoryAction.Operation.Parameters);
        LoadRequestBody(_currentStoryAction.Operation.RequestBody);
        LoadResponses(_currentStoryAction.Operation.Responses);

        if (!OptionsPanel.Visible)
            OptionsPanel.Visible = true;
    }

    private void LoadOptions(StoryActionOptions options)
    {
        //EnabledCheckBox.Checked = options.Enabled;
        CallsCountTextBox.Text = options.RequestsCount.ToString();
        ParallelismTextBox.Text = options.DegreeOfParallelism.ToString();
    }

    private void LoadParameters(List<OpenApiParameter> parameters)
    {
        if (_currentStory == null || _currentStoryAction == null)
            return;

        ParametersTableLayoutPanel.SuspendLayout();
        ParametersTableLayoutPanel.Controls.Clear();
        ParametersTableLayoutPanel.RowStyles.Clear();
        ParametersTableLayoutPanel.RowCount = 0;

        foreach (var parameter in parameters)
        {
            var parameterControl = new QueryParameterControl(parameter.Name, parameter.Type, parameter.Required, parameter.Value ?? parameter.MockValue?.ToString() ?? string.Empty)
            {
                Tag = parameter,
                Dock = DockStyle.Fill
            };

            parameterControl.Modified += (sender, e) =>
            {
                if (sender is not QueryParameterControl control)
                    return;

                _currentStoryAction.Operation.Parameters.Single(x => x.Name == control.ParameterName).Value = control.Value;

                _storyManager.SaveStory(_currentStory);
            };

            ParametersTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            ParametersTableLayoutPanel.Controls.Add(parameterControl, 0, ParametersTableLayoutPanel.RowCount++);
        }

        ParametersTableLayoutPanel.ResumeLayout();
    }

    private void LoadRequestBody(OpenApiRequestBody? requestBody)
    {
        if (requestBody?.Schema == null)
        {
            RequestRichTextBox.Text = "No request body defined for this operation";
            RequestRichTextBox.Enabled = false;
            return;
        }

        RequestRichTextBox.Text = requestBody.Value ?? requestBody.Schema;
        RequestRichTextBox.Enabled = true;
    }

    private void RequestRichTextBox_TextChanged(object sender, EventArgs e)
    {
        if (_currentStory == null || _currentStoryAction == null || _currentStoryAction.Operation.RequestBody == null)
            return;

        _currentStoryAction.Operation.RequestBody.Value = RequestRichTextBox.Text;

        _storyManager.SaveStory(_currentStory);
    }

    private void LoadResponses(Dictionary<string, OpenApiResponse> responses)
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
            HttpCodesComboBox.Tag is not Dictionary<string, OpenApiResponse> ||
            HttpCodesComboBox.SelectedValue is not string code)
        {
            return;
        }

        var responses = (Dictionary<string, OpenApiResponse>)HttpCodesComboBox.Tag!;

        if (responses.TryGetValue(code, out var response))
            ResponseRichTextBox.Text = response.Schema;
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

    private void CallsCountTextBox_TextChanged(object sender, EventArgs e)
    {
        if (_currentStory == null || _currentStoryAction == null || !int.TryParse(CallsCountTextBox.Text, out var value) || value <= 0)
            return;

        _currentStoryAction.Options.RequestsCount = value;

        _storyManager.SaveStory(_currentStory);
    }

    private void Parallelism_TextChanged(object sender, EventArgs e)
    {
        if (_currentStory == null || _currentStoryAction == null || !int.TryParse(ParallelismTextBox.Text, out var value) || value <= 0)
            return;

        _currentStoryAction.Options.DegreeOfParallelism = value;

        _storyManager.SaveStory(_currentStory);
    }

    private void RunButton_Click(object sender, EventArgs e)
    {
        if (_currentStory == null)
            return;

        using var runDialog = _serviceProvider.GetRequiredService<RunDialog>();

        _materialSkinManager.AddFormToManage(runDialog);

        runDialog.StoryToRun = _currentStory;
        runDialog.ShowDialog();
    }

    private void RemoveMenuItem_Click(object sender, EventArgs e)
    {
        var sourceControl = ActonButtonContextMenu.SourceControl;

        if (sourceControl is not ActionButton actionButton || _currentStory == null)
            return;

        var elementToRemoveIndex = StoryPanel.Controls.IndexOf(actionButton);

        if (elementToRemoveIndex == -1)
            return;

        StoryPanel.Controls.RemoveAt(elementToRemoveIndex);

        if (StoryPanel.Controls.Count > 0)
            StoryPanel.Controls.RemoveAt(elementToRemoveIndex - 1); //removes THEN

        _currentStory.Actions.RemoveAt(_currentStory.Actions.Keys.FirstOrDefault(x => _currentStory.Actions[x].Id == actionButton.Id));

        _storyManager.SaveStory(_currentStory);
    }
}

public static class HttpVerbs
{
    public const string Get = "GET";
    public const string Post = "POST";
    public const string Put = "PUT";
    public const string Patch = "PATCH";
    public const string Delete = "DELETE";
}

public class Method
{
    public required string BaseUrl { get; set; }
    public required string Name { get; set; }
    public required string Verb { get; set; }
    public required OpenApiOperation Operation { get; set; }
}

public class Action
{
    public required string BaseUrl { get; set; }
    public required string Name { get; set; }
    public required string Verb { get; set; }
}