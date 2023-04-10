using System;

namespace ToBytes.Converters
{
    internal class BoolStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(bool);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj, byte[] prefix)
        {
            byte[]? bts = ConvertExtensions.ToBytes((bool)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            bool res = bytes.ToBool();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}