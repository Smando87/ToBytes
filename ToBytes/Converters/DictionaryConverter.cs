using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ToBytes.Cache;
using ToBytes.Extensions;

namespace ToBytes.Converters
{
    public class DictionaryConverter : ISpecialConverter
    {
        public new int Version => 1;
        public object FromBytes(byte[] bytes, Type keyType, Type valType, int version)
        {
            IStructConverter? convArray = CacherSingleton.Instance.GetConverter(typeof(Array),version);
            IStructConverter? convList = CacherSingleton.Instance.GetConverter(typeof(IList), version);
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
                (var arrOfKeysGen, int size) =
                    convArray.FromBytes(byteList.GetRange(i, keysBytesLength).ToArray(), keyType);
                arrOfKeys = (Array)arrOfKeysGen;
                i += keysBytesLength;
            }
            else
            {
                arrOfKeys = Array.CreateInstance(keyType, new[]
                {
                    keysBytesLength
                });
                (var listOfKeysGen, int size) =
                    convList.FromBytes(byteList.GetRange(i, keysBytesLength + sizeof(int)).ToArray(), keyType);
                IList? listOfKeys = (IList)listOfKeysGen;
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
                (var arrOfValueGens, int size) =
                    convArray.FromBytes(byteList.GetRange(i, valsBytesLength).ToArray(), valType);
                arrOfValues = (Array)arrOfValueGens;
                i += valsBytesLength;
            }
            else
            {
                arrOfValues = Array.CreateInstance(keyType, new[]
                {
                    valsCount
                });
                (var listOfValuesGen, int size) =
                    convList.FromBytes(byteList.GetRange(i, valsCount + sizeof(int)).ToArray(), valType);
                IList? listOfValues = (IList)listOfValuesGen;
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
    }
}