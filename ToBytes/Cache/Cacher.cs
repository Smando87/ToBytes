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
        public readonly Dictionary<Type, MethodInfo> MetochdCache = new();
        public readonly Dictionary<Type, PropertyDescriptor[]> PropertyCache = new();
        public readonly Dictionary<Type, ValueType> ValueTypeCache = new();
        private readonly object _lockConverters = new();
        public Dictionary<Type, object> Converters;

        internal Cacher()
        {
            Init();
        }

        internal IStructConverter GetConverter(Type propPropertyType)
        {
            object res = null;
            if (CacherSingleton.Instance.Converters.TryGetValue(propPropertyType, out res))
            {
                return (IStructConverter)res;
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

        internal MethodInfo GetToBytesMethodCached(Type valType)
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
                    Converters = new Dictionary<Type, object>
                    {
                        {
                            typeof(int), new IntStructConverter()
                        },
                        {
                            typeof(int?), new IntStructConverter()
                        },
                        {
                            typeof(long), new LongStructConverter()
                        },
                        {
                            typeof(long?), new LongStructConverter()
                        },
                        {
                            typeof(double), new DoubleStructConverter()
                        },
                        {
                            typeof(double?), new DoubleStructConverter()
                        },
                        {
                            typeof(bool), new BoolStructConverter()
                        },
                        {
                            typeof(bool?), new BoolStructConverter()
                        },
                        {
                            typeof(string), new StringStructConverter()
                        },
                        {
                            typeof(DateTime), new DateTimeStructConverter()
                        },
                        {
                            typeof(DateTime?), new DateTimeStructConverter()
                        },
                        // {typeof(byte[]), new ByteArrayConverter()},
                        {
                            typeof(byte), new ByteStructConverter()
                        },
                        {
                            typeof(byte?), new ByteStructConverter()
                        },
                        {
                            typeof(sbyte), new SByteStructConverter()
                        },
                        {
                            typeof(sbyte?), new SByteStructConverter()
                        },
                        {
                            typeof(short), new ShortStructConverter()
                        },
                        {
                            typeof(short?), new ShortStructConverter()
                        },
                        {
                            typeof(ushort), new UShortStructConverter()
                        },
                        {
                            typeof(ushort?), new UShortStructConverter()
                        },
                        {
                            typeof(uint), new UIntStructConverter()
                        },
                        {
                            typeof(uint?), new UIntStructConverter()
                        },
                        {
                            typeof(ulong), new ULongStructConverter()
                        },
                        {
                            typeof(ulong?), new ULongStructConverter()
                        },
                        {
                            typeof(float), new FloatStructConverter()
                        },
                        {
                            typeof(float?), new FloatStructConverter()
                        },
                        {
                            typeof(decimal), new DecimalStructConverter()
                        },
                        {
                            typeof(decimal?), new DecimalStructConverter()
                        },
                        {
                            typeof(TimeSpan), new TimeSpanStructConverter()
                        },
                        {
                            typeof(TimeSpan?), new TimeSpanStructConverter()
                        },
                        {
                            typeof(Guid), new GuidStructConverter()
                        },
                        {
                            typeof(Guid?), new GuidStructConverter()
                        },
                        {
                            typeof(char), new CharStructConverter()
                        },
                        {
                            typeof(char?), new CharStructConverter()
                        },
                        {
                            typeof(Array), new ArrayStructConverter()
                        },
                        {
                            typeof(IList), new ListStructConverter()
                        }

                        //{typeof(byte), new ByteConverter()},
                    };
                }
            }
        }
    }
}