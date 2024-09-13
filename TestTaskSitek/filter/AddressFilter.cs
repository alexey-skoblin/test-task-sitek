using TestTaskSitek.entity;

namespace TestTaskSitek.filter;

public class AddressFilter : IFilter<Address>
{
    public IEnumerable<Address> Filter(IEnumerable<Address> items)
    {
        return items.Where(address => address.IsActive);
    }
}