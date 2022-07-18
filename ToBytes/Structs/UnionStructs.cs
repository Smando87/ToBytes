using System;
using System.Runtime.InteropServices;

namespace ToBytes
{
    [StructLayout(LayoutKind.Explicit)]
    public struct IntUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(0)] public int value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct UIntUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(0)] public uint value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct DoubleUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(4)] public byte byte4;
        [FieldOffset(5)] public byte byte5;
        [FieldOffset(6)] public byte byte6;
        [FieldOffset(7)] public byte byte7;
        [FieldOffset(0)] public double value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct LongUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(4)] public byte byte4;
        [FieldOffset(5)] public byte byte5;
        [FieldOffset(6)] public byte byte6;
        [FieldOffset(7)] public byte byte7;
        [FieldOffset(0)] public long value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ULongUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(4)] public byte byte4;
        [FieldOffset(5)] public byte byte5;
        [FieldOffset(6)] public byte byte6;
        [FieldOffset(7)] public byte byte7;
        [FieldOffset(0)] public ulong value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ShortUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(0)] public short value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct UShortUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(0)] public ushort value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct FloatUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(0)] public float value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SByteUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(0)] public sbyte value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct CharUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(0)] public char value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct BooleanUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(0)] public bool value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct DecimalUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(4)] public byte byte4;
        [FieldOffset(5)] public byte byte5;
        [FieldOffset(6)] public byte byte6;
        [FieldOffset(7)] public byte byte7;
        [FieldOffset(8)] public byte byte8;
        [FieldOffset(9)] public byte byte9;
        [FieldOffset(10)] public byte byte10;
        [FieldOffset(11)] public byte byte11;
        [FieldOffset(12)] public byte byte12;
        [FieldOffset(13)] public byte byte13;
        [FieldOffset(14)] public byte byte14;
        [FieldOffset(15)] public byte byte15;
        [FieldOffset(0)] public decimal value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct DateTimeUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(4)] public byte byte4;
        [FieldOffset(5)] public byte byte5;
        [FieldOffset(6)] public byte byte6;
        [FieldOffset(7)] public byte byte7;
        [FieldOffset(0)] public DateTime value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct GuidUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(4)] public byte byte4;
        [FieldOffset(5)] public byte byte5;
        [FieldOffset(6)] public byte byte6;
        [FieldOffset(7)] public byte byte7;
        [FieldOffset(8)] public byte byte8;
        [FieldOffset(9)] public byte byte9;
        [FieldOffset(10)] public byte byte10;
        [FieldOffset(11)] public byte byte11;
        [FieldOffset(12)] public byte byte12;
        [FieldOffset(13)] public byte byte13;
        [FieldOffset(14)] public byte byte14;
        [FieldOffset(15)] public byte byte15;
        [FieldOffset(0)] public Guid value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct TimeSpanUnion
    {
        [FieldOffset(0)] public byte byte0;
        [FieldOffset(1)] public byte byte1;
        [FieldOffset(2)] public byte byte2;
        [FieldOffset(3)] public byte byte3;
        [FieldOffset(4)] public byte byte4;
        [FieldOffset(5)] public byte byte5;
        [FieldOffset(6)] public byte byte6;
        [FieldOffset(7)] public byte byte7;
        [FieldOffset(0)] public TimeSpan value;
    }
}