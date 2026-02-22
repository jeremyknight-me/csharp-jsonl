using System.Text.Json;
using System.Text.Json.Serialization;

namespace JK.JsonLines.Tests.Unit.TestUtils;

internal sealed class DateTimeFormatJsonConverter : JsonConverter<DateTime>
{
    private const string format = "yyyy-MM-dd";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString(), format, null);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(format));
    }
}

internal sealed class DateTimeNullableFormatJsonConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return value is null
            ? null
            : DateTime.ParseExact(value, "yyyy-MM-dd", null);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStringValue($"{value:yyyy-MM-dd}");
        }
    }
}
