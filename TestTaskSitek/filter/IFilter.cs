namespace TestTaskSitek.filter;

public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items);
}