using System;

namespace ToBytes
{
    public static class ToByteExtensions
    {
        public static T FromBytes<T>(this byte[]? bytes)
        {
            if (bytes == null)
            {
                return default;
            }

            return (T)FromBytes(bytes, typeof(T));
        }

        public static object FromBytes(this byte[]? bytes, Type type)
        {
            return ByteDeserializer.FromBytes(bytes, type);
        }

        public static byte[]? ToBytes<T>(this T obj)
        {
            return ByteSerializer.ToBytes(obj);
        }
        
        public static byte[]? ToBytesEncrypted<T>(this T obj, string password)
        {
            return ByteSerializer.ToBytesEncrypted<T>(obj, password);
        }
        
        public static void ToBytesToFile<T>(this T obj, string path)
        {
            ByteSerializer.WriteToFile(obj, path);
        }
        
        public static void ToEncryptedBytesToFile<T>(this T obj, string path, string password)
        {
            ByteSerializer.WriteEncryptedToFile(obj, path, password);
        }

        public static T FromBytesFromFile<T>(string path)
        {
            return ByteDeserializer.FromFile<T>(path);
        }
        
        public static T FromEncryptedBytesFromFile<T>(string path, string password)
        {
            return ByteDeserializer.FromEncryptedFile<T>(path, password);
        }
        
        public static T FromEncryptedBytes<T>(this byte[] bytes, string password)
        {
            return ByteDeserializer.FromEncryptedBytes<T>(bytes, password);
        }


    }
}