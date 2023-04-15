using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using ToBytes.Converters;

namespace ToBytes.Cache
{
    internal class Cacher
    {
        public readonly Dictionary<Type?, MethodInfo> MetochdCache = new();
        public readonly Dictionary<Type, PropertyDescriptor[]> PropertyCache = new();
        public readonly Dictionary<Type, ValueType> ValueTypeCache = new();
        private readonly object _lockConverters = new();
        public Dictionary<Type, List<IStructConverter>> Converters;

        internal Cacher()
        {
            Init();
        }

        internal IStructConverter GetConverter(Type propPropertyType, int version)
        {
            List<IStructConverter> res = null;
            if (CacherSingleton.Instance.Converters.TryGetValue(propPropertyType, out res))
            {
                return (IStructConverter)res.Where(ff => ff.Version <= version).OrderByDescending(ff => ff.Version)
                    .FirstOrDefault();
            }

            return null;
        }

        internal PropertyDescriptor[] GetPropertiesListCached<T>(T obj, Type? type)
        {
            PropertyDescriptor[] props;
            if (!CacherSingleton.Instance.PropertyCache.TryGetValue(type, out props))
            {
                PropertyDescriptorCollection? ps = TypeDescriptor.GetProperties(obj).Sort();
                props = new PropertyDescriptor[ps.Count];
                ps.CopyTo(props, 0);
                CacherSingleton.Instance.PropertyCache.Add(type, props);
            }

            return props;
        }

        internal MethodInfo GetToBytesMethodCached(Type? valType)
        {
            MethodInfo method = null;
            if (!CacherSingleton.Instance.MetochdCache.TryGetValue(valType, out method))
            {
                method = typeof(ToByteExtensions).GetMethod("ToBytes");
                method = method.MakeGenericMethod(valType);
                CacherSingleton.Instance.MetochdCache.Add(valType, method);
            }

            return method;
        }

        public ValueType GetValueTypeFromType(Type type)
        {
            ValueType valueType = ValueType.Unknown;
            if (!CacherSingleton.Instance.ValueTypeCache.TryGetValue(type, out valueType))
            {
                if (type.IsCustomStruct())
                {
                    valueType = ValueType.CustomStruct;
                    CacherSingleton.Instance.ValueTypeCache.Add(type, valueType);
                    return valueType;
                }

                if (type.IsStruct())
                {
                    valueType = ValueType.Struct;
                }
                else if (type == typeof(string))
                {
                    valueType = ValueType.Struct;
                }
                else if (type.IsArray)
                {
                    if (type.GetElementType().IsStruct())
                    {
                        valueType = ValueType.ArrayOfStruct;
                    }
                    else
                    {
                        valueType = ValueType.ArrayOfObject;
                    }
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    if (type.GetListType().IsStruct())
                    {
                        valueType = ValueType.ListOfStruct;
                    }
                    else
                    {
                        valueType = ValueType.ListOfObject;
                    }
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    Type[]? arguments = type.GetGenericArguments();
                    Type keyType = arguments[0];
                    Type valType = arguments[1];
                    valueType = ValueType.Dictionary;
                }

                else if (type.IsEnum)
                {
                    valueType = ValueType.Enum;
                }
                else
                {
                    valueType = ValueType.Object;
                }

                CacherSingleton.Instance.ValueTypeCache.Add(type, valueType);
            }

            return valueType;
        }

