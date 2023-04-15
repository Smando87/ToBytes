using System;

namespace ToBytes.Converters
{
    internal class StringStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => 0;
        public ValueType Type => ValueType.String;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ((string)obj).ToBytesUnsafe();
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            string? res = bytes.ToStringUnsafe();
            return (res, bytes.Length);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}