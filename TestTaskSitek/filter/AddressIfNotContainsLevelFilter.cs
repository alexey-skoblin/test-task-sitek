using TestTaskSitek.entity;

namespace TestTaskSitek.filter;

public class AddressIfNotContainsLevelFilter(HashSet<int> setOfLevels) : IFilter<Address>
{
    public IEnumerable<Address> Filter(IEnumerable<Address> levels)
    {
        return levels.Where(address => !setOfLevels.Contains(address.Level));
    }
}