using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[SimpleJob(RuntimeMoniker.Net50)]
[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkArray
{
    private int[] array;
    private List<int> list;

    // [Benchmark(Description = "array_int_to_bytes_span")]
    // public void array_int_to_bytes_span()
    // {
    //     
    //     ReadOnlySpan<int> span = new ReadOnlySpan<int>(array);
    //     ReadOnlySpan<byte> res = MemoryMarshal.Cast<int, byte>(span);
    //     var bytes = res.ToArray();
    //
    // }

    //Fastest
    [Benchmark(Description = "array_int_to_bytes_block")]
    public void array_int_to_bytes_block()
    {
        byte[] bytes = new byte[array.Length * sizeof(int)];
        Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);
    }

    [Benchmark(Description = "list_int_to_bytes_block")]
    public void list_int_to_bytes_block()
    {
        byte[] bytes = new byte[list.Count * sizeof(int)];
        Buffer.BlockCopy(list.ToArray(), 0, bytes, 0, list.Count);
    }

    [Benchmark(Description = "list_int_to_bytes_block_span")]
    public void list_int_to_bytes_block_span()
    {
        byte[] bytes = new byte[list.Count * sizeof(int)];
        Span<int> span = CollectionsMarshal.AsSpan(list);
        //ReadOnlySpan<int> span = new ReadOnlySpan<int>(list.);
        Buffer.BlockCopy(span.ToArray(), 0, bytes, 0, list.Count);
    }

    [Benchmark(Description = "lsit_int_to_bytes_span")]
    public void lsit_int_to_bytes_span()
    {
        byte[] bytes = null;
        Span<int> span = CollectionsMarshal.AsSpan(list);
        ReadOnlySpan<byte> res = MemoryMarshal.Cast<int, byte>(span);
        bytes = res.ToArray();
        //ReadOnlySpan<int> span = new ReadOnlySpan<int>(list.);
    }

    [GlobalSetup]
    public void Setup()
    {
        list = new List<int>();
        for (int i = 0; i < 10000; i++)
        {
            list.Add(i);
        }

        array = list.ToArray();
    }
    //
    // [Benchmark(Description = "array_int_to_bytes_union")]
    // public void array_int_to_bytes_union()
    // {
    //     byte[] bytes = new byte[array.Length * sizeof(int)];
    //     var index = 0;
    //     foreach (var i in array)
    //     {
    //         var bs = ConvertExtensions.ToBytes(i);
    //         Buffer.BlockCopy(bs, 0, bytes, index, bs.Length);
    //         index += sizeof(int);
    //     }
    // }
}