using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using Bogus;

namespace JsonBenchmarks;

[MemoryDiagnoser]
public class SerializeBenchmarks
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = false
    };

    private List<TestModel> _values = [];

    [Params(100, 1_000, 10_000)]
    public int ItemCount;

    [GlobalSetup]
    public void Setup()
    {
        Randomizer.Seed = new Random(1337);
        var faker = new Faker<TestModel>()
            .RuleFor(m => m.One, f => f.Random.Bool())
            .RuleFor(m => m.Two, f => f.Random.String(10))
            .RuleFor(m => m.Three, f => f.Date.RecentDateOnly())
            .RuleFor(m => m.Four, f => f.Random.Int())
            .RuleFor(m => m.Five, f => f.Random.Decimal());
        _values = faker.Generate(ItemCount);
    }

    [Benchmark(Baseline = true)]
    public string StringBuilder()
    {
        StringBuilder builder = new();
        foreach (TestModel value in _values)
        {
            var json = JsonSerializer.Serialize(value, _options);
            builder.AppendLine(json);
        }

        return builder.ToString().TrimEnd(['\r', '\n']);
    }

    [Benchmark]
    public string ArrayBuffer()
    {
        // Use a pooled byte buffer to avoid allocating a string per item.
        System.Buffers.ArrayBufferWriter<byte> buffer = new();

        // Prepare the platform newline bytes once to preserve Environment.NewLine behavior.
        var newLineBytes = Encoding.UTF8.GetBytes(Environment.NewLine);

        foreach (TestModel value in _values)
        {
            // Serialize each item independently to UTF-8 bytes to avoid reusing a single Utf8JsonWriter.
            byte[] itemBytes = JsonSerializer.SerializeToUtf8Bytes(value, _options);

            // Append the item bytes.
            Span<byte> span = buffer.GetSpan(itemBytes.Length);
            itemBytes.CopyTo(span);
            buffer.Advance(itemBytes.Length);

            // Append a newline.
            span = buffer.GetSpan(newLineBytes.Length);
            newLineBytes.CopyTo(span);
            buffer.Advance(newLineBytes.Length);
        }

        // If nothing was written, return empty string.
        if (buffer.WrittenCount == 0)
        {
            return string.Empty;
        }

        // Exclude the final newline added after the last record.
        ReadOnlySpan<byte> written = buffer.WrittenMemory.Span.Slice(0, buffer.WrittenCount - newLineBytes.Length);
        return Encoding.UTF8.GetString(written);
    }
}
