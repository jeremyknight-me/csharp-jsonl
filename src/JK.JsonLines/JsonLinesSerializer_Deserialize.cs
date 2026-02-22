using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace JK.JsonLines;

public static partial class JsonLinesSerializer
{
    //internal static object? Deserialize([StringSyntax(StringSyntaxAttribute.Json)] ReadOnlySpan<char> json, JsonTypeInfo jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static object? Deserialize([StringSyntax(StringSyntaxAttribute.Json)] ReadOnlySpan<char> json, Type returnType, JsonSerializerContext context)
    //{
    //    ArgumentNullException.ThrowIfNull(returnType);
    //    ArgumentNullException.ThrowIfNull(context);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static object? Deserialize([StringSyntax(StringSyntaxAttribute.Json)] ReadOnlySpan<char> json, Type returnType, JsonSerializerOptions? options = null)
    //{
    //    ArgumentNullException.ThrowIfNull(returnType);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static object? Deserialize(Stream utf8Json, JsonTypeInfo jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static object? Deserialize(Stream utf8Json, Type returnType, JsonSerializerContext context)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(returnType);
    //    ArgumentNullException.ThrowIfNull(context);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static object? Deserialize(Stream utf8Json, Type returnType, JsonSerializerOptions? options = null)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(returnType);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static object? Deserialize([StringSyntax(StringSyntaxAttribute.Json)] string json, JsonTypeInfo jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(json);
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static object? Deserialize([StringSyntax(StringSyntaxAttribute.Json)] string json, Type returnType, JsonSerializerContext context)
    //{
    //    ArgumentNullException.ThrowIfNull(json);
    //    ArgumentNullException.ThrowIfNull(returnType);
    //    ArgumentNullException.ThrowIfNull(context);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static object? Deserialize([StringSyntax(StringSyntaxAttribute.Json)] string json, Type returnType, JsonSerializerOptions? options = null)
    //{
    //    ArgumentNullException.ThrowIfNull(json);
    //    ArgumentNullException.ThrowIfNull(returnType);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static TValue? Deserialize<TValue>([StringSyntax(StringSyntaxAttribute.Json)] ReadOnlySpan<char> json, JsonSerializerOptions? options = null)
    //{
    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static TValue? Deserialize<TValue>([StringSyntax(StringSyntaxAttribute.Json)] ReadOnlySpan<char> json, JsonTypeInfo<TValue> jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static TValue? Deserialize<TValue>(Stream utf8Json, JsonSerializerOptions? options = null)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static TValue? Deserialize<TValue>(Stream utf8Json, JsonTypeInfo<TValue> jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    public static IEnumerable<TValue> Deserialize<TValue>([StringSyntax(StringSyntaxAttribute.Json)] string json, JsonSerializerOptions? options = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(json);
        return DeserializeIterator<TValue>(json, options);
    }

    private static IEnumerable<TValue> DeserializeIterator<TValue>(string json, JsonSerializerOptions? options)
    {
        var lines = json.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
        foreach (var line in lines)
        {
            TValue? obj = JsonSerializer.Deserialize<TValue>(line, options);
            if (obj is null)
            {
                throw new JsonLineException(line, "JSONL deserialized to null string.");
            }

            yield return obj;
        }
    }

    //internal static TValue? Deserialize<TValue>([StringSyntax(StringSyntaxAttribute.Json)] string json, JsonTypeInfo<TValue> jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(json);
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static ValueTask<object?> DeserializeAsync(Stream utf8Json, JsonTypeInfo jsonTypeInfo, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static ValueTask<object?> DeserializeAsync(Stream utf8Json, Type returnType, JsonSerializerContext context, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(returnType);
    //    ArgumentNullException.ThrowIfNull(context);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static ValueTask<object?> DeserializeAsync(Stream utf8Json, Type returnType, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(returnType);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static ValueTask<TValue?> DeserializeAsync<TValue>(Stream utf8Json, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static ValueTask<TValue?> DeserializeAsync<TValue>(Stream utf8Json, JsonTypeInfo<TValue> jsonTypeInfo, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static IAsyncEnumerable<TValue?> DeserializeAsyncEnumerable<TValue>(Stream utf8Json, bool topLevelValues, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static IAsyncEnumerable<TValue?> DeserializeAsyncEnumerable<TValue>(Stream utf8Json, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    //{
    //    return DeserializeAsyncEnumerable<TValue>(utf8Json, topLevelValues: false, options, cancellationToken);
    //}

    //internal static IAsyncEnumerable<TValue?> DeserializeAsyncEnumerable<TValue>(Stream utf8Json, JsonTypeInfo<TValue> jsonTypeInfo, bool topLevelValues, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static IAsyncEnumerable<TValue?> DeserializeAsyncEnumerable<TValue>(Stream utf8Json, JsonTypeInfo<TValue> jsonTypeInfo, CancellationToken cancellationToken = default)
    //{
    //    return DeserializeAsyncEnumerable(utf8Json, jsonTypeInfo, topLevelValues: false, cancellationToken);
    //}
}
