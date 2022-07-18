using System;

namespace ToBytes
{
    public static class ToByteExtensions
    {
        public static T FromBytes<T>(this byte[] bytes)
        {
            if (bytes == null)
            {
                return default;
            }

            return (T)FromBytes(bytes, typeof(T));
        }

        public static object FromBytes(this byte[] bytes, Type type)
        {
            return ByteDeserializer.FromBytes(bytes, type);
        }

        public static byte[] ToBytes<T>(this T obj)
        {
            return ByteSerializer.ToBytes(obj);
        }
    }
}