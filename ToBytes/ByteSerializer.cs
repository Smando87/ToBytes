using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ToBytes.Cache;
using ToBytes.Converters;
using ToBytes.Extensions;
using Enum = System.Enum;

namespace ToBytes
{
    internal class ByteSerializer
    {
        public static int Version => 1;

        private static byte[] ArrayOfObjectToBytes(IList array, Type type, Type? elType)
        {
            List<byte>? bytes = new List<byte>();
            for (int i = 0; i < array.Count; i++)
            {
                bytes.AddRange(ToBytes(array[i]));
            }

            return bytes.ToArray();
        }

        private static byte[] ArrayOfStructToBytes<T>(T obj, Type type, Type? elType)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(typeof(Array), Version);
            return conv.ToBytes(obj);
        }

        private static byte[] DictionaryToBytes(object obj, Type type, Type keyType, Type valType)
        {
            List<byte>? bytes = new List<byte>();
            IDictionary? dict = (IDictionary)obj;
            IStructConverter? listConverter = CacherSingleton.Instance.GetConverter(typeof(IList), Version);
            //dict.Keys.GetType()
            Type? keysArrType = dict.Keys.GetType().GetGenericArguments()[0];
            int[]? indices = new int[1]
            {
                dict.Keys.Count
            };

            Array? keysArrInstance = Array.CreateInstance(keysArrType, indices);
            Array? keysArr = (Array)keysArrInstance;
            dict.Keys.CopyTo(keysArr, 0);
            bytes.AddRange(ConvertExtensions.ToBytes(dict.Keys.Count));
            if (keyType.IsStruct())
            {
                bytes.AddRange(ConvertExtensions.ToBytes((int)ValueType.Struct));

                byte[]? keysBytesTemp = listConverter.ToBytes(keysArr);
                bytes.AddRange(ConvertExtensions.ToBytes(keysBytesTemp.Length));
                bytes.AddRange(keysBytesTemp);
            }
            else
            {
                bytes.AddRange(ConvertExtensions.ToBytes((int)ValueType.Object));
                foreach (var el in keysArr)
                {
                    MethodInfo? toBytesMethod = CacherSingleton.Instance.GetToBytesMethodCached(keysArrType);
                    byte[]? bytesToAdd = (byte[])toBytesMethod.Invoke(null, new[]
                    {
                        el
                    })!;
                    var noPrefix = new byte[bytesToAdd.Length - 2];
                    Buffer.BlockCopy(bytesToAdd, 2, noPrefix, 0, bytesToAdd.Length - 2);
                    bytes.AddRange(ConvertExtensions.ToBytes(noPrefix.Length));
                    bytes.AddRange(noPrefix);
                }
            }

            Type? valsArrType = dict.Values.GetType().GetGenericArguments()[1];
            Array? valsArrInstance = Array.CreateInstance(valsArrType, indices);
            Array? valsArr = (Array)valsArrInstance;
            dict.Values.CopyTo(valsArr, 0);
            bytes.AddRange(ConvertExtensions.ToBytes(dict.Values.Count));
            if (valType.IsStruct())
            {
                bytes.AddRange(ConvertExtensions.ToBytes((int)ValueType.Struct));
                byte[]? valsBytesTemp = listConverter.ToBytes(valsArr);
                bytes.AddRange(ConvertExtensions.ToBytes(valsBytesTemp.Length));
                bytes.AddRange(valsBytesTemp);
            }
            else
            {
                bytes.AddRange(ConvertExtensions.ToBytes((int)ValueType.Object));
                foreach (var el in valsArr)
                {
                    MethodInfo? toBytesMethod = CacherSingleton.Instance.GetToBytesMethodCached(valsArrType);
                    byte[]? bytesToAdd = (byte[])toBytesMethod.Invoke(null, new[]
                    {
                        el
                    })!;
                    var noPrefix = new byte[bytesToAdd.Length - 2];
                    Buffer.BlockCopy(bytesToAdd, 2, noPrefix, 0, bytesToAdd.Length - 2);
                    bytes.AddRange(ConvertExtensions.ToBytes(noPrefix.Length));
                    bytes.AddRange(noPrefix);
                }
            }

            return bytes.ToArray();
        }

        private static byte[] ListOfObjectToBytes(IList array, Type type, Type? elType)
        {
            List<byte>? bytes = new List<byte>();
            bytes.AddRange(ConvertExtensions.ToBytes(array.Count));
            foreach (var el in array)
            {
                MethodInfo? toBytesMethod = CacherSingleton.Instance.GetToBytesMethodCached(elType);
                byte[]? bytesToAdd = (byte[])toBytesMethod.Invoke(null, new[]
                {
                    el
                })!;
                bytes.AddRange(ConvertExtensions.ToBytes(bytesToAdd.Length));
                bytes.AddRange(bytesToAdd);
            }

            return bytes.ToArray();
        }

