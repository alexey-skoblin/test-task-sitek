namespace TestTaskSitek.loader.@internal;

public interface IInternalLoader<T>
{
    public List<T> Load(List<FileInfo> files);
}