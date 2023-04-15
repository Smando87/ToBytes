using System;

namespace ToBytes.Converters
{
    internal class DateTimeStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => 8;
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((DateTime)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            DateTime res = bytes.ToDateTime();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}