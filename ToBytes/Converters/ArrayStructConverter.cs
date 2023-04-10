using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("ToBytes.Tests")]

namespace ToBytes.Converters
{
    internal class ArrayStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => 0;
        public ValueType Type => ValueType.ArrayOfStruct;

        public byte[] ToBytes(object obj, byte[] prefix)
        {
            Array array = (Array)obj;
            Type? elType = array.GetType().GetElementType();
            int elSize = Marshal.SizeOf(elType);
            int dimensions = array.Rank;
            byte[] bytes = new byte[array.Length * elSize];
            Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);
            List<byte> bytesTemp = new();
            byte[]? dimsArray = ConvertExtensions.ToBytes(dimensions);
            bytesTemp.AddRange(dimsArray);
            int[]? indices0 = new int[array.Rank];
            for (int i = 0; i < indices0.Length; i++)
            {
                bytesTemp.AddRange(ConvertExtensions.ToBytes(array.GetLength(i)));
            }

            bytesTemp.AddRange(bytes);
            byte[]? bytesFinal = bytesTemp.ToArray();
            return bytesFinal;
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            List<byte>? bytesToRevert = new List<byte>(bytes);
            int dimesRev = bytesToRevert.GetRange(0, 4).ToArray().ToInt();
            int index = sizeof(int);
            int[]? indices = new int[dimesRev];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = bytesToRevert.GetRange(index, 4).ToArray().ToInt();
                index += sizeof(int);
            }

            Array? res = Array.CreateInstance(destType, indices);
            //var converted = new int[indices[0], indices[1]];
            Buffer.BlockCopy(bytes, index, res, 0, bytes.Length - index);
            return (res, Size);
        }

       
    }
}