using System.ComponentModel;

namespace Testhardo;

public partial class ActionButton : UserControl
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Guid Id { get; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string MethodName { get; init; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string BaseUrl { get; init; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Verb { get; init; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public OpenApiDocument.Operation? Operation { get; init; }

    public ActionButton(string name, string verb, string baseUrl, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        MethodName = name;
        Verb = verb;
        BaseUrl = baseUrl;

        InitializeComponent();

        VerbLabel.Text = verb;
        VerbLabel.BackColor = Utility.GetActionColor(verb);
        MainButton.Text = name.AsSpan(1).ToString();

        ToolTipManager.SetToolTip(MainButton, $"{verb} {baseUrl}{name}");

        foreach (Control control in Controls)
        {
            control.MouseDown += (s, e) => OnMouseDown(e);
            control.Click += (s, e) => OnClick(e);
        }
    }

    public void SetSelected() => MainButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Outlined;
    public void SetUnselected() => MainButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;

    public override Cursor Cursor
    {
        get => base.Cursor;
        set
        {
            if (value == null)
                return;

            base.Cursor = value;

            foreach (Control control in Controls)
            {
                control.Cursor = value;
            }
        }
    }
}
