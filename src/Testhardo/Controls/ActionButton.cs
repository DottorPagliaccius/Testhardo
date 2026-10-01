using System.ComponentModel;

namespace Testhardo;

public partial class ActionButton : UserControl
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Id => Operation.OperationId;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string MethodName => Operation.Summary is null or "" ? Operation.Path : Operation.Summary;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string BaseUrl { get; init; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Verb => Operation.Method;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public OpenApiOperation Operation { get; init; }

    public ActionButton(OpenApiOperation operation, string baseUrl)
    {
        Operation = operation;
        BaseUrl = baseUrl;

        InitializeComponent();

        VerbLabel.Text = Verb;
        VerbLabel.BackColor = Utility.GetActionColor(Verb);
        MainButton.Text = MethodName.AsSpan(1).ToString();

        ToolTipManager.SetToolTip(MainButton, $"{Verb} {baseUrl}{MethodName}");

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
            base.Cursor = value;

            foreach (Control control in Controls)
            {
                control.Cursor = value;
            }
        }
    }
}