        private static byte[] ListOfStructToBytes<T>(T obj, Type type, Type? elType)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(typeof(IList), Version);
            return conv.ToBytes(obj);
        }

        public static SerializeMetadata ObjectToBytes<T>(T obj)
        {
            if (obj == null)
            {
                return new SerializeMetadata
                {
                    Data = new byte[0]
                };
            }

            Type? type = typeof(T);
            List<byte>? resData = new List<byte>();
            SerializeMetadata? result = new SerializeMetadata();

            PropertyDescriptor[]? props = CacherSingleton.Instance.GetPropertiesListCached(obj, type);

            int numerberOfProperties = props.Length;
            // Value types:
            //0 struct
            //1 null
            //2 string
            //3 object (recursive)
            byte[]? valueTypes = new byte[numerberOfProperties];
            List<byte>? dynamicSizes = new List<byte>();

            ULongUnion uLongUnion = new ULongUnion();

            for (int index = 0; index < props.Length; index++)
            {
                PropertyDescriptor? prop = props[index];
                if (prop.IsReadOnly)
                {
                    continue;
                }

                object? val = obj.GetPropValue<T>(prop.Name);
                if (val == null)
                {
                    valueTypes[index] = 1;
                    continue;
                }

                Type? valType = val.GetType();
                IStructConverter? conv = CacherSingleton.Instance.GetConverter(prop.PropertyType, Version);

                if (conv != null)
                {
                    byte[]? bytes = conv.ToBytes(val);
                    resData.AddRange(bytes);
                    valueTypes[index] = (byte)conv.Type;
                    if (valueTypes[index] == 2)
                    {
                        long length = (long)bytes.Length;
                        dynamicSizes.AddRange(ConvertExtensions.ToBytes(length));
                    }

                    continue;
                }

                if (valType.IsClass)
                {
                    valueTypes[index] = 3;
                    MethodInfo? toBytesMethod = CacherSingleton.Instance.GetToBytesMethodCached(valType);
                    byte[]? bytes = (byte[])toBytesMethod.Invoke(null, new[]
                    {
                        val
                    })!;
                    resData.AddRange(bytes);
                    long cVal = (long)bytes.Length;
                    dynamicSizes.AddRange(ConvertExtensions.ToBytes(cVal));
                }
            }

            byte[]? res = new byte[17 + valueTypes.Length + dynamicSizes.Count + resData.Count];
            res[0] = 3;
            uLongUnion.value = (ulong)numerberOfProperties;
            res[1] = uLongUnion.byte0;
            res[2] = uLongUnion.byte1;
            res[3] = uLongUnion.byte2;
            res[4] = uLongUnion.byte3;
            res[5] = uLongUnion.byte4;
            res[6] = uLongUnion.byte5;
            res[7] = uLongUnion.byte6;
            res[8] = uLongUnion.byte7;
            uLongUnion.value = (ulong)dynamicSizes.Count;
            res[9] = uLongUnion.byte0;
            res[10] = uLongUnion.byte1;
            res[11] = uLongUnion.byte2;
            res[12] = uLongUnion.byte3;
            res[13] = uLongUnion.byte4;
            res[14] = uLongUnion.byte5;
            res[15] = uLongUnion.byte6;
            res[16] = uLongUnion.byte7;
            valueTypes.CopyTo(res, 17);
            dynamicSizes.CopyTo(res, 17 + valueTypes.Length);

            int dataOfffset = 17 + valueTypes.Length + dynamicSizes.Count;
            resData.CopyTo(res, 17 + valueTypes.Length + dynamicSizes.Count);

            result.Data = res.ToArray();
            result.DataLength = resData.Count;
            result.DataOffset = dataOfffset;
            result.MetaDataLength = dataOfffset;
            result.Length = result.DataLength + result.MetaDataLength;

            return result;
        }

        private static byte[] StringToBytes<T>(T obj, Type type)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(type, Version);
            return conv.ToBytes(obj);
        }

        private static byte[] StructToBytes<T>(T obj, Type type)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(type, Version);
            return conv.ToBytes(obj);
        }
        
        private static byte[] CustomStructToBytes<T>(T obj)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(typeof(CustomStructConverter), Version);
            return conv.ToBytes(obj);
        }

        private static byte[] EnumToBytes<T>(T obj)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(typeof(Enum), Version);
            return conv.ToBytes(obj);
        }

        public static byte[]? ToBytes<T>(T obj)
        {
            CacherSingleton.Instance.Init();

            List<byte> bytesWithPrefix = new List<byte>
            {
                (byte)ByteSerializer.Version,
                (byte)SerializedType.Standard
            };
            if (obj == null)
            {
                return null;
            }

            Type type = obj.GetType();

            ValueType valueType = CacherSingleton.Instance.GetValueTypeFromType(type);
            Type? elType = null;
            byte[] res = new byte[]
            {
            };
            switch (valueType)
            {
                case ValueType.Struct:
                    res = StructToBytes(obj, type);
                    break;
                case ValueType.CustomStruct:
                    res = CustomStructToBytes(obj);
                    break;
                case ValueType.String:
                    res = StringToBytes(obj, type);
                    break;
                case ValueType.Object:
                    res = ObjectToBytes(obj).Data;
                    break;
                case ValueType.ArrayOfStruct:
                    elType = type.GetElementType();
                    res = ArrayOfStructToBytes(obj, type, elType);
                    break;
                case ValueType.ArrayOfObject:
                    elType = type.GetElementType();
                    res = ArrayOfObjectToBytes((IList)obj, type, elType);
                    break;
                case ValueType.ListOfStruct:
                    Type? listElType = ((IList)obj).GetListTypeFromObj();
                    res = ListOfStructToBytes(obj, type, listElType);
                    break;
                case ValueType.ListOfObject:
                    elType = ((IList)obj).GetListTypeFromObj();
                    res = ListOfObjectToBytes((IList)obj, type, elType);
                    break;
                case ValueType.Dictionary:
                    Type[]? arguments = type.GetGenericArguments();
                    Type keyType = arguments[0];
                    Type valType = arguments[1];
                    res = DictionaryToBytes(obj, type, keyType, valType);
                    break;
                case ValueType.Enum:
                    res = EnumToBytes(obj);
                    break;
                case ValueType.Unknown:
                    break;
                case ValueType.Null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            bytesWithPrefix.AddRange(res);
            var res2 = bytesWithPrefix.ToArray();
            return res2;
        }
    }
}