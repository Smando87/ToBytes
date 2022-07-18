using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using ObjectSerializer;
using System;
using System.Collections;
using System.Collections.Generic;

[SimpleJob(RuntimeMoniker.Net50)]
[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkDictionary
{
    private Dictionary<Type, object> _dictionary;
    private Hashtable _hashTable;
    private List<byte> list;

    [Benchmark(Description = "Dictionary")]
    public void Dictionary()
    {
        //_dictionary = new Dictionary<Type, object>();
        _dictionary.Add(typeof(DummyObject), new object());
        object obj = null;
        _dictionary.TryGetValue(typeof(DummyObject), out obj);
        _dictionary.Remove(typeof(DummyObject));
    }

    [Benchmark(Description = "Dictionary2")]
    public void Dictionary2()
    {
        //_dictionary = new Dictionary<Type, object>();
        _dictionary.Add(typeof(DummyObject), new object());
        object obj = null;
        if (_dictionary.ContainsKey(typeof(DummyObject)))
        {
            obj = _dictionary[typeof(DummyObject)];
        }

        _dictionary.Remove(typeof(DummyObject));
    }

    [Benchmark(Description = "Hashtable")]
    public void Hashtable()
    {
        //_hashTable = new Hashtable();
        _hashTable.Add(typeof(DummyObject), new object());
        if (_hashTable.ContainsKey(typeof(DummyObject)))
        {
            object? obj = _hashTable[typeof(DummyObject)];
        }

        _hashTable.Remove(typeof(DummyObject));
    }

    [GlobalSetup]
    public void Setup()
    {
        _dictionary = new Dictionary<Type, object>();
        _hashTable = new Hashtable();
    }
}