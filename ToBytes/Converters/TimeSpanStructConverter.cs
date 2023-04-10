using System;

namespace ToBytes.Converters
{
    internal class TimeSpanStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => 8;
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj, byte[] prefix)
        {
            byte[]? bts = ConvertExtensions.ToBytes((TimeSpan)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            TimeSpan res = bytes.ToTimeSpan();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}