using System;

namespace ToBytes.Converters
{
    internal class DoubleStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(double);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((double)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            double res = bytes.ToDouble();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}