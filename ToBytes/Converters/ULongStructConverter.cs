namespace ToBytes.Converters
{
    internal class ULongStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(ulong);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            byte[]? bts = ConvertExtensions.ToBytes((ulong)obj);
            return bts;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            ulong res = bytes.ToULong();
            return (res, Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            ulong res = bytes.ToULong();
            return (res, Size);
        }
    }
}