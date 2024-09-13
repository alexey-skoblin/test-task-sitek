using System.Text.Json;

namespace TestTaskSitek.parser;

public class JsonParser<T> : IParser<T> where T : new()
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public T Parse(string value)
    {
        return JsonSerializer.Deserialize<T>(value, Options) ?? new T();
    }

    public List<T> ParseToList(string value)
    {
        return JsonSerializer.Deserialize<List<T>>(value, Options) ?? [];
    }
}