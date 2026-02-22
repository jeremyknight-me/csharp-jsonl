using System.Text.Json;
using System.Text.Json.Serialization;

namespace JK.JsonLines.Tests.Unit;

public abstract class TestBase
{
    protected static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = false
    };
}
