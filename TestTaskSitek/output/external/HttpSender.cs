namespace TestTaskSitek.output;

public class HttpSender : ISender
{
    private readonly HttpClient _httpClient = new();

    public string Send(string url)
    {
        var response = _httpClient.GetAsync(url).Result;
        return response.Content.ReadAsStringAsync().Result;
    }

    public void DownloadFile(string fileUrl, string filePath)
    {
        var fileStream = _httpClient.GetStreamAsync(fileUrl).Result;
        using var file = File.Create(filePath);
        fileStream.CopyTo(file);
    }
}