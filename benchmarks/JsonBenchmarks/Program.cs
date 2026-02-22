using BenchmarkDotNet.Running;

namespace JsonBenchmarks;

internal sealed class Program
{
    private static void Main(string[] args)
        => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
}
