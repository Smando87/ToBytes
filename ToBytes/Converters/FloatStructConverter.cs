using System;

namespace ToBytes.Converters
{
    internal class FloatStructConverter : IStructConverter
    {
        public int Size => 4;
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((float)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            float res = bytes.ToFloat();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}