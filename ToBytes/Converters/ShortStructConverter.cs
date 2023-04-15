using System;

namespace ToBytes.Converters
{
    internal class ShortStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(short);
        public ValueType Type => ValueType.Struct;


        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((short)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            short res = bytes.ToShort();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}