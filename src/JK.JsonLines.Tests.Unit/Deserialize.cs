using JK.JsonLines.Tests.Unit.TestUtils;

namespace JK.JsonLines.Tests.Unit;

public class Deserialize : TestBase
{
    [Fact]
    public void SingleValue_ReturnsValue()
    {
        string json =
            """
            {"one":true,"two":"value","three":"2020-01-02","four":7,"five":1.2}
            """;

        IEnumerable<TestModel> result = JsonLinesSerializer.Deserialize<TestModel>(json, Options);

        TestModel model = Assert.Single(result);
        Assert.True(model.One);
        Assert.Null(model.OneNullable);
        Assert.Equal("value", model.Two);
        Assert.Null(model.TwoNullable);
        Assert.Equal(new DateTime(2020, 1, 2), model.Three);
        Assert.Null(model.ThreeNullable);
        Assert.Equal(7, model.Four);
        Assert.Null(model.FourNullable);
        Assert.Equal(1.2m, model.Five);
        Assert.Null(model.FiveNullable);
    }

    [Fact]
    public void MultipleValues_ReturnsValues()
    {
        string json =
            """
            {"one":true,"two":"a","three":"2020-01-01","four":1,"five":1.1}
            {"one":false,"two":"b","three":"2020-02-02","four":2,"five":2.2}
            {"one":true,"two":"c","three":"2020-03-03","four":3,"five":3.3}
            """;

        IEnumerable<TestModel> result = JsonLinesSerializer.Deserialize<TestModel>(json, Options);

        Assert.Collection(result,
            model =>
            {
                Assert.True(model.One);
                Assert.Null(model.OneNullable);
                Assert.Equal("a", model.Two);
                Assert.Null(model.TwoNullable);
                Assert.Equal(new DateTime(2020, 1, 1), model.Three);
                Assert.Null(model.ThreeNullable);
                Assert.Equal(1, model.Four);
                Assert.Null(model.FourNullable);
                Assert.Equal(1.1m, model.Five);
                Assert.Null(model.FiveNullable);
            },
            model =>
            {
                Assert.False(model.One);
                Assert.Null(model.OneNullable);
                Assert.Equal("b", model.Two);
                Assert.Null(model.TwoNullable);
                Assert.Equal(new DateTime(2020, 2, 2), model.Three);
                Assert.Null(model.ThreeNullable);
                Assert.Equal(2, model.Four);
                Assert.Null(model.FourNullable);
                Assert.Equal(2.2m, model.Five);
                Assert.Null(model.FiveNullable);
            },
            model =>
            {
                Assert.True(model.One);
                Assert.Null(model.OneNullable);
                Assert.Equal("c", model.Two);
                Assert.Null(model.TwoNullable);
                Assert.Equal(new DateTime(2020, 3, 3), model.Three);
                Assert.Null(model.ThreeNullable);
                Assert.Equal(3, model.Four);
                Assert.Null(model.FourNullable);
                Assert.Equal(3.3m, model.Five);
                Assert.Null(model.FiveNullable);
            });
    }

    [Fact]
    public void NullString_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => JsonLinesSerializer.Deserialize<TestModel>(null!, Options));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void WhitespaceString_ThrowsArgumentNullException(string? json)
    {
        _ = Assert.Throws<ArgumentException>(() => JsonLinesSerializer.Deserialize<TestModel>(json!, Options));
    }
}
