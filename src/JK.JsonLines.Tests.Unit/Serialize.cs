using JK.JsonLines.Tests.Unit.TestUtils;

namespace JK.JsonLines.Tests.Unit;

public class Serialize : TestBase
{
    [Fact]
    public void EmptyEnumerable_ReturnsEmptyString()
    {
        IEnumerable<TestModel> values = Array.Empty<TestModel>();
        string result = JsonLinesSerializer.Serialize(values, Options);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void SingleValue_ReturnsJsonLine()
    {
        IEnumerable<TestModel> values =
        [
            new TestModel
            {
                One = true,
                Two = "value",
                Three = new DateTime(2020, 1, 2),
                Four = 7,
                Five = 1.2m
                // nullable properties intentionally left null
            }
        ];

        string result = JsonLinesSerializer.Serialize(values, Options);
        string expected =
            """
            {"one":true,"two":"value","three":"2020-01-02","four":7,"five":1.2}
            """;
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MultipleValues_ReturnsJsonLines()
    {
        IEnumerable<TestModel> values =
        [
            new TestModel { One = true, Two = "a", Three = new DateTime(2020,1,1), Four = 1, Five = 1.0m },
            new TestModel { One = false, Two = "b", Three = new DateTime(2020, 2, 2), Four = 2, Five = 2.0m },
            new TestModel { One = true, Two = "c", Three = new DateTime(2020, 3, 3), Four = 3, Five = 3.0m }
        ];

        string result = JsonLinesSerializer.Serialize(values, Options);
        string expected =
            """
            {"one":true,"two":"a","three":"2020-01-01","four":1,"five":1.0}
            {"one":false,"two":"b","three":"2020-02-02","four":2,"five":2.0}
            {"one":true,"two":"c","three":"2020-03-03","four":3,"five":3.0}
            """;
        Assert.Equal(expected, result);
    }

    [Fact]
    public void NullValues_ThrowsArgumentNullException()
    {
        IEnumerable<TestModel>? values = null;
        Assert.Throws<ArgumentNullException>(() => JsonLinesSerializer.Serialize(values!));
    }
}
