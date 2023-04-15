using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ToBytes.Tests")]

namespace ToBytes.Converters
{
    internal interface IStructConverter : IConverter
    {
        int Size { get; }
        ValueType Type { get; }

        (object, int) FromBytes(byte[] bytes);
        (object, int) FromBytes(byte[] bytes, Type destType);

        byte[] ToBytes(object obj);
    }
}