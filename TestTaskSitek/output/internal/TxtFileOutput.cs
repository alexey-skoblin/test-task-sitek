using TestTaskSitek.entity;

namespace TestTaskSitek.output.@internal;

public class TxtFileOutput : IOutput
{

    public TxtFileOutput(string heading)
    {
        Heading = heading;
    }
    
    public TxtFileOutput(string path, string heading)
    {
        Path = path;
        Heading = heading;
    }

    private const string Name = "Отчет.txt";
    private string Path { get; set; } = "";
    private string Heading { get; set; }
    
    public void Output(Dictionary<AddressLevel, List<Address>> dictionary)
    {
        var path = string.IsNullOrEmpty(Path) ? Name : System.IO.Path.Combine(Path, Name);
        using var writer = new StreamWriter(path);
        {
            writer.WriteLine(Heading);
            // writer.WriteLine();
            foreach (var (addressLevel, addresses) in dictionary)
            {
                writer.WriteLine($"   Address Level: {addressLevel.Name}");
                // writer.WriteLine();
                foreach (var line in addresses.Select(address => $"      ID: {address.Id}," +
                                                                 $" Type: {address.TypeName}," +
                                                                 $" Name: {address.Name}"))
                {
                    writer.WriteLine(line);
                }
                // writer.WriteLine();
            }
        }
    }
}