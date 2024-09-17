namespace TestTaskSitek.utility;

public class FileManager
{
    public void CreateIfNotExists(string path)
    {
            Directory.CreateDirectory(path);
    }

    public void ClearDir(string path)
    {
        var di = new DirectoryInfo(path);
        foreach (var file in di.GetFiles()) file.Delete();
        foreach (var dir in di.GetDirectories()) dir.Delete(true);
    }

    public List<FileInfo> GetAllFilesRecursive(string path)
    {
        var directory = new DirectoryInfo(path);
        var files = new List<FileInfo>();

        foreach (var file in directory.GetFiles()) files.Add(file);

        foreach (var dir in directory.GetDirectories()) files.AddRange(GetAllFilesRecursive(dir.FullName));

        return files;
    }
}