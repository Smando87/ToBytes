using System;

namespace ToBytes.Converters
{
    internal class DecimalStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(decimal);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj, byte[] prefix)
        {
            byte[]? bts = ConvertExtensions.ToBytes((decimal)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            decimal res = bytes.ToDecimal();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}