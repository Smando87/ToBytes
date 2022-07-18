using NUnit.Framework;
using ObjectSerializer;
using System;
using System.Collections.Generic;
using ToBytes.Cache;

namespace ToBytes.Tests
{
    public class SerializerTests
    {
        [Test]
        public void dictionary_struct_object()
        {
            Dictionary<int, DummyObject>? obj = new()
            {
                {
                    1, new DummyObject
                    {
                        Integer = 1
                    }
                },
                {
                    3, new DummyObject
                    {
                        Integer = 2
                    }
                }
            };
            byte[]? bytes = obj.ToBytes();
            Dictionary<int, DummyObject>? obj2 = bytes.FromBytes<Dictionary<int, DummyObject>>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void dictionary_struct_struct()
        {
            Dictionary<int, int>? obj = new()
            {
                {
                    1, 2
                },
                {
                    3, 4
                }
            };
            byte[]? bytes = obj.ToBytes();
            Dictionary<int, int>? obj2 = bytes.FromBytes<Dictionary<int, int>>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void object_date_time()
        {
            DummyObject3? obj = new()
            {
                DateTime = DateTime.Now
            };
            Console.WriteLine(obj);
            byte[]? bytes = obj.ToBytes();
            DummyObject3? obj2 = bytes.FromBytes<DummyObject3>();
            Console.WriteLine(obj2);
            Assert.AreEqual(obj.DateTime, obj2.DateTime);
            Assert.Pass();
        }


        [Test]
        public void object_dummy()
        {
            DummyObject? obj = new()
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
            byte[]? bytes = obj.ToBytes();
            Console.WriteLine(bytes.Length);
            //Assert.AreEqual(bytes.Length, 30);
            DummyObject? obj2 = bytes.FromBytes<DummyObject>();
            Assert.AreEqual(obj, obj2);
            Assert.Pass();
        }

        [Test]
        public void object_list_dummy()
        {
            List<DummyObject>? obj = new();
            obj.Add(new DummyObject
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
            });
            obj.Add(new DummyObject
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
            });
            Console.WriteLine(obj);
            byte[]? bytes = obj.ToBytes();
            List<DummyObject>? obj2 = bytes.FromBytes<List<DummyObject>>();
            Console.WriteLine(obj2);
            Assert.AreEqual(obj, obj2);
            Assert.Pass();
        }

