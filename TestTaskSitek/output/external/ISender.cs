namespace TestTaskSitek.output;

public interface ISender
{
    string Send(string url);

    void DownloadFile(string fileUrl, string filePath);
}