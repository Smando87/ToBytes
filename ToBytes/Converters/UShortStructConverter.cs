using System;

namespace ToBytes.Converters
{
    internal class UShortStructConverter : IStructConverter
    {
        public int Size => sizeof(ushort);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((ushort)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            ushort res = bytes.ToUShort();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}