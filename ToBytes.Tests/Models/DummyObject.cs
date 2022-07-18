using System;
using System.Collections.Generic;

namespace ObjectSerializer
{
    public class DummyObject
    {
        public DummyObject ZDummyObjectC { get; set; }
        public int Integer { get; set; }
        public int? IntegerN { get; set; }
        public int? Integer2 { get; set; }

        public decimal Decimal { get; set; }

        // public decimal? DecimalN { get; set; }
        // public decimal? Decimal2 { get; set; }
        //
        public float Float { get; set; }

        public float? FloatN { get; set; }

        //
        // public string String { get; set; }
        public short Short { get; set; }
        public short? ShortN { get; set; }
        public ushort UShort { get; set; }
        public ushort? UShortN { get; set; }
        public byte Byte { get; set; }
        public byte? ByteN { get; set; }
        public sbyte SByte { get; set; }
        public sbyte? SByteN { get; set; }
        public bool Bool { get; set; }
        public bool? BoolN { get; set; }
        public char Char { get; set; }
        public char? CharN { get; set; }

        public string String { get; set; }

        // public DateTime DateTime { get; set; }
        // public DateTime? DateTimeN { get; set; }
        // public DateTime? DateTime2 { get; set; }
        // public TimeSpan TimeSpan { get; set; }
        // public TimeSpan? TimeSpanN { get; set; }
        // public TimeSpan? TimeSpan2 { get; set; }
        public Guid Guid { get; set; }
        public Guid? GuidN { get; set; }
        public Guid? Guid2 { get; set; }

        public static IEqualityComparer<DummyObject> DummyObjectComparer { get; } = new DummyObjectEqualityComparer();
        public string String2 { get; set; }
        public DateTime DateTime { get; set; }

        public TimeSpan TimeSpan { get; set; }
        // public Uri Uri { get; set; }
        //
        // public byte[] ByteArray { get; set; }
        //

        protected bool Equals(DummyObject other)
        {
            return Equals(ZDummyObjectC, other.ZDummyObjectC) && Integer == other.Integer &&
                   IntegerN == other.IntegerN && Integer2 == other.Integer2 && Decimal == other.Decimal &&
                   Float.Equals(other.Float) && Nullable.Equals(FloatN, other.FloatN) && Short == other.Short &&
                   ShortN == other.ShortN && UShort == other.UShort && UShortN == other.UShortN && Byte == other.Byte &&
                   ByteN == other.ByteN && SByte == other.SByte && SByteN == other.SByteN && Bool == other.Bool &&
                   BoolN == other.BoolN && Char == other.Char && CharN == other.CharN && String == other.String &&
                   String2 == other.String2;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((DummyObject)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = ZDummyObjectC != null ? ZDummyObjectC.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ Integer;
                hashCode = (hashCode * 397) ^ IntegerN.GetHashCode();
                hashCode = (hashCode * 397) ^ Integer2.GetHashCode();
                hashCode = (hashCode * 397) ^ Decimal.GetHashCode();
                hashCode = (hashCode * 397) ^ Float.GetHashCode();
                hashCode = (hashCode * 397) ^ FloatN.GetHashCode();
                hashCode = (hashCode * 397) ^ Short.GetHashCode();
                hashCode = (hashCode * 397) ^ ShortN.GetHashCode();
                hashCode = (hashCode * 397) ^ UShort.GetHashCode();
                hashCode = (hashCode * 397) ^ UShortN.GetHashCode();
                hashCode = (hashCode * 397) ^ Byte.GetHashCode();
                hashCode = (hashCode * 397) ^ ByteN.GetHashCode();
                hashCode = (hashCode * 397) ^ SByte.GetHashCode();
                hashCode = (hashCode * 397) ^ SByteN.GetHashCode();
                hashCode = (hashCode * 397) ^ Bool.GetHashCode();
                hashCode = (hashCode * 397) ^ BoolN.GetHashCode();
                hashCode = (hashCode * 397) ^ Char.GetHashCode();
                hashCode = (hashCode * 397) ^ CharN.GetHashCode();
                hashCode = (hashCode * 397) ^ (String != null ? String.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (String2 != null ? String2.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(ZDummyObjectC)}: {ZDummyObjectC}, {nameof(Integer)}: {Integer}, {nameof(IntegerN)}: {IntegerN}, {nameof(Integer2)}: {Integer2}, {nameof(Decimal)}: {Decimal}, {nameof(Float)}: {Float}, {nameof(FloatN)}: {FloatN}, {nameof(Short)}: {Short}, {nameof(ShortN)}: {ShortN}, {nameof(UShort)}: {UShort}, {nameof(UShortN)}: {UShortN}, {nameof(Byte)}: {Byte}, {nameof(ByteN)}: {ByteN}, {nameof(SByte)}: {SByte}, {nameof(SByteN)}: {SByteN}, {nameof(Bool)}: {Bool}, {nameof(BoolN)}: {BoolN}, {nameof(Char)}: {Char}, {nameof(CharN)}: {CharN}, {nameof(String)}: {String}, {nameof(String2)}: {String2}";
        }

        private sealed class DummyObjectEqualityComparer : IEqualityComparer<DummyObject>
        {
            public bool Equals(DummyObject x, DummyObject y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.Integer == y.Integer && x.IntegerN == y.IntegerN && x.Integer2 == y.Integer2 &&
                       x.Decimal == y.Decimal && x.Float.Equals(y.Float) && Nullable.Equals(x.FloatN, y.FloatN) &&
                       x.Short == y.Short && x.ShortN == y.ShortN && x.UShort == y.UShort && x.UShortN == y.UShortN &&
                       x.Byte == y.Byte && x.ByteN == y.ByteN && x.SByte == y.SByte && x.SByteN == y.SByteN &&
                       x.Bool == y.Bool && x.BoolN == y.BoolN && x.Char == y.Char && x.CharN == y.CharN &&
                       x.String == y.String;
            }

            public int GetHashCode(DummyObject obj)
            {
                unchecked
                {
                    int hashCode = obj.Integer;
                    hashCode = (hashCode * 397) ^ obj.IntegerN.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Integer2.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Decimal.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Float.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.FloatN.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Short.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.ShortN.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.UShort.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.UShortN.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Byte.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.ByteN.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.SByte.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.SByteN.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Bool.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.BoolN.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Char.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.CharN.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.String != null ? obj.String.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }
    }
}