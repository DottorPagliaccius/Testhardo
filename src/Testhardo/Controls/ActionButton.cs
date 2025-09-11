using ReaLTaiizor.Controls;

namespace Testhardo;

public partial class ActionButton : UserControl
{
    public Action Action { get; }

    public MaterialButton Button => MainButton;

    public ActionButton(Action action)
    {
        Action = action;

        InitializeComponent();

        VerbLabel.Text = action.Verb;
        VerbLabel.BackColor = GetActionColor(action.Verb);
        MainButton.Text = action.Name.AsSpan(1).ToString();

        ToolTipManager.SetToolTip(MainButton, $"{action.Verb} {action.BaseUrl}{action.Name}");

        foreach (Control control in Controls)
        {
            control.MouseDown += (s, e) => OnMouseDown(e);
        }
    }

    private static Color GetActionColor(string httpVerb) => httpVerb switch
    {
        HttpVerbs.Get => Color.FromArgb(97, 175, 254),
        HttpVerbs.Post => Color.FromArgb(73, 204, 144),
        HttpVerbs.Put => Color.FromArgb(80, 227, 194),
        HttpVerbs.Delete => Color.FromArgb(249, 62, 62),
        _ => throw new NotImplementedException(),
    };
}
