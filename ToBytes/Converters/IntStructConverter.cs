using System;

namespace ToBytes.Converters
{
    internal class IntStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => 4;
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((int)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            int res = bytes.ToInt();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}