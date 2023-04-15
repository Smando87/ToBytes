using System;

namespace ToBytes.Converters
{
    internal class UIntStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(uint);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((uint)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            uint res = bytes.ToUInt();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}