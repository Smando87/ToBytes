using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[SimpleJob(RuntimeMoniker.Net50)]
[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkUnion
{
    private List<byte> list;

    //
    // [Benchmark(Description = "union_int_to_bytes")]
    // public void int_to_bytes()
    // {
    //     var val = 1;
    //     var bytes = ConvertExtensions.ToBytes(val);
    //
    //     //var val2 = bytes.Toint();
    // }
    //
    //
    // [Benchmark(Description = "union_int_to_bytes_unsafe")]
    // public void int_to_bytes_unsafe()
    // {
    //     var val = 1;
    //     var bytes = val.ToBytesUnsafe();
    //
    //     //var val2 = bytes.TointUnsafe();
    // }
    //
    // [Benchmark(Description = "union_int_to_bytes2")]
    // public void int_to_bytes2()
    // {
    //     var val = 1;
    //     var bytes = ConvertExtensions.ToBytes2(val);
    //
    //     //var val2 = bytes.Toint();
    // }

    [Benchmark(Description = "union_int_to_bytes_span")]
    public void int_to_bytes3()
    {
        int val = 1;
        ReadOnlySpan<int> span = new(new int[1]
        {
            val
        });
        ReadOnlySpan<byte> res = MemoryMarshal.Cast<int, byte>(span);
        byte[]? bytes = res.ToArray();

        //var val2 = bytes.Toint();
    }
}