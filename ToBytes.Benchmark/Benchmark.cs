using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Newtonsoft.Json;
using ObjectSerializer;
using System;
using System.Collections.Generic;
using ToBytes;
using JsonSerializer = System.Text.Json.JsonSerializer;

[SimpleJob(RuntimeMoniker.Net50)]
[RPlotExporter]
[MemoryDiagnoser]
public class Benchmark
{
    private List<byte> list;

    public static DummyObject obj { get; set; }

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

        obj = new DummyObject
        {
            ZDummyObjectC = new DummyObject
            {
                Integer = 1
            },
            Integer = 10,
            Integer2 = 3,
            Float = 1.2f,
            FloatN = null,
            Decimal = 1.3m,
            Byte = 6,
            Char = 'c',
            Short = 7,
            Bool = true,
            String = "string",
            String2 = "string2",
            DateTime = DateTime.Now,
            TimeSpan = TimeSpan.MaxValue,
            Guid = Guid.NewGuid()
        };
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

    // [Benchmark]
    // public void ListToArray()
    // {
    //     list.ToArray();
    // }
    //
    // [Benchmark]
    // public void ListToArray3()
    // {
    //     var arr = new byte[list.Count];
    //     list.CopyTo(arr, 0);
    // }
    //
    // [Benchmark]
    // public void ListToArray4()
    // {
    //     var arr = new byte[list.Count];
    //     for (int i = 0; i < list.Count; i++)
    //     {
    //         arr[i] = list[i];
    //     }
    // }


    // [Benchmark]
    // public void ArrayAdd()
    // {
    //     var array = new byte[10000];
    //     for (int i = 0; i < array.Length; i++)
    //     {
    //         array[i] = (byte) i;
    //     }
    // }
    //
    //
    // [Benchmark]
    // public void ListAdd()
    // {
    //     var list = new List<byte>();
    //     for (int i = 0; i < 10000; i++)
    //     {
    //         list.Add((byte) i);
    //     }
    //     var arr = list.ToArray();
    // }
    //
    //  [Benchmark]
    //  public void GetProperties()
    //  {
    //      var props = TypeDescriptor.GetProperties(obj).Sort();
    //  }
    //
    //  [Benchmark]
    //  public void GetProperties2()
    //  {
    // https://github.com/chaquotay/PropertyAccess/tree/master/src/PropertyAccess
    //      var props = obj.GetType().GetProperties().OrderBy(ff=>ff.Name);
    //  }

    // [Benchmark]
    // public void GetPropertiyValue()
    // {
    //     obj.GetType().GetProperty("Integer").GetValue(obj, null);
    // }
    //
    // [Benchmark]
    // public void GetPropertiyValue2()
    // {
    //     typeof(DummyObject).GetProperty("Integer").GetValue(obj, null);
    // } 
    // [Benchmark]
    // public void GetPropertiyValue3()
    // {
    //     PropertyCallAdapterProvider<DummyObject>.GetInstance("Integer").InvokeGet(obj);
    // }
    // [Benchmark]
    // public void StringToBytes()
    // {
    //     var str = "string";
    //     var bytes = Encoding.UTF8.GetBytes(str);
    // }
    //
    // [Benchmark]
    // public void StringToBytes2()
    // {
    //     var str = "string";
    //     var bytes = new byte[str.Length];
    //     unsafe
    //     {
    //         fixed (void* ptr = str)
    //         {
    //             System.Runtime.InteropServices.Marshal.Copy(new IntPtr(ptr), bytes, 0, str.Length);
    //         }
    //     }

    /*
     * fixed (byte* bptr = tempByte)
{
char* cptr = (char*)(bptr + offset);
tempText = new string(cptr, 0, len / 2);
}
     */
    //}

    // [Benchmark]
    // public void IntToBytes()
    // {
    //     var val = 10;
    //     var len = 4;
    //     var bytes = new byte[len];
    //     unsafe
    //     {
    //         int* ptr = &val;
    //         System.Runtime.InteropServices.Marshal.Copy(new IntPtr(ptr), bytes, 0, len);
    //     }
    // }
    //
    // [Benchmark]
    // public void IntToBytes2()
    // {
    //     var val = 10;
    //     var intUnion = new IntUnion();
    //     var len = 4;
    //     var bytes = new byte[len];
    //     intUnion.value = val;
    //     bytes = new byte[] {intUnion.byte0, intUnion.byte1, intUnion.byte2, intUnion.byte3};
    // }
    //
}