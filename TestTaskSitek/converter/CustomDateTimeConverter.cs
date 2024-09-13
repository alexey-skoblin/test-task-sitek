using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestTaskSitek.converter;

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    public override void Write(Utf8JsonWriter writer, DateTime date, JsonSerializerOptions options)
    {
        writer.WriteStringValue(DateTimeFormatter.ToDateString(date));
    }

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTimeFormatter.FromDateString(reader.GetString()!);
    }
}