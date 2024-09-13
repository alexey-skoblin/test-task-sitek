using TestTaskSitek.entity;

namespace TestTaskSitek.output.@internal;

internal interface IOutput
{
    void Output(Dictionary<AddressLevel, List<Address>> dictionary);
}