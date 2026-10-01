namespace Testhardo;

public class Story : IEquatable<Story?>
{
    public required Guid Id { get; init; }
    public required string Description { get; init; }

    public OrderedDictionary<int, StoryAction> Actions { get; init; } = [];

    public StoryAction? GetAction(string id) => Actions.Values.SingleOrDefault(x => x.Id == id);

    #region Equality
    public override bool Equals(object? obj) => Equals(obj as Story);
    public bool Equals(Story? other) => other is not null && Id.Equals(other.Id);
    public override int GetHashCode() => HashCode.Combine(Id);
    public static bool operator ==(Story? left, Story? right) => EqualityComparer<Story>.Default.Equals(left, right);
    public static bool operator !=(Story? left, Story? right) => !(left == right);
    #endregion
}

public class StoryAction : IEquatable<StoryAction?>
{
    public required string Id { get; init; }
    public string Description => RelativeUrl.Length > 0 ? RelativeUrl[1..] : string.Empty;
    public required string Verb { get; init; }
    public required string BaseUrl { get; init; }
    public required string RelativeUrl { get; init; }

    public StoryActionOptions Options { get; } = new();

    public required OpenApiOperation Operation { get; init; }

    #region Equality
    public override bool Equals(object? obj) => Equals(obj as StoryAction);
    public bool Equals(StoryAction? other) => other is not null && Id.Equals(other.Id);
    public override int GetHashCode() => HashCode.Combine(Id);
    public static bool operator ==(StoryAction? left, StoryAction? right) => EqualityComparer<StoryAction>.Default.Equals(left, right);
    public static bool operator !=(StoryAction? left, StoryAction? right) => !(left == right);
    #endregion
}

public class StoryActionOptions
{
    public bool Enabled { get; set; } = true;
    public int RequestsCount { get; set; } = 1;
    public int TimeoutInSeconds { get; set; } = 10;
    public int DegreeOfParallelism { get; set; } = 10;
}