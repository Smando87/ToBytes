using System;

namespace ToBytes.Converters
{
    internal class CharStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(char);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj, byte[] prefix)
        {
            byte[]? bts = ConvertExtensions.ToBytes((char)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            char res = bytes.ToChar();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            throw new NotImplementedException();
        }
    }
}