using Newtonsoft.Json;
using NUnit.Framework;
using ObjectSerializer;
using System;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ToBytes.Tests
{
    public class SizeTests
    {
        [Test]
        public void size_comparison()
        {
            DummyObject? obj = new DummyObject
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

            byte[]? tobytesMethod = obj.ToBytes();
            byte[]? dotnetJson = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
            byte[]? newtonSoftJson = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
            Console.WriteLine($"dotnetJson: {dotnetJson.Length}");
            Console.WriteLine($"newtonSoftJson: {newtonSoftJson.Length}");
            Console.WriteLine($"tobytesMethod: {tobytesMethod.Length}");
            Assert.Less(tobytesMethod.Length, dotnetJson.Length);
            Assert.Less(tobytesMethod.Length, newtonSoftJson.Length);
        }

        [Test]
        public void test_sizes()
        {
            Console.WriteLine("short: " + sizeof(short));
            Console.WriteLine("int: " + sizeof(int));
            Console.WriteLine("long: " + sizeof(long));
            Console.WriteLine("float: " + sizeof(float));
            Console.WriteLine("double: " + sizeof(double));
            Console.WriteLine("decimal: " + sizeof(decimal));
            Console.WriteLine("bool: " + sizeof(bool));
            Console.WriteLine("char: " + sizeof(char));
        }
    }
}