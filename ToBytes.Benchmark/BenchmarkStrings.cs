using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Generic;
using ToBytes;

[SimpleJob(RuntimeMoniker.Net50)]
[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkStrings
{
    private List<byte> list;


    [Benchmark(Description = "union_string_to_bytes")]
    public void string_to_bytes()
    {
        string? val = "string";
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.Toint();
    }


    [Benchmark(Description = "union_string_to_bytes_unsafe")]
    public void string_to_bytes_unsafe()
    {
        string? val = "string";
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.TointUnsafe();
    }
}