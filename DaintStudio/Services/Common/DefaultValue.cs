

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DaintStudio.Services.Common;

public static class DefaultValue
{
    public static readonly JsonSerializerOptions JsonOption = new()
    {
        WriteIndented = false,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
        Converters =
        {
            new UtcDateTimeConverter(),
            new DecimalAsStringConverter(),
            new NullableDecimalAsStringConverter()
        }

    };
}
public class UtcDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var str = reader.GetString();
        if (DateTime.TryParse(str, null, DateTimeStyles.AdjustToUniversal, out var dt))
            return DateTime.SpecifyKind(dt, DateTimeKind.Utc);
        return DateTime.UtcNow; // fallback an toàn
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
    }
}
public class DecimalAsStringConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Nếu token là number thì đọc trực tiếp
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetDecimal();
        }

        // Nếu token là string -> parse with InvariantCulture
        var s = reader.GetString();
        if (string.IsNullOrWhiteSpace(s))
            return 0m;

        if (decimal.TryParse(s, NumberStyles.Number | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var result))
            return result;

        // fallback: try current culture (optional)
        if (decimal.TryParse(s, NumberStyles.Number | NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, out result))
            return result;

        throw new JsonException($"Cannot convert \"{s}\" to System.Decimal.");
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        // Viết ra như string để bảo toàn format (nếu bạn muốn)
        writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
    }

}

public class NullableDecimalAsStringConverter : JsonConverter<decimal?>
{
    public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        if (reader.TokenType == JsonTokenType.Number)
            return reader.GetDecimal();

        var s = reader.GetString();
        if (string.IsNullOrWhiteSpace(s))
            return null;

        if (decimal.TryParse(s, NumberStyles.Number | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var result))
            return result;

        if (decimal.TryParse(s, NumberStyles.Number | NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, out result))
            return result;

        throw new JsonException($"Cannot convert \"{s}\" to System.Decimal.");
    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString(CultureInfo.InvariantCulture));
        else
            writer.WriteNullValue();
    }
}
