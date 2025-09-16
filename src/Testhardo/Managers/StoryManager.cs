using System.Collections.Concurrent;
using System.Text.Json;

namespace Testhardo;

public interface IStoryManager
{
    void DeleteStory(Guid id);
    IDictionary<Guid, string> GetStories();
    Story? GetStory(Guid id);
    string GetUniqueName();
    void SaveStory(Story story);
}

public class StoryManager : IStoryManager
{
    private readonly string _path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Testhardo\Stories";

    public IDictionary<Guid, string> GetStories()
    {
        if (!Directory.Exists(_path))
            return new Dictionary<Guid, string>();

        var stories = new ConcurrentDictionary<Guid, string>();

        var files = Directory.GetFiles(_path, "*.json");

        Parallel.ForEach(files, file =>
        {
            var story = JsonSerializer.Deserialize<Story>(File.ReadAllText(file), Program.DefaultJsonSerializerOptions);

            if (story is null)
                return;

            stories.TryAdd(story.Id, story.Description);
        });

        return stories;
    }

    public Story? GetStory(Guid id)
    {
        var filePath = Path.Combine(_path, $"{id}.json");

        if (!File.Exists(filePath))
            return null;

        var json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<Story>(json, Program.DefaultJsonSerializerOptions);
    }

    public void SaveStory(Story story)
    {
        if (!Directory.Exists(_path))
            Directory.CreateDirectory(_path);

        var filePath = Path.Combine(_path, $"{story.Id}.json");
        var json = JsonSerializer.Serialize(story, Program.DefaultJsonSerializerOptions);

        File.WriteAllText(filePath, json);
    }

    public void DeleteStory(Guid id)
    {
        var filePath = Path.Combine(_path, $"{id}.json");

        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    public string GetUniqueName()
    {
        const string baseName = "Story";

        if (!Directory.Exists(_path))
            return $"{baseName}{1}";

        var counter = 1;
        var stories = GetStories();

        while (stories.Values.Contains($"{baseName}{counter}"))
            counter++;

        return $"{baseName}{counter}";
    }
}
