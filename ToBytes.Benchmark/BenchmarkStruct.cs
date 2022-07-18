using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Newtonsoft.Json;
using System.Collections.Generic;
using ToBytes;
using JsonSerializer = System.Text.Json.JsonSerializer;

[SimpleJob(RuntimeMoniker.Net50)]
[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkStruct
{
    private List<byte> list;

    public static int[] obj { get; set; }
    // [Benchmark(Description = "BinaryFormatter")]
    // public void BinaryFormatter()
    // {
    //     BinaryFormatter bf = new BinaryFormatter();
    //     using (MemoryStream ms = new MemoryStream())
    //     {
    //         bf.Serialize(ms, obj);
    //         var data =  ms.ToArray();
    //     }
    // }

    [GlobalSetup]
    public void Setup()
    {
        list = new List<byte>();
        //for (var i = 0; i < 10000; i++) list.Add((byte) i);

        obj = new int[10000];
        for (int i = 0; i < 10000; i++)
        {
            obj[i] = i;
        }
    }

    [Benchmark(Description = "ToBytes", Baseline = true)]
    public void ToBytes()
    {
        byte[]? data = obj.ToBytes();
        //var obj2 = metadata.Data.FromBytes<DummyObject>();
    }

    [Benchmark(Description = "ToJsonDotnet")]
    public void ToJsonDotnet()
    {
        string? data = JsonSerializer.Serialize(obj);
        //var obj2 = JsonSerializer.Deserialize<DummyObject>(metadata);
    }

    [Benchmark(Description = "ToJsonNewtonSoft")]
    public void ToJsonNewtonSoft()
    {
        string? data = JsonConvert.SerializeObject(obj);
        //var obj2 = JsonSerializer.Deserialize<DummyObject>(metadata);
    }
}