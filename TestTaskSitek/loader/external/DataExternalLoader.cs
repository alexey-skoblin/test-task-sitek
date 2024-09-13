using System.IO.Compression;
using TestTaskSitek.output;
using TestTaskSitek.utility;
using Version = TestTaskSitek.entity.Version;

namespace TestTaskSitek.data;

public class DataExternalLoader(FileManager fileManager) : IExternalLoader
{
    public string Load(Version version, ISender sender)
    {
        var pathToDownloads = version.Id.ToString();
        var pathArchive = Path.Combine(pathToDownloads, version.Id + ".zip");
        fileManager.CreateIfNotExists(pathToDownloads);
        if (fileManager.GetAllFilesRecursive(pathToDownloads).Count != 0) return pathToDownloads;
        sender.DownloadFile(version.GarXmlDeltaUrl, pathArchive);
        ZipFile.ExtractToDirectory(pathArchive, pathToDownloads);
        File.Delete(pathArchive);
        return pathToDownloads;
    }
}