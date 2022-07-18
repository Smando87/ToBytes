using System;
using System.Text;

namespace ToBytes
{
    public static class ConvertExtensions
    {
        private static IntUnion intUnion;

        public static void Init()
        {
            intUnion = new IntUnion();
        }

        public static bool ToBool(this byte[] bytes)
        {
            return bytes[0] != 0;
        }

        public static bool? ToBoolNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            return bytes[0] != 0;
        }

        public static byte ToByte(this byte[] bytes)
        {
            return bytes[0];
        }

        public static byte? ToByteNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            return bytes[0];
        }

        public static byte[] ToBytes(int value)
        {
            intUnion.value = value;
            byte[]? res = new[]
            {
                intUnion.byte0, intUnion.byte1, intUnion.byte2, intUnion.byte3
            };
            return res;
        }

        public static byte[] ToBytes(int? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0
                };
            }

            IntUnion longUnion = new IntUnion();
            longUnion.value = (int)value;
            byte[]? res = new[]
            {
                longUnion.byte0, longUnion.byte1, longUnion.byte2, longUnion.byte3
            };
            return res;
        }

        public static byte[] ToBytes(long value)
        {
            LongUnion longUnion = new LongUnion();
            longUnion.value = value;
            byte[]? res = new[]
            {
                longUnion.byte0, longUnion.byte1, longUnion.byte2, longUnion.byte3, longUnion.byte4, longUnion.byte5,
                longUnion.byte6, longUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(long? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            LongUnion longUnion = new LongUnion();
            longUnion.value = value.Value;
            byte[]? res = new[]
            {
                longUnion.byte0, longUnion.byte1, longUnion.byte2, longUnion.byte3, longUnion.byte4, longUnion.byte5,
                longUnion.byte6, longUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(float value)
        {
            FloatUnion floatUnion = new FloatUnion();
            floatUnion.value = value;
            byte[]? res = new[]
            {
                floatUnion.byte0, floatUnion.byte1, floatUnion.byte2, floatUnion.byte3
            };
            return res;
        }

        public static byte[] ToBytes(float? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0
                };
            }

            FloatUnion floatUnion = new FloatUnion();
            floatUnion.value = value.Value;
            byte[]? res = new[]
            {
                floatUnion.byte0, floatUnion.byte1, floatUnion.byte2, floatUnion.byte3
            };
            return res;
        }

        public static byte[] ToBytes(double value)
        {
            DoubleUnion doubleUnion = new DoubleUnion();
            doubleUnion.value = value;
            byte[]? res = new[]
            {
                doubleUnion.byte0, doubleUnion.byte1, doubleUnion.byte2, doubleUnion.byte3, doubleUnion.byte4,
                doubleUnion.byte5, doubleUnion.byte6, doubleUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(double? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            DoubleUnion doubleUnion = new DoubleUnion();
            doubleUnion.value = value.Value;
            byte[]? res = new[]
            {
                doubleUnion.byte0, doubleUnion.byte1, doubleUnion.byte2, doubleUnion.byte3, doubleUnion.byte4,
                doubleUnion.byte5, doubleUnion.byte6, doubleUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(decimal value)
        {
            DecimalUnion decimalUnion = new DecimalUnion();
            decimalUnion.value = value;
            byte[]? res = new[]
            {
                decimalUnion.byte0, decimalUnion.byte1, decimalUnion.byte2, decimalUnion.byte3, decimalUnion.byte4,
                decimalUnion.byte5, decimalUnion.byte6, decimalUnion.byte7, decimalUnion.byte8, decimalUnion.byte9,
                decimalUnion.byte10, decimalUnion.byte11, decimalUnion.byte12, decimalUnion.byte13, decimalUnion.byte14,
                decimalUnion.byte15
            };
            return res;
        }

        public static byte[] ToBytes(decimal? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            DecimalUnion decimalUnion = new DecimalUnion();
            decimalUnion.value = value.Value;
            byte[]? res = new[]
            {
                decimalUnion.byte0, decimalUnion.byte1, decimalUnion.byte2, decimalUnion.byte3, decimalUnion.byte4,
                decimalUnion.byte5, decimalUnion.byte6, decimalUnion.byte7, decimalUnion.byte8, decimalUnion.byte9,
                decimalUnion.byte10, decimalUnion.byte11, decimalUnion.byte12, decimalUnion.byte13, decimalUnion.byte14,
                decimalUnion.byte15
            };
            return res;
        }

        public static byte[] ToBytes(string value)
        {
            byte[]? res = Encoding.UTF8.GetBytes(value);
            return res;
        }


        public static byte[] ToBytes(bool value)
        {
            byte[]? res = new[]
            {
                value ? (byte)1 : (byte)0
            };
            return res;
        }

        public static byte[] ToBytes(bool? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0
                };
            }

            byte[]? res = new[]
            {
                value.Value ? (byte)1 : (byte)0
            };
            return res;
        }

        public static byte[] ToBytes(byte value)
        {
            byte[]? res = new[]
            {
                value
            };
            return res;
        }

        public static byte[] ToBytes(byte? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0
                };
            }

            byte[]? res = new[]
            {
                value.Value
            };
            return res;
        }

        public static byte[] ToBytes(char value)
        {
            CharUnion charUnion = new CharUnion();
            charUnion.value = value;
            byte[]? res = new[]
            {
                charUnion.byte0, charUnion.byte1
            };
            return res;
        }

        public static byte[] ToBytes(char? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0
                };
            }

            CharUnion charUnion = new CharUnion();
            charUnion.value = value.Value;
            byte[]? res = new[]
            {
                charUnion.byte0, charUnion.byte1
            };
            return res;
        }

        public static byte[] ToBytes(short value)
        {
            ShortUnion shortUnion = new ShortUnion();
            shortUnion.value = value;
            byte[]? res = new[]
            {
                shortUnion.byte0, shortUnion.byte1
            };

            return res;
        }

        public static byte[] ToBytes(sbyte value)
        {
            SByteUnion sByteUnion = new SByteUnion();
            sByteUnion.value = value;
            byte[]? res = new[]
            {
                sByteUnion.byte0
            };

            return res;
        }

        public static byte[] ToBytes(short? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0
                };
            }

            ShortUnion shortUnion = new ShortUnion();
            shortUnion.value = value.Value;
            byte[]? res = new[]
            {
                shortUnion.byte0, shortUnion.byte1
            };
            return res;
        }

        public static byte[] ToBytes(ushort value)
        {
            UShortUnion shortUnion = new UShortUnion();
            shortUnion.value = value;
            byte[]? res = new[]
            {
                shortUnion.byte0, shortUnion.byte1
            };

            return res;
        }

        public static byte[] ToBytes(ushort? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0
                };
            }

            UShortUnion shortUnion = new UShortUnion();
            shortUnion.value = value.Value;
            byte[]? res = new[]
            {
                shortUnion.byte0, shortUnion.byte1
            };
            return res;
        }

        public static byte[] ToBytes(uint value)
        {
            UIntUnion longUnion = new UIntUnion();
            longUnion.value = value;
            byte[]? res = new[]
            {
                longUnion.byte0, longUnion.byte1, longUnion.byte2, longUnion.byte3
            };
            return res;
        }

        public static byte[] ToBytes(uint? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0
                };
            }

            UIntUnion longUnion = new UIntUnion();
            longUnion.value = value.Value;
            byte[]? res = new[]
            {
                longUnion.byte0, longUnion.byte1, longUnion.byte2, longUnion.byte3
            };
            return res;
        }

        public static byte[] ToBytes(ulong value)
        {
            ULongUnion longUnion = new ULongUnion();
            longUnion.value = value;
            byte[]? res = new[]
            {
                longUnion.byte0, longUnion.byte1, longUnion.byte2, longUnion.byte3, longUnion.byte4, longUnion.byte5,
                longUnion.byte6, longUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(ulong? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            ULongUnion longUnion = new ULongUnion();
            longUnion.value = value.Value;
            byte[]? res = new[]
            {
                longUnion.byte0, longUnion.byte1, longUnion.byte2, longUnion.byte3, longUnion.byte4, longUnion.byte5,
                longUnion.byte6, longUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(DateTime value)
        {
            DateTimeUnion dateTimeUnion = new DateTimeUnion();
            dateTimeUnion.value = value;
            byte[]? res = new[]
            {
                dateTimeUnion.byte0, dateTimeUnion.byte1, dateTimeUnion.byte2, dateTimeUnion.byte3, dateTimeUnion.byte4,
                dateTimeUnion.byte5, dateTimeUnion.byte6, dateTimeUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(DateTime? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            DateTimeUnion dateTimeUnion = new DateTimeUnion();
            dateTimeUnion.value = value.Value;
            byte[]? res = new[]
            {
                dateTimeUnion.byte0, dateTimeUnion.byte1, dateTimeUnion.byte2, dateTimeUnion.byte3, dateTimeUnion.byte4,
                dateTimeUnion.byte5, dateTimeUnion.byte6, dateTimeUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(TimeSpan value)
        {
            TimeSpanUnion timeSpanUnion = new TimeSpanUnion();
            timeSpanUnion.value = value;
            byte[]? res = new[]
            {
                timeSpanUnion.byte0, timeSpanUnion.byte1, timeSpanUnion.byte2, timeSpanUnion.byte3, timeSpanUnion.byte4,
                timeSpanUnion.byte5, timeSpanUnion.byte6, timeSpanUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(TimeSpan? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            TimeSpanUnion timeSpanUnion = new TimeSpanUnion();
            timeSpanUnion.value = value.Value;
            byte[]? res = new[]
            {
                timeSpanUnion.byte0, timeSpanUnion.byte1, timeSpanUnion.byte2, timeSpanUnion.byte3, timeSpanUnion.byte4,
                timeSpanUnion.byte5, timeSpanUnion.byte6, timeSpanUnion.byte7
            };
            return res;
        }

        public static byte[] ToBytes(Guid value)
        {
            GuidUnion guidUnion = new GuidUnion();
            guidUnion.value = value;
            byte[]? res = new[]
            {
                guidUnion.byte0, guidUnion.byte1, guidUnion.byte2, guidUnion.byte3, guidUnion.byte4, guidUnion.byte5,
                guidUnion.byte6, guidUnion.byte7, guidUnion.byte8, guidUnion.byte9, guidUnion.byte10, guidUnion.byte11,
                guidUnion.byte12, guidUnion.byte13, guidUnion.byte14, guidUnion.byte15
            };
            return res;
        }

        public static byte[] ToBytes(Guid? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            GuidUnion guidUnion = new GuidUnion();
            guidUnion.value = value.Value;
            byte[]? res = new[]
            {
                guidUnion.byte0, guidUnion.byte1, guidUnion.byte2, guidUnion.byte3, guidUnion.byte4, guidUnion.byte5,
                guidUnion.byte6, guidUnion.byte7, guidUnion.byte8, guidUnion.byte9, guidUnion.byte10, guidUnion.byte11,
                guidUnion.byte12, guidUnion.byte13, guidUnion.byte14, guidUnion.byte15
            };
            return res;
        }

        public static byte[] ToBytes2(int value)
        {
            IntUnion longUnion = new IntUnion
            {
                value = value
            };
            byte[]? res = new[]
            {
                longUnion.byte0, longUnion.byte1, longUnion.byte2, longUnion.byte3
            };
            return res;
        }

        public static char ToChar(this byte[] bytes)
        {
            CharUnion charUnion = new CharUnion();
            charUnion.byte0 = bytes[0];
            charUnion.byte1 = bytes[1];
            return charUnion.value;
        }

        public static char? ToCharNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            CharUnion charUnion = new CharUnion();
            charUnion.byte0 = bytes[0];
            charUnion.byte1 = bytes[1];
            return charUnion.value;
        }

        public static DateTime ToDateTime(this byte[] bytes)
        {
            DateTimeUnion dateTimeUnion = new DateTimeUnion();
            dateTimeUnion.byte0 = bytes[0];
            dateTimeUnion.byte1 = bytes[1];
            dateTimeUnion.byte2 = bytes[2];
            dateTimeUnion.byte3 = bytes[3];
            dateTimeUnion.byte4 = bytes[4];
            dateTimeUnion.byte5 = bytes[5];
            dateTimeUnion.byte6 = bytes[6];
            dateTimeUnion.byte7 = bytes[7];
            return dateTimeUnion.value;
        }

        public static DateTime? ToDateTimeNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            DateTimeUnion dateTimeUnion = new DateTimeUnion();
            dateTimeUnion.byte0 = bytes[0];
            dateTimeUnion.byte1 = bytes[1];
            dateTimeUnion.byte2 = bytes[2];
            dateTimeUnion.byte3 = bytes[3];
            dateTimeUnion.byte4 = bytes[4];
            dateTimeUnion.byte5 = bytes[5];
            dateTimeUnion.byte6 = bytes[6];
            dateTimeUnion.byte7 = bytes[7];
            return dateTimeUnion.value;
        }

        public static decimal ToDecimal(this byte[] bytes)
        {
            DecimalUnion decimalUnion = new DecimalUnion();
            decimalUnion.byte0 = bytes[0];
            decimalUnion.byte1 = bytes[1];
            decimalUnion.byte2 = bytes[2];
            decimalUnion.byte3 = bytes[3];
            decimalUnion.byte4 = bytes[4];
            decimalUnion.byte5 = bytes[5];
            decimalUnion.byte6 = bytes[6];
            decimalUnion.byte7 = bytes[7];
            decimalUnion.byte8 = bytes[8];
            decimalUnion.byte9 = bytes[9];
            decimalUnion.byte10 = bytes[10];
            decimalUnion.byte11 = bytes[11];
            decimalUnion.byte12 = bytes[12];
            decimalUnion.byte13 = bytes[13];
            decimalUnion.byte14 = bytes[14];
            decimalUnion.byte15 = bytes[15];
            return decimalUnion.value;
        }

        public static decimal? ToDecimalNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            DecimalUnion decimalUnion = new DecimalUnion();
            decimalUnion.byte0 = bytes[0];
            decimalUnion.byte1 = bytes[1];
            decimalUnion.byte2 = bytes[2];
            decimalUnion.byte3 = bytes[3];
            decimalUnion.byte4 = bytes[4];
            decimalUnion.byte5 = bytes[5];
            decimalUnion.byte6 = bytes[6];
            decimalUnion.byte7 = bytes[7];
            decimalUnion.byte8 = bytes[8];
            decimalUnion.byte9 = bytes[9];
            decimalUnion.byte10 = bytes[10];
            decimalUnion.byte11 = bytes[11];
            decimalUnion.byte12 = bytes[12];
            decimalUnion.byte13 = bytes[13];
            decimalUnion.byte14 = bytes[14];
            decimalUnion.byte15 = bytes[15];
            return decimalUnion.value;
        }

        public static double ToDouble(this byte[] bytes)
        {
            DoubleUnion doubleUnion = new DoubleUnion();
            doubleUnion.byte0 = bytes[0];
            doubleUnion.byte1 = bytes[1];
            doubleUnion.byte2 = bytes[2];
            doubleUnion.byte3 = bytes[3];
            doubleUnion.byte4 = bytes[4];
            doubleUnion.byte5 = bytes[5];
            doubleUnion.byte6 = bytes[6];
            doubleUnion.byte7 = bytes[7];
            return doubleUnion.value;
        }

        public static double? ToDoubleNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            DoubleUnion doubleUnion = new DoubleUnion();
            doubleUnion.byte0 = bytes[0];
            doubleUnion.byte1 = bytes[1];
            doubleUnion.byte2 = bytes[2];
            doubleUnion.byte3 = bytes[3];
            doubleUnion.byte4 = bytes[4];
            doubleUnion.byte5 = bytes[5];
            doubleUnion.byte6 = bytes[6];
            doubleUnion.byte7 = bytes[7];
            return doubleUnion.value;
        }

        public static float ToFloat(this byte[] bytes)
        {
            FloatUnion floatUnion = new FloatUnion();
            floatUnion.byte0 = bytes[0];
            floatUnion.byte1 = bytes[1];
            floatUnion.byte2 = bytes[2];
            floatUnion.byte3 = bytes[3];
            return floatUnion.value;
        }

        public static float? ToFloatNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            FloatUnion floatUnion = new FloatUnion();
            floatUnion.byte0 = bytes[0];
            floatUnion.byte1 = bytes[1];
            floatUnion.byte2 = bytes[2];
            floatUnion.byte3 = bytes[3];
            return floatUnion.value;
        }

        public static Guid ToGuid(this byte[] bytes)
        {
            GuidUnion guidUnion = new GuidUnion();
            guidUnion.byte0 = bytes[0];
            guidUnion.byte1 = bytes[1];
            guidUnion.byte2 = bytes[2];
            guidUnion.byte3 = bytes[3];
            guidUnion.byte4 = bytes[4];
            guidUnion.byte5 = bytes[5];
            guidUnion.byte6 = bytes[6];
            guidUnion.byte7 = bytes[7];
            guidUnion.byte8 = bytes[8];
            guidUnion.byte9 = bytes[9];
            guidUnion.byte10 = bytes[10];
            guidUnion.byte11 = bytes[11];
            guidUnion.byte12 = bytes[12];
            guidUnion.byte13 = bytes[13];
            guidUnion.byte14 = bytes[14];
            guidUnion.byte15 = bytes[15];
            return guidUnion.value;
        }

        public static Guid? ToGuidNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            GuidUnion guidUnion = new GuidUnion();
            guidUnion.byte0 = bytes[0];
            guidUnion.byte1 = bytes[1];
            guidUnion.byte2 = bytes[2];
            guidUnion.byte3 = bytes[3];
            guidUnion.byte4 = bytes[4];
            guidUnion.byte5 = bytes[5];
            guidUnion.byte6 = bytes[6];
            guidUnion.byte7 = bytes[7];
            guidUnion.byte8 = bytes[8];
            guidUnion.byte9 = bytes[9];
            guidUnion.byte10 = bytes[10];
            guidUnion.byte11 = bytes[11];
            guidUnion.byte12 = bytes[12];
            guidUnion.byte13 = bytes[13];
            guidUnion.byte14 = bytes[14];
            guidUnion.byte15 = bytes[15];
            return guidUnion.value;
        }

        public static int ToInt(this byte[] bytes)
        {
            IntUnion longUnion = new IntUnion();
            longUnion.byte0 = bytes[0];
            longUnion.byte1 = bytes[1];
            longUnion.byte2 = bytes[2];
            longUnion.byte3 = bytes[3];
            return longUnion.value;
        }

        public static int? ToIntNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            IntUnion longUnion = new IntUnion();
            longUnion.byte0 = bytes[0];
            longUnion.byte1 = bytes[1];
            longUnion.byte2 = bytes[2];
            longUnion.byte3 = bytes[3];
            return longUnion.value;
        }

        public static long ToLong(this byte[] bytes)
        {
            LongUnion longUnion = new LongUnion();
            longUnion.byte0 = bytes[0];
            longUnion.byte1 = bytes[1];
            longUnion.byte2 = bytes[2];
            longUnion.byte3 = bytes[3];
            longUnion.byte4 = bytes[4];
            longUnion.byte5 = bytes[5];
            longUnion.byte6 = bytes[6];
            longUnion.byte7 = bytes[7];
            return longUnion.value;
        }

        public static long? ToLongNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            LongUnion longUnion = new LongUnion();
            longUnion.byte0 = bytes[0];
            longUnion.byte1 = bytes[1];
            longUnion.byte2 = bytes[2];
            longUnion.byte3 = bytes[3];
            longUnion.byte4 = bytes[4];
            longUnion.byte5 = bytes[5];
            longUnion.byte6 = bytes[6];
            longUnion.byte7 = bytes[7];
            return longUnion.value;
        }

        public static sbyte ToSByte(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return 0;
            }

            SByteUnion sByteUnion = new SByteUnion();
            sByteUnion.byte0 = bytes[0];

            return sByteUnion.value;
        }

        public static short ToShort(this byte[] bytes)
        {
            ShortUnion shortUnion = new ShortUnion();
            shortUnion.byte0 = bytes[0];
            shortUnion.byte1 = bytes[1];
            return shortUnion.value;
        }

        public static short? ToShortNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            ShortUnion shortUnion = new ShortUnion();
            shortUnion.byte0 = bytes[0];
            shortUnion.byte1 = bytes[1];
            return shortUnion.value;
        }

        public static string ToString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static TimeSpan ToTimeSpan(this byte[] bytes)
        {
            TimeSpanUnion timeSpanUnion = new TimeSpanUnion();
            timeSpanUnion.byte0 = bytes[0];
            timeSpanUnion.byte1 = bytes[1];
            timeSpanUnion.byte2 = bytes[2];
            timeSpanUnion.byte3 = bytes[3];
            timeSpanUnion.byte4 = bytes[4];
            timeSpanUnion.byte5 = bytes[5];
            timeSpanUnion.byte6 = bytes[6];
            timeSpanUnion.byte7 = bytes[7];
            return timeSpanUnion.value;
        }

        public static TimeSpan? ToTimeSpanNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            TimeSpanUnion timeSpanUnion = new TimeSpanUnion();
            timeSpanUnion.byte0 = bytes[0];
            timeSpanUnion.byte1 = bytes[1];
            timeSpanUnion.byte2 = bytes[2];
            timeSpanUnion.byte3 = bytes[3];
            timeSpanUnion.byte4 = bytes[4];
            timeSpanUnion.byte5 = bytes[5];
            timeSpanUnion.byte6 = bytes[6];
            timeSpanUnion.byte7 = bytes[7];
            return timeSpanUnion.value;
        }

        public static uint ToUInt(this byte[] bytes)
        {
            UIntUnion uintUnion = new UIntUnion();
            uintUnion.byte0 = bytes[0];
            uintUnion.byte1 = bytes[1];
            uintUnion.byte2 = bytes[2];
            uintUnion.byte3 = bytes[3];
            return uintUnion.value;
        }

        public static uint? ToUIntNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            UIntUnion uintUnion = new UIntUnion();
            uintUnion.byte0 = bytes[0];
            uintUnion.byte1 = bytes[1];
            uintUnion.byte2 = bytes[2];
            uintUnion.byte3 = bytes[3];
            return uintUnion.value;
        }

        public static ulong ToULong(this byte[] bytes)
        {
            ULongUnion longUnion = new ULongUnion();
            longUnion.byte0 = bytes[0];
            longUnion.byte1 = bytes[1];
            longUnion.byte2 = bytes[2];
            longUnion.byte3 = bytes[3];
            longUnion.byte4 = bytes[4];
            longUnion.byte5 = bytes[5];
            longUnion.byte6 = bytes[6];
            longUnion.byte7 = bytes[7];
            return longUnion.value;
        }

        public static ulong? ToULongNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            ULongUnion longUnion = new ULongUnion();
            longUnion.byte0 = bytes[0];
            longUnion.byte1 = bytes[1];
            longUnion.byte2 = bytes[2];
            longUnion.byte3 = bytes[3];
            longUnion.byte4 = bytes[4];
            longUnion.byte5 = bytes[5];
            longUnion.byte6 = bytes[6];
            longUnion.byte7 = bytes[7];
            return longUnion.value;
        }

        public static ushort ToUShort(this byte[] bytes)
        {
            UShortUnion shortUnion = new UShortUnion();
            shortUnion.byte0 = bytes[0];
            shortUnion.byte1 = bytes[1];
            return shortUnion.value;
        }

        public static ushort? ToUShortNullable(this byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return null;
            }

            UShortUnion shortUnion = new UShortUnion();
            shortUnion.byte0 = bytes[0];
            shortUnion.byte1 = bytes[1];
            return shortUnion.value;
        }
    }
}