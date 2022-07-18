using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ToBytes.Converters
{
    public class ListTests
    {
        [Test]
        public void array()
        {
            int[]? array = new int[5]
            {
                1, 2, 3, 4, 5
            };
            Assert.IsTrue(array.GetType().IsArray());
            array.GetType().GetElementType();
            ReadOnlySpan<byte> res = MemoryMarshal.Cast<int, byte>(array);
            ReadOnlySpan<int> revert = MemoryMarshal.Cast<byte, int>(res);
            int[]? res1 = revert.ToArray();
            Assert.AreEqual(array, res1);
        }

        [Test]
        public void array_block()
        {
            int[]? array = new int[5]
            {
                1, 2, 3, 4, 5
            };
            Assert.IsTrue(array.GetType().IsArray());
            Type? elType = array.GetType().GetElementType();
            byte[] bytes = new byte[array.Length * sizeof(int)];
            Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);

            int[]? converted = new int[bytes.Length / sizeof(int)];
            Buffer.BlockCopy(bytes, 0, converted, 0, bytes.Length);
            //var res1 = revert.ToArray();
            Assert.AreEqual(array, converted);
        }

        [Test]
        public void array_block_generic_int()
        {
            int[]? array = new int[5]
            {
                1, 2, 3, 4, 5
            };
            Assert.IsTrue(array.GetType().IsArray());
            Type? elType = array.GetType().GetElementType();
            int elSize = Marshal.SizeOf(elType);
            byte[] bytes = new byte[array.Length * elSize];
            Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);
            int[]? converted = new int[bytes.Length / elSize];
            Buffer.BlockCopy(bytes, 0, converted, 0, bytes.Length);
            //var res1 = revert.ToArray();
            Assert.AreEqual(array, converted);
        }

        [Test]
        public void array_converter()
        {
            ArrayStructConverter? arrayConverter = new();
            //init data
            int[,] array =
            {
                {
                    1, 2
                },
                {
                    3, 4
                },
                {
                    5, 6
                },
                {
                    7, 8
                }
            };

            byte[]? bytes = arrayConverter.ToBytes(array);

            (var obj, int len) = arrayConverter.FromBytes(bytes, typeof(int));
            int[,]? converted = (int[,])obj;

            Assert.AreEqual(array, converted);
        }


        [Test]
        public void array_converter_1()
        {
            ArrayStructConverter? arrayConverter = new();
            //init data
            int[] array =
            {
                1, 2, 3, 4, 5
            };

            byte[]? bytes = arrayConverter.ToBytes(array);

            (var obj, int len) = arrayConverter.FromBytes(bytes, typeof(int));
            int[]? converted = (int[])obj;
            Assert.AreEqual(array, converted);
        }

        [Test]
        public void array_converter_3()
        {
            ArrayStructConverter? arrayConverter = new();
            //init data
            int[,,,] array =
            {
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
                }
            };

            byte[]? bytes = arrayConverter.ToBytes(array);

            (var obj, int len) = arrayConverter.FromBytes(bytes, typeof(int));
            int[,,,]? converted = (int[,,,])obj;

            Assert.AreEqual(array, converted);
        }

        [Test]
        public void array_generic()
        {
            int[]? array = new int[5]
            {
                1, 2, 3, 4, 5
            };
            Assert.IsTrue(array.GetType().IsArray());
            Type? elType = array.GetType().GetElementType();

            //var method1 = typeof(MemoryMarshal).GetMethod("Cast", new [] { typeof(byte), typeof(Span<>) });
            MethodInfo?
                method = typeof(MemoryMarshal)
                    .GetMethods()[2]; //("Cast", new [] { typeof(int), typeof(byte), typeof(Span<>) });
            //method = method.MakeGenericMethod(elType, typeof(byte), array.GetType());
            Type[]? args = method.GetGenericArguments();
            object? res1 = method.Invoke(null, new object[]
            {
                typeof(byte), array
            });
            // MemoryMarshal.Cast<>()
            ReadOnlySpan<byte> res = MemoryMarshal.Cast<int, byte>(array);
            //ReadOnlySpan<int> revert = MemoryMarshal.Cast<byte, int>(res);
            //var res1 = revert.ToArray();
            //Assert.AreEqual(array, res1);
        }

        [Test]
        public void array_multi_block_generic_int()
        {
            //init data
            int[,] arrayNative =
            {
                {
                    1, 2
                },
                {
                    3, 4
                },
                {
                    5, 6
                },
                {
                    7, 8
                }
            };

            //to bytes
            object obj = arrayNative;
            Array array = (Array)obj;
            Assert.IsTrue(array.GetType().IsArray());
            Type? elType = array.GetType().GetElementType();
            int elSize = Marshal.SizeOf(elType);
            int dimensions = array.Rank;
            byte[] bytes = new byte[array.Length * elSize];
            Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);
            List<byte> bytesTemp = new();
            byte[]? dimsArray = ConvertExtensions.ToBytes(dimensions);
            bytesTemp.AddRange(dimsArray);
            int[]? indices0 = new int[array.Rank];
            for (int i = 0; i < indices0.Length; i++)
            {
                bytesTemp.AddRange(ConvertExtensions.ToBytes(array.GetLength(i)));
            }

            bytesTemp.AddRange(bytes);
            byte[]? bytesFinal = bytesTemp.ToArray();


            //Revert back
            List<byte>? bytesToRevert = new(bytesFinal);
            int dimesRev = bytesToRevert.GetRange(0, 4).ToArray().ToInt();
            int index = sizeof(int);
            int[]? indices = new int[dimesRev];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = bytesToRevert.GetRange(index, 4).ToArray().ToInt();
                index += sizeof(int);
            }

            Array? converted = Array.CreateInstance(elType, indices);
            //var converted = new int[indices[0], indices[1]];
            Buffer.BlockCopy(bytesFinal, index, converted, 0, bytesFinal.Length - index);
            //var res1 = revert.ToArray();
            Assert.AreEqual(array, converted);
        }

        [Test]
        public void array2()
        {
        }


        [Test]
        public void dictionary()
        {
            Dictionary<int, int>? array = new();
            Assert.IsTrue(array.GetType().IsArray());
        }


        [Test]
        public void list()
        {
            List<int>? list = new();
            Assert.IsTrue(list.GetType().IsGenericList());
        }

        [Test]
        public void list_array_converter()
        {
            ListStructConverter? arrayConverter = new();
            //init data
            List<int[]> array = new()
            {
                new[]
                {
                    1, 1
                },
                new[]
                {
                    1, 1
                },
                new[]
                {
                    1, 1
                },
                new[]
                {
                    1, 1
                },
                new[]
                {
                    1, 1
                }
            };

            byte[]? bytes = arrayConverter.ToBytes(array.ToArray());

            (var obj, int len) = arrayConverter.FromBytes(bytes, typeof(int));
            List<int[]>? converted = (List<int[]>)obj;
            Assert.AreEqual(array, converted);
        }

        [Test]
        public void list_array_json()
        {
            ListStructConverter? arrayConverter = new();
            //init data
            List<int[]> array = new()
            {
                new[]
                {
                    1, 1
                },
                new[]
                {
                    1, 1
                },
                new[]
                {
                    1, 1
                },
                new[]
                {
                    1, 1
                },
                new[]
                {
                    1, 1
                }
            };

            string? bytes = JsonConvert.SerializeObject(array);


            List<int[]>? converted = (List<int[]>)JsonConvert.DeserializeObject(bytes, typeof(List<int[]>));
            Assert.AreEqual(array, converted);
        }


        [Test]
        public void list_converter()
        {
            ListStructConverter? arrayConverter = new();
            //init data
            List<int> array = new()
            {
                1,
                2,
                3,
                4,
                5
            };

            byte[]? bytes = arrayConverter.ToBytes(array.ToArray());

            (var obj, int len) = arrayConverter.FromBytes(bytes, typeof(int));
            List<int>? converted = (List<int>)obj;
            Assert.AreEqual(array, converted);
        }

        [Test]
        public void list_converter_double()
        {
            ListStructConverter? arrayConverter = new();
            //init data
            List<double> array = new()
            {
                1,
                2,
                3,
                4,
                5
            };

            byte[]? bytes = arrayConverter.ToBytes(array.ToArray());

            (var obj, int len) = arrayConverter.FromBytes(bytes, typeof(double));
            List<double>? converted = (List<double>)obj;
            Assert.AreEqual(array, converted);
        }

        [Test]
        public void list_converter_span()
        {
            ListStructConverter? arrayConverter = new();
            //init data
            List<int> array = new()
            {
                1,
                2,
                3,
                4,
                5
            };

            byte[]? bytes = arrayConverter.ToBytes(array.ToArray());

            (var obj, int len) = arrayConverter.FromBytes(bytes, typeof(int));
            List<int>? converted = (List<int>)obj;
            Assert.AreEqual(array, converted);
        }

        [SetUp]
        public void Setup()
        {
        }
    }
}