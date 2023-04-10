using System;

namespace ToBytes.Converters
{
    internal class SByteStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(sbyte);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj, byte[] prefix)
        {
            byte[]? bts = ConvertExtensions.ToBytes((sbyte)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            sbyte res = bytes.ToSByte();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}