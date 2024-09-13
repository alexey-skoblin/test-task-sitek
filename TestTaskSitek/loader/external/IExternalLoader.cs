using TestTaskSitek.output;
using Version = TestTaskSitek.entity.Version;

namespace TestTaskSitek.data;

public interface IExternalLoader
{
    public string Load(Version version, ISender sender);
}