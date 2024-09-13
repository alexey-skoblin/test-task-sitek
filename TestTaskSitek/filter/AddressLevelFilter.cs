using TestTaskSitek.entity;

namespace TestTaskSitek.filter;

public class AddressLevelFilter(HashSet<string> setOfStrings) : IFilter<AddressLevel>
{
    public IEnumerable<AddressLevel> Filter(IEnumerable<AddressLevel> items)
    {
        return items.Where(address => setOfStrings.Contains(address.Name));
    }
}