        internal void Init()
        {
            if (Converters == null)
            {
                lock (_lockConverters)
                {
                    Converters = new Dictionary<Type, List<IStructConverter>>
                    {
                        {
                            typeof(int), new List<IStructConverter>()
                            {
                                new IntStructConverter()
                            }
                        },
                        {
                            typeof(int?), new List<IStructConverter>()
                            {
                                new IntStructConverter()
                            }
                        },
                        {
                            typeof(long), new List<IStructConverter>()
                            {
                                new LongStructConverter()
                            }
                        },
                        {
                            typeof(long?), new List<IStructConverter>()
                            {
                                new LongStructConverter()
                            }
                        },
                        {
                            typeof(double), new List<IStructConverter>()
                            {
                                new DoubleStructConverter()
                            }
                        },
                        {
                            typeof(double?), new List<IStructConverter>()
                            {
                                new DoubleStructConverter()
                            }
                        },
                        {
                            typeof(bool), new List<IStructConverter>()
                            {
                                new BoolStructConverter()
                            }
                        },
                        {
                            typeof(bool?), new List<IStructConverter>()
                            {
                                new BoolStructConverter()
                            }
                        },
                        {
                            typeof(string), new List<IStructConverter>()
                            {
                                new StringStructConverter()
                            }
                        },
                        {
                            typeof(DateTime), new List<IStructConverter>()
                            {
                                new DateTimeStructConverter()
                            }
                        },
                        {
                            typeof(DateTime?), new List<IStructConverter>()
                            {
                                new DateTimeStructConverter()
                            }
                        },
                        // {typeof(byte[]), new ByteArrayConverter()}},
                        {
                            typeof(byte), new List<IStructConverter>()
                            {
                                new ByteStructConverter()
                            }
                        },
                        {
                            typeof(byte?), new List<IStructConverter>()
                            {
                                new ByteStructConverter()
                            }
                        },
                        {
                            typeof(sbyte), new List<IStructConverter>()
                            {
                                new SByteStructConverter()
                            }
                        },
                        {
                            typeof(sbyte?), new List<IStructConverter>()
                            {
                                new SByteStructConverter()
                            }
                        },
                        {
                            typeof(short), new List<IStructConverter>()
                            {
                                new ShortStructConverter()
                            }
                        },
                        {
                            typeof(short?), new List<IStructConverter>()
                            {
                                new ShortStructConverter()
                            }
                        },
                        {
                            typeof(ushort), new List<IStructConverter>()
                            {
                                new UShortStructConverter()
                            }
                        },
                        {
                            typeof(ushort?), new List<IStructConverter>()
                            {
                                new UShortStructConverter()
                            }
                        },
                        {
                            typeof(uint), new List<IStructConverter>()
                            {
                                new UIntStructConverter()
                            }
                        },
                        {
                            typeof(uint?), new List<IStructConverter>()
                            {
                                new UIntStructConverter()
                            }
                        },
                        {
                            typeof(ulong), new List<IStructConverter>()
                            {
                                new ULongStructConverter()
                            }
                        },
                        {
                            typeof(ulong?), new List<IStructConverter>()
                            {
                                new ULongStructConverter()
                            }
                        },
                        {
                            typeof(float), new List<IStructConverter>()
                            {
                                new FloatStructConverter()
                            }
                        },
                        {
                            typeof(float?), new List<IStructConverter>()
                            {
                                new FloatStructConverter()
                            }
                        },
                        {
                            typeof(decimal), new List<IStructConverter>()
                            {
                                new DecimalStructConverter()
                            }
                        },
                        {
                            typeof(decimal?), new List<IStructConverter>()
                            {
                                new DecimalStructConverter()
                            }
                        },
                        {
                            typeof(TimeSpan), new List<IStructConverter>()
                            {
                                new TimeSpanStructConverter()
                            }
                        },
                        {
                            typeof(TimeSpan?), new List<IStructConverter>()
                            {
                                new TimeSpanStructConverter()
                            }
                        },
                        {
                            typeof(Guid), new List<IStructConverter>()
                            {
                                new GuidStructConverter()
                            }
                        },
                        {
                            typeof(Guid?), new List<IStructConverter>()
                            {
                                new GuidStructConverter()
                            }
                        },
                        {
                            typeof(char), new List<IStructConverter>()
                            {
                                new CharStructConverter()
                            }
                        },
                        {
                            typeof(char?), new List<IStructConverter>()
                            {
                                new CharStructConverter()
                            }
                        },
                        {
                            typeof(Array), new List<IStructConverter>()
                            {
                                new ArrayStructConverter()
                            }
                        },
                        {
                            typeof(IList), new List<IStructConverter>()
                            {
                                new ListStructConverter()
                            }
                        },
                        {
                            typeof(Enum), new List<IStructConverter>()
                            {
                                new EnumStructConverter()
                            }
                        },
                        {
                            typeof(CustomStructConverter), new List<IStructConverter>()
                            {
                                new CustomStructConverter()
                            }
                        }

                        //{typeof(byte), new ByteConverter()},
                    };
                }
            }
        }
    }
}