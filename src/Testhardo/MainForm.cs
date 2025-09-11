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

    public MainForm()
    {
        InitializeComponent();

        _materialSkinManager = MaterialSkinManager.Instance;
        _materialSkinManager.EnforceBackcolorOnAllComponents = true;
        _materialSkinManager.AddFormToManage(this);
        _materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        _materialSkinManager.ColorScheme = new MaterialColorScheme(MaterialPrimary.Green600, MaterialPrimary.Green700, MaterialPrimary.Green200, MaterialAccent.Red100, MaterialTextShade.LIGHT);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    private void ImportButton_Click(object sender, EventArgs e)
    {
        var importDialog = new ImportDialog();

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
                        AddAction(baseUrl, actionName, verbs.Get, HttpVerbs.Get);
                    }

                    if (verbs.Post != null)
                    {
                        AddAction(baseUrl, actionName, verbs.Post, HttpVerbs.Post);
                    }

                    if (verbs.Put != null)
                    {
                        AddAction(baseUrl, actionName, verbs.Put, HttpVerbs.Put);
                    }

                    if (verbs.Delete != null)
                    {
                        AddAction(baseUrl, actionName, verbs.Delete, HttpVerbs.Delete);
                    }
                }

                TagFilterComboBox.Items.Clear();
                TagFilterComboBox.Items.AddRange(importDialog.OpenApiDocument.Tags.ToArray());
            }
            finally
            {
                MethodsPanel.ResumeLayout();
                Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }

    private void AddAction(string baseUrl, string actionName, OpenApiDocument.Operation operation, string httpVerb)
    {
        var button = new ActionButton(new Action
        {
            BaseUrl = baseUrl,
            Name = actionName,
            Verb = httpVerb,
            Operation = operation,
        });

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
            foreach (var control in MethodsPanel.Controls.OfType<MaterialButton>())
            {
                var actionNameFound = string.IsNullOrEmpty(actionName) || control.Text.Contains(actionName, StringComparison.OrdinalIgnoreCase);

                var action = (Action?)control.Tag;

                var tagFound = string.IsNullOrEmpty(tag) || action?.Operation.Tags.Any(x => x.Contains(tag, StringComparison.OrdinalIgnoreCase)) == true;

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

        DoDragDrop(dragSourceButton, DragDropEffects.Copy);
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
                if (e.Data.GetData(typeof(ActionButton)) is not ActionButton original)
                    return;

                AddButtonWithThen(original.Action);
            }
        }
        finally
        {
            _bitmapCursor?.Dispose();
            _bitmapCursor = null;
        }
    }

    private void AddButtonWithThen(Action action)
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

        var actionButton = new ActionButton(action)
        {
            Margin = new Padding(7)
        };

        StoryPanel.Controls.Add(actionButton);
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
}

public static class HttpVerbs
{
    public const string Get = "GET";
    public const string Post = "POST";
    public const string Put = "PUT";
    public const string Delete = "DELETE";
}

public class Action
{
    public required string BaseUrl { get; set; }
    public required string Name { get; set; }
    public required string Verb { get; set; }
    public required OpenApiDocument.Operation Operation { get; set; }
}