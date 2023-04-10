using System;

namespace ToBytes.Converters
{
    internal class LongStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(long);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj, byte[] prefix)
        {
            byte[]? bts = ConvertExtensions.ToBytes((long)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            long res = bytes.ToLong();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}