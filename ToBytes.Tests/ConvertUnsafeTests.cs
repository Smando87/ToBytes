using NUnit.Framework;
using System;

namespace ToBytes.Tests
{
    public class ConvertNullableTest
    {
        [Test]
        public void bool_to_bytes_nullable_unsafe()
        {
            bool? val = true;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(1, bytes.Length);
            bool? val2 = bytes.ToBoolNullableUnsafe();
            Assert.AreEqual(val, val2);
        }


        [Test]
        public void bool_to_bytes_unsafe()
        {
            bool val = true;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(1, bytes.Length);
            bool val2 = bytes.ToBoolUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void byte_to_bytes_unsafe()
        {
            byte val = 1;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(1, bytes.Length);
            byte val2 = bytes.ToByteUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void char_to_bytes_nullable_unsafe()
        {
            char? val = '1';
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(2, bytes.Length);
            char? val2 = bytes.ToCharNullableUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void char_to_bytes_unsafe()
        {
            char val = '1';
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(2, bytes.Length);
            char val2 = bytes.ToCharUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void datetime_to_bytes_nullable_unsafe()
        {
            DateTime? val = new DateTime(1, 1, 1);
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(8, bytes.Length);
            DateTime? val2 = bytes.ToDateTimeNullableUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void datetime_to_bytes_unsafe()
        {
            DateTime val = new DateTime(2022, 1, 1);
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(8, bytes.Length);
            DateTime val2 = bytes.ToDateTimeUnsafe();
            Assert.AreEqual(val, val2);
            Assert.AreEqual(val2.Year, 2022);
            Assert.AreEqual(val2.Month, 1);
            Assert.AreEqual(val2.Day, 1);
        }

        [Test]
        public void decimal_to_bytes_nullable_unsafe()
        {
            decimal? val = 1.1m;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(16, bytes.Length);
            decimal? val2 = bytes.ToDecimalNullableUnsafe();
            Assert.AreEqual(val, val2);
        }

        // [Test]
        // public void date_to_bytes_unsafe()
        // {
        //     var val = new DateTime(1,1,1);
        //     var bytes = ConvertUtilsUnsafe.ToBytesUnsafe(val);
        //     Assert.AreEqual(8, bytes.Length);
        //     var val2 = bytes.ToDateTime();
        //     Assert.AreEqual(val,val2 );
        // }

        // [Test]
        // public void guid_to_bytes_unsafe()
        // {
        //     var val = Guid.NewGuid();
        //     var bytes = ConvertUtilsUnsafe.ToBytesUnsafe(val);
        //     Assert.AreEqual(16, bytes.Length);
        //     var val2 = bytes.ToGuid();
        //     Assert.AreEqual(val,val2 );
        // }
        //
        [Test]
        public void decimal_to_bytes_unsafe()
        {
            decimal val = 1.1m;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(16, bytes.Length);
            decimal val2 = bytes.ToDecimalUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void double_to_bytes_nullable_unsafe()
        {
            double? val = 1.0;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(8, bytes.Length);
            double? val2 = bytes.ToDoubleNullableUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void double_to_bytes_unsafe()
        {
            double val = 1.0;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(8, bytes.Length);
            double val2 = bytes.ToDoubleUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void float_to_bytes_nullable_unsafe()
        {
            float? val = 1.0f;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(4, bytes.Length);
            float? val2 = bytes.ToFloatNullableUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void float_to_bytes_unsafe()
        {
            float val = 1.0f;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(4, bytes.Length);
            float val2 = bytes.ToFloatUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void guid_to_bytes_unsafe()
        {
            Guid val = Guid.NewGuid();
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(16, bytes.Length);
            Guid val2 = bytes.ToGuid();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void int_to_bytes_nullable_unsafe()
        {
            int? val = 1;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(4, bytes.Length);
            int? val2 = bytes.ToIntNullableUnsafe();
            Assert.AreEqual(val, val2);
        }


        [Test]
        public void int_to_bytes_unsafe()
        {
            int val = 1;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(4, bytes.Length);
            int val2 = bytes.ToIntUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void long_to_bytes_nullable_unsafe()
        {
            long? val = 1L;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(8, bytes.Length);
            long? val2 = bytes.ToLongNullableUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void long_to_bytes_unsafe()
        {
            long val = 1L;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(8, bytes.Length);
            long val2 = bytes.ToLongUnsafe();
            Assert.AreEqual(val, val2);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void short_to_bytes_nullable_unsafe()
        {
            short? val = 1;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(2, bytes.Length);
            short? val2 = bytes.ToShortNullableUnsafe();
            Assert.AreEqual(val, val2);
        }


        [Test]
        public void short_to_bytes_unsafe()
        {
            short val = 1;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(2, bytes.Length);
            short val2 = bytes.ToShortUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void string_to_bytes_unsafe()
        {
            string? val = "123456";
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(12, bytes.Length);
            string? val2 = bytes.ToStringUnsafe();
            Assert.AreEqual(val.Length, val2.Length);
            Assert.AreEqual(val, val2);
        }


        [Test]
        public void timespan_to_bytes_unsafe()
        {
            TimeSpan val = new TimeSpan(1, 1, 1);
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(8, bytes.Length);
            TimeSpan val2 = bytes.ToTimeSpanUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void uint_to_bytes_nullable_unsafe()
        {
            uint? val = 1;
            byte[]? bytes = ConvertExtensionsUnsafe.ToBytesUnsafe(val);
            Assert.AreEqual(4, bytes.Length);
            uint? val2 = bytes.ToUIntNullableUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void uint_to_bytes_unsafe()
        {
            uint val = 1;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(4, bytes.Length);
            uint val2 = bytes.ToUIntUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void ulong_to_bytes_nullable_unsafe()
        {
            ulong? val = 1;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(8, bytes.Length);
            ulong? val2 = bytes.ToULongNullableUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void ulong_to_bytes_unsafe()
        {
            ulong val = 1;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(8, bytes.Length);
            ulong val2 = bytes.ToULongUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void ushort_to_bytes_nullable_unsafe()
        {
            ushort? val = 1;
            byte[]? bytes = ConvertExtensionsUnsafe.ToBytesUnsafe(val);
            Assert.AreEqual(2, bytes.Length);
            ushort? val2 = bytes.ToUShortNullableUnsafe();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void ushort_to_bytes_unsafe()
        {
            ushort val = 1;
            byte[]? bytes = val.ToBytesUnsafe();
            Assert.AreEqual(2, bytes.Length);
            ushort val2 = bytes.ToUShortUnsafe();
            Assert.AreEqual(val, val2);
        }
    }
}