using ReaLTaiizor.Colors;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using Testhardo.Properties;

namespace Testhardo;

public partial class MainForm : MaterialForm
{
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
                MethodsFlowPanel.SuspendLayout();

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
                MethodsFlowPanel.ResumeLayout();
                Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }

    private void AddAction(string baseUrl, string actionName, OpenApiDocument.Operation operation, string httpVerb)
    {
        //var button = new MaterialButton
        //{
        //    Text = $"{httpVerb} {actionName.AsSpan(1)}",
        //    Cursor = Cursors.Hand,
        //    Icon = GetActionIcon(httpVerb),
        //    IconType = MaterialButton.MaterialIconType.Default,
        //    Tag = new Action
        //    {
        //        BaseUrl = baseUrl,
        //        Name = actionName,
        //        Verb = httpVerb,
        //        Operation = operation
        //    }
        //};

        var button = new ActionButton(new Action
        {
            BaseUrl = baseUrl,
            Name = actionName,
            Verb = httpVerb,
            Operation = operation
        });
        
        MethodsFlowPanel.Controls.Add(button);
    }

    private static Bitmap? GetActionIcon(string httpVerb) => httpVerb switch
    {
        HttpVerbs.Get => Resources.get,
        HttpVerbs.Post => Resources.download_white,
        HttpVerbs.Put => Resources.Get2,
        HttpVerbs.Delete => null,//Resources.delete;
        _ => null,
    };

    private void Filter(string? actionName, string? tag)
    {
        if (string.IsNullOrEmpty(actionName) && string.IsNullOrEmpty(tag))
        {
            foreach (var control in MethodsFlowPanel.Controls.OfType<MaterialButton>())
            {
                control.Visible = true;
            }
        }
        else
        {
            foreach (var control in MethodsFlowPanel.Controls.OfType<MaterialButton>())
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