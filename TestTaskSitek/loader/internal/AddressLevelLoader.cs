using TestTaskSitek.entity;
using TestTaskSitek.parser;

namespace TestTaskSitek.loader.@internal;

public class AddressLevelLoader(IParser<AddressLevel> parser) : IInternalLoader<AddressLevel>
{
    public List<AddressLevel> Load(List<FileInfo> files)
    {
        var fileLevels = files.Find(x => x.Name.StartsWith("AS_OBJECT_LEVELS"));
        var addressLevels = new List<AddressLevel>();
        if (fileLevels == null) return addressLevels;
        var xmlAddresses = File.ReadAllText(fileLevels.FullName);
        var list = parser.ParseToList(xmlAddresses);
        addressLevels.AddRange(list);
        return addressLevels;
    }
}