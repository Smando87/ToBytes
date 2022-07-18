using NUnit.Framework;
using System;

namespace ToBytes.Tests
{
    public class ConvertTest
    {
        [Test]
        public void bool_to_bytes()
        {
            bool val = true;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(1, bytes.Length);
            bool val2 = bytes.ToBool();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void bool_to_bytes_nullable()
        {
            bool? val = true;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(1, bytes.Length);
            bool? val2 = bytes.ToBoolNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void byte_to_bytes()
        {
            byte val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(1, bytes.Length);
            byte val2 = bytes.ToByte();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void byte_to_bytes_nullable()
        {
            byte? val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(1, bytes.Length);
            byte? val2 = bytes.ToByteNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void char_to_bytes()
        {
            char val = '1';
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(2, bytes.Length);
            char val2 = bytes.ToChar();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void char_to_bytes_nullable()
        {
            char? val = '1';
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(2, bytes.Length);
            char? val2 = bytes.ToCharNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void datetime_to_bytes()
        {
            DateTime val = new DateTime(2022, 1, 1);
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            DateTime val2 = bytes.ToDateTime();
            Assert.AreEqual(val, val2);
            Assert.AreEqual(val2.Year, 2022);
            Assert.AreEqual(val2.Month, 1);
            Assert.AreEqual(val2.Day, 1);
        }

        [Test]
        public void datetime_to_bytes_nullable()
        {
            DateTime? val = new DateTime(1, 1, 1);
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            DateTime? val2 = bytes.ToDateTimeNullable();
            Assert.AreEqual(val, val2);
        }

        // [Test]
        // public void date_to_bytes()
        // {
        //     var val = new DateTime(1,1,1);
        //     var bytes = ConvertUtils.ToBytes(val);
        //     Assert.AreEqual(8, bytes.Length);
        //     var val2 = bytes.ToDateTime();
        //     Assert.AreEqual(val,val2 );
        // }

        // [Test]
        // public void guid_to_bytes()
        // {
        //     var val = Guid.NewGuid();
        //     var bytes = ConvertUtils.ToBytes(val);
        //     Assert.AreEqual(16, bytes.Length);
        //     var val2 = bytes.ToGuid();
        //     Assert.AreEqual(val,val2 );
        // }
        //
        [Test]
        public void decimal_to_bytes()
        {
            decimal val = 1.1m;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(16, bytes.Length);
            decimal val2 = bytes.ToDecimal();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void decimal_to_bytes_nullable()
        {
            decimal? val = 1.1m;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(16, bytes.Length);
            decimal? val2 = bytes.ToDecimalNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void double_to_bytes()
        {
            double val = 1.0;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            double val2 = bytes.ToDouble();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void double_to_bytes_nullable()
        {
            double? val = 1.0;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            double? val2 = bytes.ToDoubleNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void float_to_bytes()
        {
            float val = 1.0f;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(4, bytes.Length);
            float val2 = bytes.ToFloat();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void float_to_bytes_nullable()
        {
            float? val = 1.0f;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(4, bytes.Length);
            float? val2 = bytes.ToFloatNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void guid_to_bytes()
        {
            Guid val = Guid.NewGuid();
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(16, bytes.Length);
            Guid val2 = bytes.ToGuid();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void guid_to_bytes_nullable()
        {
            Guid? val = Guid.NewGuid();
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(16, bytes.Length);
            Guid? val2 = bytes.ToGuidNullable();
            Assert.AreEqual(val, val2);
        }


        [Test]
        public void int_to_bytes()
        {
            int val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(4, bytes.Length);
            int val2 = bytes.ToInt();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void int_to_bytes_nullable()
        {
            int? val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(4, bytes.Length);
            int? val2 = bytes.ToIntNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void long_to_bytes()
        {
            long val = 1L;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            long val2 = bytes.ToLong();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void long_to_bytes_nullable()
        {
            long? val = 1L;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            long? val2 = bytes.ToLongNullable();
            Assert.AreEqual(val, val2);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void short_to_bytes()
        {
            short val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(2, bytes.Length);
            short val2 = bytes.ToShort();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void short_to_bytes_nullable()
        {
            short? val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(2, bytes.Length);
            short? val2 = bytes.ToShortNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void string_to_bytes()
        {
            string? val = "1";
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(1, bytes.Length);
            string? val2 = ConvertExtensions.ToString(bytes);
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void timespan_to_bytes()
        {
            TimeSpan val = new TimeSpan(1, 1, 1);
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            TimeSpan val2 = bytes.ToTimeSpan();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void timespan_to_bytes_nullable()
        {
            TimeSpan? val = new TimeSpan(1, 1, 1);
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            TimeSpan? val2 = bytes.ToTimeSpanNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void uint_to_bytes()
        {
            int val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(4, bytes.Length);
            uint val2 = bytes.ToUInt();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void uint_to_bytes_nullable()
        {
            uint? val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(4, bytes.Length);
            uint? val2 = bytes.ToUIntNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void ulong_to_bytes()
        {
            ulong val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            ulong val2 = bytes.ToULong();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void ulong_to_bytes_nullable()
        {
            ulong? val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(8, bytes.Length);
            ulong? val2 = bytes.ToULongNullable();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void ushort_to_bytes()
        {
            ushort val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(2, bytes.Length);
            ushort val2 = bytes.ToUShort();
            Assert.AreEqual(val, val2);
        }

        [Test]
        public void ushort_to_bytes_nullable()
        {
            ushort? val = 1;
            byte[]? bytes = ConvertExtensions.ToBytes(val);
            Assert.AreEqual(2, bytes.Length);
            ushort? val2 = bytes.ToUShortNullable();
            Assert.AreEqual(val, val2);
        }
    }
}