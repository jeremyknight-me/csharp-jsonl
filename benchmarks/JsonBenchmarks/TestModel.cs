namespace JsonBenchmarks;

internal sealed class TestModel
{
    public bool One { get; set; }
    public bool? OneNullable { get; set; }
    public string Two { get; set; } = string.Empty;
    public string? TwoNullable { get; set; }
    public DateOnly Three { get; set; }
    public DateOnly? ThreeNullable { get; set; }
    public int Four { get; set; }
    public int? FourNullable { get; set; }
    public decimal Five { get; set; }
    public decimal? FiveNullable { get; set; }
}
