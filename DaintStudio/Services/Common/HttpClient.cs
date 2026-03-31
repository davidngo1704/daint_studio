namespace DaintStudio.Services.Common;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

public class HttpClientService
{
    public static T Get<T>(HttpClient httpClient)
    {


        return default;
    }
    public static T PostFile<T>(string url, string path_file)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentNullException(nameof(url));
        if (string.IsNullOrWhiteSpace(path_file))
            throw new ArgumentNullException(nameof(path_file));
        if (!File.Exists(path_file))
            throw new FileNotFoundException("File not found", path_file);

        using var httpClient = new HttpClient();
        using var form = new MultipartFormDataContent();
        using var fileStream = File.OpenRead(path_file);

        var streamContent = new StreamContent(fileStream);
        streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        var fileName = Path.GetFileName(path_file);
        form.Add(streamContent, "file", fileName);

        var response = httpClient.PostAsync(url, form).GetAwaiter().GetResult();
        response.EnsureSuccessStatusCode();
        var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        if (typeof(T) == typeof(string))
            return (T)(object)responseString;

        if (string.IsNullOrWhiteSpace(responseString))
            return default!;

        return JsonSerializer.Deserialize<T>(responseString)!;
    }
}
