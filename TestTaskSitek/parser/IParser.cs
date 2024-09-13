namespace TestTaskSitek.parser;

public interface IParser<T>
{
    T Parse(string value);
    List<T> ParseToList(string value);
}