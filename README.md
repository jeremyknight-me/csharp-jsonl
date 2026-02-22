# JK.JsonLines

> NOTE: This repository is new and under active development. APIs and behavior may change — use at your own risk.

JK.JsonLines is a small .NET library for reading and writing JSON Lines (JSONL) using System.Text.Json. It provides simple helpers to serialize collections to JSONL and to deserialize JSONL content into sequences of typed objects.

## Features

- Built on `System.Text.Json`.
- Serialize an enumerable of objects into a JSONL string.
- Deserialize a JSONL string into an `IEnumerable<T>`.

## Roadmap (Planned Features)

- Add support for targeting .NET 8 and .NET 9 (multi-targeting / compatibility builds).
- `HttpClient` extensions to read/write JSONL payloads over HTTP easily.
- File I/O extensions for streaming read/write helpers (file-backed JSONL operations).

These items are planned and not yet implemented; contributions are welcome.

## Requirements

- .NET 10.0 SDK (net10.0)

## Quick usage

Serialize a collection to a JSONL string:

```csharp
using JK.JsonLines;
using System.Text.Json;

var items = new[] { new Person("Alice"), new Person("Bob") };
var jsonLines = JsonLinesSerializer.Serialize(items);
// write to file
File.WriteAllText("out.jsonl", jsonLines);

record Person(string Name);
```

Deserialize a JSONL string into typed objects:

```csharp
using JK.JsonLines;
using System.Text.Json;

var jsonl = File.ReadAllText("out.jsonl");
IEnumerable<Person> people = JsonLinesSerializer.Deserialize<Person>(jsonl);
foreach (var p in people) Console.WriteLine(p.Name);

record Person(string Name);
```

Both `Serialize<TValue>(IEnumerable<TValue>, JsonSerializerOptions? options = null)` and `Deserialize<TValue>(string, JsonSerializerOptions? options = null)` accept optional `JsonSerializerOptions` to customize serialization behavior.

## Development

Clone the repository and build the solution from the repository root:

```bash
dotnet build src/JsonLines.slnx
```

Run unit tests:

```bash
dotnet test src/JK.JsonLines.Tests.Unit -c Debug
```

Run benchmarks (BenchmarkDotNet):

```bash
dotnet run -c Release --project benchmarks/JsonBenchmarks/JsonBenchmarks.csproj
```

### Project Layout

- `src` — main library sources and unit tests
- `benchmarks/` — BenchmarkDotNet projects

## Contributing

Contributions are welcome. Please open an issue first for larger changes. Follow the existing project coding style and include unit tests for new behavior.

## License

This project is licensed under the terms in the repository `LICENSE` file.
