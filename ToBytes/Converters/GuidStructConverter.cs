using System;

namespace ToBytes.Converters
{
    internal class GuidStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => 16;
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((Guid)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            Guid res = bytes.ToGuid();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}