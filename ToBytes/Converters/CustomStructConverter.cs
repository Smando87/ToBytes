using System;
using System.Runtime.InteropServices;

namespace ToBytes.Converters
{
    internal class CustomStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(bool);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            int size = Marshal.SizeOf(obj);
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(obj, ptr, true);
                Marshal.Copy(ptr, bytes, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return bytes;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            object res;

            int size = Marshal.SizeOf(destType);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.Copy(bytes, 0, ptr, size);
                res = Marshal.PtrToStructure(ptr, destType);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return (res, size);
        }
    }
}