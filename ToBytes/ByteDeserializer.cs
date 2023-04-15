using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ToBytes.Cache;
using ToBytes.Converters;
using ToBytes.Extensions;

namespace ToBytes
{
    public class ByteDeserializer
    {
        private static object BytesToArrayOfStruct(byte[] bytes, Type type, int version)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(typeof(Array),version);
            (var res, int size) = conv.FromBytes(bytes, type);
            return res;
        }

        private static object BytesToDictionary(byte[] bytes, Type type, Type keyType, Type valType, int version)
        {
            List<byte>? byteList = bytes.ToList();
            int i = 0;
            Array arrOfKeys;
            Array arrOfValues;
            //dictionary length
            int length = byteList.GetRange(i, sizeof(int)).ToArray().ToInt();
            i += sizeof(int);

            ValueType keysType = (ValueType)byteList.GetRange(i, sizeof(int)).ToArray().ToInt();
            i += sizeof(int);

            int keysBytesLength = byteList.GetRange(i, sizeof(int)).ToArray().ToInt();

            if (keysType == ValueType.Struct)
            {
                // per keys length
                i += sizeof(int);
                // i12
                arrOfKeys = (Array)BytesToArrayOfStruct(byteList.GetRange(i, keysBytesLength).ToArray(), keyType,version);
                i += keysBytesLength;
            }
            else
            {
                arrOfKeys = Array.CreateInstance(keyType, new[]
                {
                    keysBytesLength
                });
                IList? listOfKeys =
                    (IList)BytesToListOfObject(byteList.GetRange(i, keysBytesLength + sizeof(int)).ToArray(),
                        typeof(List<>), keyType,version);
                i += keysBytesLength;
                listOfKeys.CopyTo(arrOfKeys, 0);
            }

            int valsCount = byteList.GetRange(i, sizeof(int)).ToArray().ToInt();
            i += sizeof(int);

            int valTypeB = byteList.GetRange(i, sizeof(int)).ToArray().ToInt();
            ValueType valsType = (ValueType)valTypeB;
            i += sizeof(int);

            int valsBytesLength = byteList.GetRange(i, sizeof(int)).ToArray().ToInt();

            if (valsType == ValueType.Struct)
            {
                i += sizeof(int);
                // i 40
                arrOfValues = (Array)BytesToArrayOfStruct(byteList.GetRange(i, valsBytesLength).ToArray(), valType, version);
                i += valsBytesLength;
            }
            else
            {
                arrOfValues = Array.CreateInstance(typeof(object), new[]
                {
                    valsCount
                });
                var newList =  ConvertExtensions.ToBytes(valsCount).ToList();
                

                newList.AddRange(byteList.GetRange(i, byteList.Count - i));
                IList? listOfValues =
                    (IList)BytesToListOfObjectForDict(newList.ToArray(), typeof(List<object>),
                        valType, version);
                i += valsCount;
                listOfValues.CopyTo(arrOfValues, 0);
            }

            IDictionary? dict = (IDictionary)ObjectExtensions.ConstructDictionary(keyType, valType);
            for (int j = 0; j < length; j++)
            {
                dict.Add(arrOfKeys.GetValue(j), arrOfValues.GetValue(j));
            }

            return dict;
        }

        private static object BytesToListOfObject(byte[] bytes, Type type, Type elType, int version)
        {
            List<byte>? byteList = bytes.ToList();
            int i = 0;
            int length = byteList.GetRange(i, sizeof(int)).ToArray().ToInt();
            i += sizeof(int);
            IList? listInstance = (IList)Activator.CreateInstance(type, length);
            while (i < bytes.Length)
            {
                int objLength = byteList.GetRange(i, sizeof(int)).ToArray().ToInt();
                i += sizeof(int);
                object? obj = FromBytes(byteList.GetRange(i, objLength).ToArray(), elType);
                i += objLength;
                listInstance.Add(obj);
            }

