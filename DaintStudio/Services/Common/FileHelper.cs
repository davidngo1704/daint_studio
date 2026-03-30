
using System.Text.Json;

namespace DaintStudio.Services.Common;

public static class FileHelper
{

    private static readonly SemaphoreSlim _lock = new(1, 1);
    public static void WriteText(string path, string text)
    {
        var directory = Path.GetDirectoryName(path);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        File.WriteAllText(path, text);
    }

    public static bool IsExist(string filePath)
    {
        return File.Exists(filePath);
    }
    public static T Load<T>(string filePath) where T : new()
    {
        try
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);

                var obj = JsonService.FromJson<T>(json);

                return obj;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return new T();
    }
    private static async Task WriteJsonObjectAsync<T>(
        string filePath,
        T obj,
        FileMode type = FileMode.Append,
        bool isIntend = false
        )
    {
        string jsonLine = JsonSerializer.Serialize(obj, new JsonSerializerOptions(DefaultValue.JsonOption) { WriteIndented = isIntend });

        var directory = Path.GetDirectoryName(filePath);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        // Mở file ở chế độ append (tạo nếu chưa tồn tại)
        await using var stream = new FileStream(filePath, type, FileAccess.Write, FileShare.Read);

        await using var writer = new StreamWriter(stream);

        await writer.WriteLineAsync(jsonLine);
    }
    public static async Task WriteJsonObjectSafeAsync<T>(
        string filePath,
        T obj,
        FileMode type = FileMode.Append,
        bool isIntend = false
        )
    {
        await _lock.WaitAsync();
        try
        {
            await WriteJsonObjectAsync(filePath, obj, type, isIntend);
        }
        finally
        {
            _lock.Release();
        }
    }

    /// <summary>
    /// Đọc toàn bộ file .jsonl vào danh sách object (load hết file vào RAM).
    /// </summary>

    public static async Task<List<T>> ReadAllAsync<T>(string filePath)
    {
        var list = new List<T>();

        if (!File.Exists(filePath))
            return list;

        using var reader = new StreamReader(filePath);
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            try
            {
                var obj = JsonSerializer.Deserialize<T>(line, DefaultValue.JsonOption);
                if (obj != null)
                    list.Add(obj);
            }
            catch (JsonException ex)
            {

            }
        }

        return list;
    }

    /// <summary>
    /// Stream đọc từng dòng file .jsonl (dành cho file lớn, không load toàn bộ RAM).
    /// </summary>
    /// 
    public static async IAsyncEnumerable<T> StreamReadAsync<T>(string filePath)
    {
        if (!File.Exists(filePath))
            yield break;

        using var reader = new StreamReader(filePath);
        string line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            yield return JsonSerializer.Deserialize<T>(line);
        }
    }

    private static async Task ExampleStreamReadAsync()
    {
        await foreach (var trade in StreamReadAsync<object>("signals.jsonl"))
        {
            Console.WriteLine(trade);
        }
    }

    /// <summary>
    /// Stream đọc liên tục (giống "tail -f"): đọc từng dòng JSON,
    /// chờ nếu file chưa có dòng mới.
    /// </summary>
    public static async IAsyncEnumerable<T> StreamFollowAsync<T>(
        string filePath,
        int checkIntervalMs = 500,
        CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
            yield break;

        using var stream = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite); // cho phép process khác ghi song song

        using var reader = new StreamReader(stream);

        string? line;

        while (!cancellationToken.IsCancellationRequested)
        {
            line = await reader.ReadLineAsync();

            if (line != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var obj = JsonSerializer.Deserialize<T>(line, DefaultValue.JsonOption);
                if (obj != null)
                    yield return obj;
            }
            else
            {
                // Không có dòng mới → chờ 1 lúc rồi thử lại
                await Task.Delay(checkIntervalMs, cancellationToken);
            }
        }
    }

    private static async Task ExampleStreamFollowAsync()
    {
        var cts = new CancellationTokenSource();

        try
        {
            await foreach (var trade in StreamFollowAsync<object>("signals.jsonl", 300, cts.Token))
            {
                Console.WriteLine(trade);
            }
        }
        catch (OperationCanceledException ex)
        {

        }

    }

    public static T Read<T>(string path)
    {
        try
        {
            return JsonService.FromJson<T>(File.ReadAllText(path)) ?? default;

        }
        catch (Exception ex)
        {
            return default;
        }
    }
    public static void Write<T>(string path, T obj)
    {
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }
        File.WriteAllText(path, JsonService.ToJson(obj));
    }
    public static byte[] ReadFileAsBytes(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentException("File path không được rỗng.");

        if (!File.Exists(filePath))
            throw new FileNotFoundException("Không tìm thấy file.", filePath);

        return File.ReadAllBytes(filePath);
    }
    public static T ReadeFile<T>(string filePath)
    {
        if (File.Exists(filePath))
        {
            return JsonSerializer.Deserialize<T>(File.ReadAllText(filePath))!;
        }
        return default!;
    }
}
