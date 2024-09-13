using System.Text.Json.Serialization;
using TestTaskSitek.converter;

namespace TestTaskSitek.entity;

public class Version : IComparable<Version>
{
    [JsonPropertyName("VersionId")] public int Id { get; set; }

    [JsonPropertyName("TextVersion")] public string Text { get; set; } = "";

    public string FiasCompleteDbfUrl { get; set; } = "";
    public string FiasCompleteXmlUrl { get; set; } = "";
    public string FiasDeltaDbfUrl { get; set; } = "";
    public string FiasDeltaXmlUrl { get; set; } = "";
    public string Kladr4ArjUrl { get; set; } = "";
    public string Kladr47ZUrl { get; set; } = "";

    [JsonPropertyName("GarXMLFullURL")] public string GarXmlFullUrl { get; set; } = "";

    [JsonPropertyName("GarXMLDeltaURL")] public string GarXmlDeltaUrl { get; set; } = "";

    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime ExpDate { get; set; } = DateTime.MinValue;

    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime Date { get; set; } = DateTime.MinValue;

    public int CompareTo(Version? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        var expDateComparison = ExpDate.CompareTo(other.ExpDate);
        if (expDateComparison != 0) return expDateComparison;
        return Id.CompareTo(other.Id);
    }
}