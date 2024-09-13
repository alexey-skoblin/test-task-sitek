using TestTaskSitek.entity;
using TestTaskSitek.parser;

namespace TestTaskSitek.loader.@internal;

public class AddressLoader(IParser<Address> parser) : IInternalLoader<Address>
{
    public List<Address> Load(List<FileInfo> files)
    {
        var addresses = new List<Address>();
        foreach (var address in files.Where(file => file.Name.StartsWith("AS_ADDR_OBJ"))
                     .Select(file => File.ReadAllText(file.FullName))
                     .Select(parser.ParseToList))
            addresses.AddRange(address);
        return addresses;
    }
}