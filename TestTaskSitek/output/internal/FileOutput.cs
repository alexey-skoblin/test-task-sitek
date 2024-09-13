using TestTaskSitek.entity;

namespace TestTaskSitek.output.@internal;

public class FileOutput : IOutput
{
    public void Output(Dictionary<AddressLevel, List<Address>> dictionary)
    {
        foreach (var (addressLevel, addresses) in dictionary)
        {
            var fileName = $"{addressLevel.Name}.txt";
            using var writer = new StreamWriter(fileName);
            foreach (var line in addresses.Select(address => $"Address ID: {address.Id}," +
                                                             $" Address Type: {address.TypeName}," +
                                                             $" Address Name: {address.Name}"))
                writer.WriteLine(line);
        }
    }
}