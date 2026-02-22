using System.Text;
using System.Text.Json;

namespace JK.JsonLines;

public static partial class JsonLinesSerializer
{
    //internal static string Serialize(object? value, JsonTypeInfo jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static string Serialize(object? value, Type inputType, JsonSerializerContext context)
    //{
    //    ArgumentNullException.ThrowIfNull(context);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static string Serialize(object? value, Type inputType, JsonSerializerOptions? options = null)
    //{
    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    public static string Serialize<TValue>(IEnumerable<TValue> values, JsonSerializerOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(values, nameof(values));

        System.Buffers.ArrayBufferWriter<byte> buffer = new();
        var newLineBytes = Encoding.UTF8.GetBytes(Environment.NewLine);
        foreach (TValue value in values)
        {
            byte[] itemBytes = JsonSerializer.SerializeToUtf8Bytes(value, options);

            // Append the item bytes.
            Span<byte> span = buffer.GetSpan(itemBytes.Length);
            itemBytes.CopyTo(span);
            buffer.Advance(itemBytes.Length);

            // Append a newline.
            span = buffer.GetSpan(newLineBytes.Length);
            newLineBytes.CopyTo(span);
            buffer.Advance(newLineBytes.Length);
        }

        if (buffer.WrittenCount == 0)
        {
            return string.Empty;
        }

        ReadOnlySpan<byte> written = buffer.WrittenMemory.Span.Slice(0, buffer.WrittenCount - newLineBytes.Length);
        return Encoding.UTF8.GetString(written);
    }

    //internal static string Serialize<TValue>(TValue value, JsonTypeInfo<TValue> jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static Task SerializeAsync(PipeWriter utf8Json, object? value, JsonTypeInfo jsonTypeInfo, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static Task SerializeAsync(PipeWriter utf8Json, object? value, Type inputType, JsonSerializerContext context, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(context);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static Task SerializeAsync(PipeWriter utf8Json, object? value, Type inputType, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static Task SerializeAsync<TValue>(PipeWriter utf8Json, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static Task SerializeAsync<TValue>(PipeWriter utf8Json, TValue value, JsonTypeInfo<TValue> jsonTypeInfo, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(utf8Json);
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static byte[] SerializeToUtf8Bytes(object? value, JsonTypeInfo jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static byte[] SerializeToUtf8Bytes(object? value, Type inputType, JsonSerializerContext context)
    //{
    //    ArgumentNullException.ThrowIfNull(context);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static byte[] SerializeToUtf8Bytes(object? value, Type inputType, JsonSerializerOptions? options = null)
    //{
    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static byte[] SerializeToUtf8Bytes<TValue>(TValue value, JsonSerializerOptions? options = null)
    //{
    //    // todo: implement
    //    throw new NotImplementedException();
    //}

    //internal static byte[] SerializeToUtf8Bytes<TValue>(TValue value, JsonTypeInfo<TValue> jsonTypeInfo)
    //{
    //    ArgumentNullException.ThrowIfNull(jsonTypeInfo);

    //    // todo: implement
    //    throw new NotImplementedException();
    //}
}
