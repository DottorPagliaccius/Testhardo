namespace Testhardo;

public static class Utility
{
    public static Color GetActionColor(string httpVerb) => httpVerb switch
    {
        HttpVerbs.Get => Color.FromArgb(97, 175, 254),
        HttpVerbs.Post => Color.FromArgb(73, 204, 144),
        HttpVerbs.Put => Color.FromArgb(252, 161, 48),
        HttpVerbs.Patch => Color.FromArgb(80, 227, 194),
        HttpVerbs.Delete => Color.FromArgb(249, 62, 62),
        _ => throw new NotImplementedException(),
    };
}
