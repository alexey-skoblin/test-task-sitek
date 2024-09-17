using TestTaskSitek.data;
using TestTaskSitek.entity;
using TestTaskSitek.filter;
using TestTaskSitek.loader.@internal;
using TestTaskSitek.output;
using TestTaskSitek.output.@internal;
using TestTaskSitek.parser;
using TestTaskSitek.utility;
using Version = TestTaskSitek.entity.Version;

namespace TestTaskSitek;

internal static class Program
{
    private const string Url = "http://fias.nalog.ru/WebServices/Public/GetLastDownloadFileInfo";

    private static readonly FileManager FileManager = new();

    private static readonly HashSet<string> SetOfStrings = ["Дом", "Квартира", "Земельный участок", "Машино-место"];


    private static void Main(string[] args)
    {
        ISender sender = new HttpSender();
        var jsonResponse = sender.Send(Url);
        IParser<Version> parser = new JsonParser<Version>();
        var version = parser.Parse(jsonResponse);
        IExternalLoader dataExternalLoader = new DataExternalLoader(FileManager);
        var pathToDownloads = dataExternalLoader.Load(version, sender);

        var files = FileManager.GetAllFilesRecursive(pathToDownloads);

        IParser<AddressLevel> addressLevelParser = new XmLParser<AddressLevel>();
        IInternalLoader<AddressLevel> addressLevelLoader = new AddressLevelLoader(addressLevelParser);
        var levels = addressLevelLoader.Load(files);
        IParser<Address> addressParser = new XmLParser<Address>();
        IInternalLoader<Address> addressLoader = new AddressLoader(addressParser);
        var addresses = addressLoader.Load(files);

        IFilter<AddressLevel> addressLevelFilter = new AddressLevelFilter(SetOfStrings);
        var filteredLevels = addressLevelFilter.Filter(levels).Select(x => x.LevelNumber).ToHashSet();
        IFilter<Address> addressIfContainsLevelFilter = new AddressIfNotContainsLevelFilter(filteredLevels);
        IFilter<Address> addressFilter = new AddressFilter();
        var filteredAddresses = addressFilter.Filter(addressIfContainsLevelFilter.Filter(addresses)).ToList();

        var dictionaryLevels = levels.ToDictionary(variableLevel => variableLevel.LevelNumber);
        Dictionary<AddressLevel, List<Address>> dictionary = new();
        foreach (var address in filteredAddresses)
        {
            if (!dictionaryLevels.TryGetValue(address.Level, out var addressLevel)) continue;
            if (!dictionary.TryGetValue(addressLevel, out var value))
            {
                value = [];
                dictionary[addressLevel] = value;
            }

            value.Add(address);
        }
        
        foreach (var (key, value) in dictionary) {
            value.Sort();
        }
        
        string heading = $"Отчет по добавленным объектам за {DateTime.Now:dd.MM.yyyy}";
        IOutput output = new TxtFileOutput(heading);
        output.Output(dictionary);
    }
}