            return listInstance;
        }
        
        private static object BytesToListOfObjectForDict(byte[] bytes, Type type, Type elType, int version)
        {
            List<byte>? byteList = bytes.ToList();
            int i = 0;
            int length = byteList.GetRange(i, sizeof(int)).ToArray().ToInt();
            i += sizeof(int);
            IList? listInstance = (IList)Activator.CreateInstance(type, length);
            while (i < bytes.Length)
            {
                int objLength = byteList.GetRange(i, sizeof(int)).ToArray().ToInt();
                i += sizeof(int);
                object? obj = ObjectFromBytes(byteList.GetRange(i, objLength).ToArray(), elType,byteList.GetRange(i, objLength), version);
                i += objLength;
                listInstance.Add(obj);
            }

            return listInstance;
        }

        private static object BytesToListOfStruct(byte[] bytes, Type type, int version)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(typeof(IList),version);
            (var res, int size) = conv.FromBytes(bytes, type);
            return res;
        }

        /// <summary>
        ///     The main deserialization method., convert an array of bytes to an object.
        /// </summary>
        /// <param name="bytes">The array of byte to convert</param>
        /// <param name="type">The destination Type</param>
        /// <returns>AN instance of the deserialized object</returns>
        public static object FromBytes(byte[]? bytes, Type type)
        {
            CacherSingleton.Instance.Init();
            var prefix = bytes.ToList().GetRange(0, 2).ToArray();
            var version = prefix[0];
            ValueType valueTypeFromType = CacherSingleton.Instance.GetValueTypeFromType(type);
            Type elType = null;
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(type,version);
            //TODO: optimize
            
            var data = bytes.ToList().GetRange(prefix.Length, bytes.Length - prefix.Length).ToArray();
            switch (valueTypeFromType)
            {
                case ValueType.String:
                case ValueType.Struct:
                    (var objRes, int size) = conv.FromBytes(data);
                    return objRes;
                case ValueType.CustomStruct:
                    return BytesToCustomStruct(data, type, version);
                    break;
                case ValueType.Null:
                    break;

                case ValueType.Object:
                    break;
                case ValueType.ArrayOfStruct:
                    elType = type.GetElementType();
                    return BytesToArrayOfStruct(data, elType, version);
                    break;
                case ValueType.ArrayOfObject:
                    //elType = type.GetElementType();
                    //return ArrayOfObjectToBytes(obj, type, elType);
                    break;
                case ValueType.ListOfStruct:
                    elType = type.GetListType();
                    return BytesToListOfStruct(data, elType, version);
                    break;
                case ValueType.ListOfObject:
                    elType = type.GetListType();
                    return BytesToListOfObject(data, type, elType, version);
                    break;
                case ValueType.Unknown:
                    break;
                case ValueType.Dictionary:
                    Type[]? arguments = type.GetGenericArguments();
                    Type keyType = arguments[0];
                    Type valType = arguments[1];
                    return BytesToDictionary(data, type, keyType, valType, version);
                    break;
                case ValueType.Enum:
                    return BytesToEnum(data, type, version);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // if (type.IsStruct())
            // {
            //     var conv = CacherSingleton.Instance.GetConverter(type);
            //     (var objRes, var size) = conv.FromBytes(bytes);
            //     return objRes;
            // }
            //
            // var isString = type == typeof(string);
            // if (isString)
            // {
            //     var conv = CacherSingleton.Instance.GetConverter(type);
            //     (var objRes, var size) = conv.FromBytes(bytes);
            //     return objRes;
            // }
            //
            // var isArray = type.IsArray();
            // if (isArray)
            // {
            //     var elType = type.GetElementType();
            //     if (elType.IsStruct())
            //     {
            //         return BytesToArrayOfStruct(bytes, elType);
            //     }
            // }
            //
            // var isList = type.IsList();
            // if (isList)
            // {
            //     var elType = type.GetListType();
            //     if (elType.IsStruct())
            //     {
            //         return BytesToListOfStruct(bytes, elType);
            //     }
            // }


            List<byte>? byteList = data.ToList();
            byte valueType = byteList[0];
            object obj = null;
            if (valueType == (byte)ValueType.Object)
            {
                obj = ObjectFromBytes(data, type, byteList,version);
            }


            return obj;
        }

        private static object BytesToCustomStruct(byte[] data, Type type, byte version)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(typeof(CustomStructConverter),version);
            (var res, var size)= conv.FromBytes(data, type);
            return res;
        }

        private static object BytesToEnum(byte[] data, Type elType, int version)
        {
            IStructConverter? conv = CacherSingleton.Instance.GetConverter(typeof(Enum),version);
            (var res, var size)= conv.FromBytes(data);
            return res;
        }

        private static object? ObjectFromBytes(byte[] bytes, Type type, List<byte> byteList, int version)
        {
            object? obj = Activator.CreateInstance(type);

            PropertyDescriptor[]? props = CacherSingleton.Instance.GetPropertiesListCached(obj, type);

            int i = 1;

            long numeberOfProperties = BitConverter.ToInt64(bytes, i);
            i += 8;

            long numeberOfDynamicSizes = BitConverter.ToInt64(bytes, i);
            i += 8;

            byte[]? valueTypes = new byte[numeberOfProperties];
            Array.Copy(bytes, i, valueTypes, 0, numeberOfProperties);
            i += (int)numeberOfProperties;

            byte[]? dynamicSizes = new byte[numeberOfDynamicSizes];
            Array.Copy(bytes, i, dynamicSizes, 0, numeberOfDynamicSizes);
            i += (int)numeberOfDynamicSizes;

            int indexProps = 0;
            int indexDynamicSizes = 0;
            foreach (PropertyDescriptor prop in props)
            {
                if (prop.IsReadOnly)
                {
                    continue;
                }

                if (valueTypes[indexProps] == (byte)ValueType.Null)
                {
                    indexProps++;
                    continue;
                }

                IStructConverter? conv = CacherSingleton.Instance.GetConverter(prop.PropertyType,version );

                if (conv != null)
                {
                    byte[] bts = null;
                    int length = conv.Size;
                    if (conv.Type == ValueType.String)
                    {
                        bts = dynamicSizes.ToList().GetRange(indexDynamicSizes, 8).ToArray();
                        length = (int)bts.ToLong();
                        indexDynamicSizes += 8;
                    }

                    bts = byteList.GetRange(i, length).ToArray();
                    (var val, int size) = conv.FromBytes(bts);
                    obj.SetPropValue(prop.Name, val);
                    i += size;
                }

                if (valueTypes[indexProps] == (byte)ValueType.Object)
                {
                    byte[]? bts = dynamicSizes.ToList().GetRange(indexDynamicSizes, 8).ToArray();
                    long lenght = bts.ToLong();
                    byte[]? bytes2 = byteList.GetRange(i, (int)lenght).ToArray();
                    object? val = FromBytes(bytes2, prop.PropertyType);
                    prop.SetValue(obj, val);
                    indexDynamicSizes += 8;
                    i += (int)lenght;
                }

                indexProps++;
            }

            return obj;
        }

        public static T FromFile<T>(string path)
        {
            byte[]? bytes = File.ReadAllBytes(path);
            return (T)FromBytes(bytes, typeof(T));
        }

        public static T FromEncryptedBytes<T>(byte[] bytes, string password)
        {
            var bytesDecrypted = CryptoExtensions.Decrypt(bytes, password);
            return (T)FromBytes(bytesDecrypted, typeof(T));
        }

        public static T FromEncryptedFile<T>(string path, string password)
        {
            byte[]? bytes = File.ReadAllBytes(path);
            return FromEncryptedBytes<T>(bytes, password);
        }
    }
}