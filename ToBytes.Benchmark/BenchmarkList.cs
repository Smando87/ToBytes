using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using ObjectSerializer;
using System.Collections.Generic;
using ToBytes;

[SimpleJob(RuntimeMoniker.Net50)]
[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkList
{
    private List<int> list;
    private List<DummyObject> listObj;

    [GlobalSetup]
    public void Setup()
    {
        list = new List<int>();
        for (int i = 0; i < 10000; i++)
        {
            list.Add(i);
        }

        listObj = new List<DummyObject>();
        for (int i = 0; i < 10000; i++)
        {
            listObj.Add(new DummyObject
            {
                Integer = i
            });
        }
    }

    [Benchmark(Description = "StructToBytes", Baseline = true)]
    public void ToBytes()
    {
        byte[]? data = list.ToBytes();
    }

    // [Benchmark(Description = "StructToJsonDotnet")]
    // public void ToJsonDotnet()
    // {
    //     var data = JsonSerializer.Serialize(list);
    // }
    //
    // [Benchmark(Description = "StructToJsonNewtonSoft")]
    // public void ToJsonNewtonSoft()
    // {
    //     var data = Newtonsoft.Json.JsonConvert.SerializeObject(list);
    // }
    //
    // [Benchmark(Description = "ObjectToBytes")]
    // public void ObjectToBytes()
    // {
    //     var data = listObj.ToBytes();
    // }
    //
    // [Benchmark(Description = "ObjectToJsonDotnet")]
    // public void ObjectToJsonDotnet()
    // {
    //     var data = JsonSerializer.Serialize(listObj);
    // }
    //
    // [Benchmark(Description = "ObjecttToJsonNewtonSoft")]
    // public void ObjectToJsonNewtonSoft()
    // {
    //     var data = Newtonsoft.Json.JsonConvert.SerializeObject(listObj);
    // }
}