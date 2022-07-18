using System;

namespace ToBytes.Converters
{
    internal class ByteStructConverter : IStructConverter
    {
        public int Size => sizeof(byte);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((byte)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            byte res = bytes.ToByte();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}