        [Test]
        public void object_list_dummy_full()
        {
            List<DummyObject3>? obj = new();
            obj.Add(new DummyObject3
            {
                DateTime = DateTime.Now
            });
            obj.Add(new DummyObject3
            {
                DateTime = DateTime.Now
            });
            Console.WriteLine(obj);
            byte[]? bytes = obj.ToBytes();
            List<DummyObject3>? obj2 = bytes.FromBytes<List<DummyObject3>>();
            Console.WriteLine(obj2);
            Assert.AreEqual(obj, obj2);
            Assert.Pass();
        }

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void struct_array_int()
        {
            int[] obj =
            {
                1, 2, 3, 4, 5
            };
            Console.WriteLine(obj);
            byte[]? bytes = obj.ToBytes();
            Assert.AreEqual(bytes.Length, 28);
            int[]? obj2 = bytes.FromBytes<int[]>();
            Console.WriteLine(obj2);
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_array_multi_int()
        {
            int[,,] obj =
            {
                {
                    {
                        1, 2
                    },
                    {
                        3, 4
                    }
                },
                {
                    {
                        5, 6
                    },
                    {
                        7, 8
                    }
                }
            };
            byte[]? bytes = obj.ToBytes();
            int[,,]? obj2 = bytes.FromBytes<int[,,]>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_bool()
        {
            bool obj = true;
            byte[]? bytes = obj.ToBytes();
            bool obj2 = bytes.FromBytes<bool>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_byte()
        {
            byte obj = 1;
            byte[]? bytes = obj.ToBytes();
            byte obj2 = bytes.FromBytes<byte>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_char()
        {
            char obj = 'c';
            byte[]? bytes = obj.ToBytes();
            char obj2 = bytes.FromBytes<char>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_custom()
        {
            DateTime obj = DateTime.Now;
            Console.WriteLine(obj);
            byte[]? bytes = obj.ToBytes();
            DateTime obj2 = bytes.FromBytes<DateTime>();
            Console.WriteLine(obj2);
            Assert.AreEqual(obj, obj2);
            Assert.Fail();
        }


        [Test]
        public void struct_date_time()
        {
            DateTime obj = DateTime.Now;
            Console.WriteLine(obj);
            byte[]? bytes = obj.ToBytes();
            DateTime obj2 = bytes.FromBytes<DateTime>();
            Console.WriteLine(obj2);
            Assert.AreEqual(obj, obj2);
            Assert.Pass();
        }

        [Test]
        public void struct_date_time_null()
        {
            DateTime? obj = null;
            Console.WriteLine(obj);
            byte[]? bytes = obj.ToBytes();
            DateTime? obj2 = bytes.FromBytes<DateTime?>();
            Console.WriteLine(obj2);
            Assert.AreEqual(obj, obj2);
            Assert.Pass();
        }

        [Test]
        public void struct_datetime()
        {
            DateTime obj = DateTime.Now;
            byte[]? bytes = obj.ToBytes();
            DateTime obj2 = bytes.FromBytes<DateTime>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_decimal()
        {
            decimal obj = 1.2m;
            byte[]? bytes = obj.ToBytes();
            decimal obj2 = bytes.FromBytes<decimal>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_double()
        {
            double obj = 1.2;
            byte[]? bytes = obj.ToBytes();
            double obj2 = bytes.FromBytes<double>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_float()
        {
            float obj = 1.2f;
            byte[]? bytes = obj.ToBytes();
            float obj2 = bytes.FromBytes<float>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_guid()
        {
            Guid obj = Guid.NewGuid();
            byte[]? bytes = obj.ToBytes();
            Guid obj2 = bytes.FromBytes<Guid>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_int()
        {
            int obj = 1;
            byte[]? bytes = obj.ToBytes();
            int obj2 = bytes.FromBytes<int>();
            Assert.AreEqual(obj, obj2);
        }


        [Test]
        public void struct_list_int()
        {
            List<int> obj = new()
            {
                1,
                2,
                3,
                4,
                5
            };
            byte[]? bytes = obj.ToBytes();
            List<int>? obj2 = bytes.FromBytes<List<int>>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_list_multi_int()
        {
            List<List<int>> obj = new()
            {
                new List<int>()
                {
                    1,
                    2
                },
                new List<int>()
                {
                    3,
                    4
                }
            };
            byte[]? bytes = obj.ToBytes();
            List<List<int>>? obj2 = bytes.FromBytes<List<List<int>>>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_list_multi_object()
        {
            List<List<DummyObject>> obj = new()
            {
                new()
                {
                    new DummyObject()
                    {
                        Integer = 1
                    }
                },
                new()
                {
                    new DummyObject()
                    {
                        Integer = 2
                    }
                }
            };
            byte[]? bytes = obj.ToBytes();
            List<List<DummyObject>>? obj2 = bytes.FromBytes<List<List<DummyObject>>>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_short()
        {
            short obj = 1;
            byte[]? bytes = obj.ToBytes();
            short obj2 = bytes.FromBytes<short>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_string()
        {
            string obj = "string";
            byte[]? bytes = obj.ToBytes();
            string? obj2 = bytes.FromBytes<string>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_string_null()
        {
            string obj = null;
            byte[]? bytes = obj.ToBytes();
            string? obj2 = bytes.FromBytes<string>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_timespan()
        {
            TimeSpan obj = TimeSpan.MaxValue;
            byte[]? bytes = obj.ToBytes();
            TimeSpan obj2 = bytes.FromBytes<TimeSpan>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_uint()
        {
            uint obj = 1;
            byte[]? bytes = obj.ToBytes();
            uint obj2 = bytes.FromBytes<uint>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_uint_null()
        {
            uint? obj = null;
            byte[]? bytes = obj.ToBytes();
            uint? obj2 = bytes.FromBytes<uint?>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_ulong()
        {
            ulong obj = 1;
            byte[]? bytes = obj.ToBytes();
            ulong obj2 = bytes.FromBytes<ulong>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_ulong_null()
        {
            ulong? obj = null;
            byte[]? bytes = obj.ToBytes();
            ulong? obj2 = bytes.FromBytes<ulong?>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void struct_ushort()
        {
            ushort obj = 1;
            byte[]? bytes = obj.ToBytes();
            ushort obj2 = bytes.FromBytes<ushort>();
            Assert.AreEqual(obj, obj2);
        }


        [Test]
        public void struct_ushort_null()
        {
            ushort? obj = null;
            byte[]? bytes = obj.ToBytes();
            ushort? obj2 = bytes.FromBytes<ushort?>();
            Assert.AreEqual(obj, obj2);
        }

        [Test]
        public void TestReflectionDelegate()
        {
            DummyObject? obj = new()
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
                String2 = "string2"
            };
            DummyObject? obj2 = new()
            {
                //DummyObjectC = new DummyObject() {Integer = 1},
                Integer = 1,
                Integer2 = 3,
                Float = 1.2f,
                FloatN = null,
                Decimal = 1.3m,
                Byte = 6,
                Char = 'c',
                Short = 7,
                Bool = true,
                String = "string",
                String2 = "string2"
            };

            IPropertyCallAdapter<DummyObject>? ist = PropertyCallAdapterProvider<DummyObject>.GetInstance("Integer");
            object? val = ist?.InvokeGet(obj);

            IPropertyCallAdapter<DummyObject>? ist2 = PropertyCallAdapterProvider<DummyObject>.GetInstance("Integer");
            object? val2 = ist2?.InvokeGet(obj.ZDummyObjectC);
            Assert.AreEqual(val2, 1);
            Assert.AreEqual(val, 10);
            Assert.Pass();
        }
    }
}