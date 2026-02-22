using System.Text.Json.Serialization;

namespace JK.JsonLines.Tests.Unit.TestUtils;

internal sealed class TestModel
{
    public bool One { get; set; }
    public bool? OneNullable { get; set; }
    public string Two { get; set; } = string.Empty;
    public string? TwoNullable { get; set; }

    [JsonConverter(typeof(DateTimeFormatJsonConverter))]
    public DateTime Three { get; set; }

    [JsonConverter(typeof(DateTimeNullableFormatJsonConverter))]
    public DateTime? ThreeNullable { get; set; }

    public int Four { get; set; }
    public int? FourNullable { get; set; }
    public decimal Five { get; set; }
    public decimal? FiveNullable { get; set; }
}
