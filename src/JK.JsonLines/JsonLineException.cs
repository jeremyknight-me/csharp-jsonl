namespace JK.JsonLines;

public class JsonLineException : Exception
{
    public JsonLineException(string line, string message)
        : base(message)
    {
        JsonLine = line;
    }

    public JsonLineException(string line, string message, Exception innerException)
        : base(message, innerException)
    {
        JsonLine = line;
    }

    public string JsonLine { get; }
}
