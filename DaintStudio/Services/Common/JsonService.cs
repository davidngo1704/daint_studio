
using System.Text.Json;

namespace DaintStudio.Services.Common;

public class JsonService
{
    public static string ToJson(object obj, bool indented = false)
    {
        var options = DefaultValue.JsonOption;
        if (indented)
        {
            options = new JsonSerializerOptions(DefaultValue.JsonOption) { WriteIndented = true };
        }
        return JsonSerializer.Serialize(obj, options);
    }
    public static T? FromJson<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, DefaultValue.JsonOption);
    }
    public static T? CloneObject<T>(T source)
    {
        if (source == null) return default;
        var json = ToJson(source);
        return FromJson<T>(json);
    }
}
