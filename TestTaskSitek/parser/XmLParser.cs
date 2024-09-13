using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TestTaskSitek.parser;

public class XmLParser<T> : IParser<T> where T : new()
{
    private static readonly XmlSerializer Serializer = new(typeof(T));

    public T Parse(string value)
    {
        return (T)Serializer.Deserialize(new StringReader(value))! ?? new T();
    }

    public List<T> ParseToList(string value)
    {
        var rootAttribute = typeof(T).GetCustomAttribute<XmlRootAttribute>()?.ElementName;
        var document = XDocument.Parse(value);
        var elements = document.Descendants(rootAttribute);
        var list = new List<T>();
        foreach (var element in elements) list.Add(Parse(element.ToString()));
        return list;
    }
}