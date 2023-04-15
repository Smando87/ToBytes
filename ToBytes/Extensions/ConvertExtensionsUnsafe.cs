using System;
using System.Runtime.InteropServices;

namespace ToBytes
{
    public static class ConvertExtensionsUnsafe
    {
        public static bool? ToBoolNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0
            })
            {
                return null;
            }

            bool res = false;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(bool*)ptr;
                }
            }

            return res;
        }

        public static bool ToBoolUnsafe(this byte[] bytes)
        {
            bool res = false;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(bool*)ptr;
                }
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this long value)
        {
            byte[]? res = new byte[8];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this long? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            byte[]? res = new byte[8];
            var value2 = (long)value;
            unsafe
            {
                Marshal.Copy(new IntPtr(&value2), res, 0, res.Length);
            }

            return res;
        }
        
        public static byte[] ToBytesUnsafe(this uint? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0
                };
            }

            byte[]? res = new byte[4];
            var value2 = (uint)value;
            unsafe
            {
                Marshal.Copy(new IntPtr(&value2), res, 0, res.Length);
            }

            return res;
        }
        
        public static byte[] ToBytesUnsafe(this uint value)
        {
           
            byte[]? res = new byte[4];
            
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this ushort value)
        {
            byte[]? res = new byte[2];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }
        
        public static byte[] ToBytesUnsafe(this ushort? value)
        {
            
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0
                };
            }
            byte[]? res = new byte[2];
            var value2 = (ushort)value;
            unsafe
            {
                Marshal.Copy(new IntPtr(&value2), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this ulong value)
        {
            byte[]? res = new byte[8];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this ulong? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            byte[]? res = new byte[8];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this int value)
        {
            byte[]? res = new byte[4];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this int? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0
                };
            }

            byte[]? res = new byte[4];
            int value2 = (int)value;
            unsafe
            {
                Marshal.Copy(new IntPtr(&value2), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this short value)
        {
            byte[]? res = new byte[2];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this short? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0
                };
            }

            byte[]? res = new byte[2];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this byte value)
        {
            byte[]? res = new byte[1];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this byte? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0
                };
            }

            byte[]? res = new byte[1];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this float value)
        {
            byte[]? res = new byte[4];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this float? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0
                };
            }

            byte[]? res = new byte[4];
            var value2 = (float)value;
            unsafe
            {
                Marshal.Copy(new IntPtr(&value2), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this double value)
        {
            byte[]? res = new byte[8];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this double? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            byte[]? res = new byte[8];
            double value2 = (double)value;
            unsafe
            {
                Marshal.Copy(new IntPtr(&value2), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this decimal value)
        {
            byte[]? res = new byte[16];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this decimal? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            byte[]? res = new byte[16];
            decimal value2 = (decimal)value;
            unsafe
            {
                Marshal.Copy(new IntPtr(&value2), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this bool value)
        {
            byte[]? res = new byte[1];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this bool? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0
                };
            }

            byte[]? res = new byte[1];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this char value)
        {
            byte[]? res = new byte[2];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this char? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0
                };
            }

            byte[]? res = new byte[2];
            char value2 = value.Value;
            unsafe
            {
                Marshal.Copy(new IntPtr(&value2), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this string value)
        {
            byte[]? res = new byte[value.Length * 2];

            unsafe
            {
                fixed (void* ptr = value)
                {
                    Marshal.Copy(new IntPtr(ptr), res, 0, value.Length * 2);
                }
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this DateTime value)
        {
            byte[]? res = new byte[8];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this DateTime? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            byte[]? res = new byte[8];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this Guid value)
        {
            byte[]? res = new byte[16];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this Guid? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            byte[]? res = new byte[16];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this TimeSpan value)
        {
            byte[]? res = new byte[8];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte[] ToBytesUnsafe(this TimeSpan? value)
        {
            if (!value.HasValue)
            {
                return new byte[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0
                };
            }

            byte[]? res = new byte[8];
            unsafe
            {
                Marshal.Copy(new IntPtr(&value), res, 0, res.Length);
            }

            return res;
        }

        public static byte ToByteUnsafe(this byte[] bytes)
        {
            byte res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(byte*)ptr;
                }
            }

            return res;
        }

        public static char? ToCharNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0
            })
            {
                return null;
            }

            char? res = '\0';
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(char*)ptr;
                }
            }

            return res;
        }


        public static char ToCharUnsafe(this byte[] bytes)
        {
            char res = '\0';
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(char*)ptr;
                }
            }

            return res;
        }

        public static DateTime? ToDateTimeNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0, 0, 0, 0, 0, 0, 0
            })
            {
                return null;
            }

            DateTime? res = new DateTime?();
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(DateTime?*)ptr;
                }
            }

            return res;
        }

        public static DateTime ToDateTimeUnsafe(this byte[] bytes)
        {
            DateTime res = new DateTime();
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(DateTime*)ptr;
                }
            }

            return res;
        }

        public static decimal? ToDecimalNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            })
            {
                return null;
            }

            decimal res = 0m;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(decimal*)ptr;
                }
            }

            return res;
        }

        public static decimal ToDecimalUnsafe(this byte[] bytes)
        {
            decimal res = 0m;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(decimal*)ptr;
                }
            }

            return res;
        }

        public static double? ToDoubleNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0, 0, 0, 0, 0, 0, 0
            })
            {
                return null;
            }

            double res = 0d;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(double*)ptr;
                }
            }

            return res;
        }

        public static double ToDoubleUnsafe(this byte[] bytes)
        {
            double res = 0d;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(double*)ptr;
                }
            }

            return res;
        }

        public static float? ToFloatNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0, 0, 0
            })
            {
                return null;
            }

            float res = 0f;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(float*)ptr;
                }
            }

            return res;
        }

        public static float ToFloatUnsafe(this byte[] bytes)
        {
            float res = 0f;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(float*)ptr;
                }
            }

            return res;
        }

        public static int? ToIntNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0, 0, 0
            })
            {
                return null;
            }

            int res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(int*)ptr;
                }
            }

            return res;
        }

        public static int ToIntUnsafe(this byte[] bytes)
        {
            int res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(int*)ptr;
                }
            }

            return res;
        }

        public static long? ToLongNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0, 0, 0, 0, 0, 0, 0
            })
            {
                return null;
            }

            long res = 0L;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(long*)ptr;
                }
            }

            return res;
        }

        public static long ToLongUnsafe(this byte[] bytes)
        {
            long res = 0L;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(long*)ptr;
                }
            }

            return res;
        }

        public static short? ToShortNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0
            })
            {
                return null;
            }

            short res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(short*)ptr;
                }
            }

            return res;
        }

        public static short ToShortUnsafe(this byte[] bytes)
        {
            short res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(short*)ptr;
                }
            }

            return res;
        }

        public static string ToStringUnsafe(this byte[] bytes)
        {
            string? res = "";
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    char* cptr = (char*)ptr;
                    res = new string(cptr, 0, bytes.Length / 2);
                }
            }

            return res;
        }

        public static TimeSpan ToTimeSpanUnsafe(this byte[] bytes)
        {
            TimeSpan res = new TimeSpan();
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(TimeSpan*)ptr;
                }
            }

            return res;
        }

        public static uint? ToUIntNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0, 0, 0
            })
            {
                return null;
            }

            uint res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(uint*)ptr;
                }
            }

            return res;
        }

        public static uint ToUIntUnsafe(this byte[] bytes)
        {
            uint res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(uint*)ptr;
                }
            }

            return res;
        }

        public static ulong? ToULongNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0, 0, 0, 0, 0, 0, 0
            })
            {
                return null;
            }

            ulong res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(ulong*)ptr;
                }
            }

            return res;
        }

        public static ulong ToULongUnsafe(this byte[] bytes)
        {
            ulong res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(ulong*)ptr;
                }
            }

            return res;
        }

        public static ushort? ToUShortNullableUnsafe(this byte[] bytes)
        {
            if (bytes.Length == 0 || bytes == new byte[]
            {
                0, 0
            })
            {
                return null;
            }

            ushort res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(ushort*)ptr;
                }
            }

            return res;
        }

        public static ushort ToUShortUnsafe(this byte[] bytes)
        {
            ushort res = 0;
            unsafe
            {
                fixed (void* ptr = bytes)
                {
                    res = *(ushort*)ptr;
                }
            }

            return res;
        }
    }
}