using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using ToBytes;

[SimpleJob(RuntimeMoniker.Net50)]
[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkConvert
{
    private List<byte> list;


    [Benchmark(Description = "convert_bool_to_bytes")]
    public void bool_to_bytes()
    {
        bool val = true;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToBool();
    }


    [Benchmark(Description = "convert_bool_to_bytes_unsafe")]
    public void bool_to_bytes_unsafe()
    {
        bool val = true;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToBoolUnsafe();
    }

    [Benchmark(Description = "convert_bool_to_bytes2")]
    public void bool_to_bytes2()
    {
        bool val = true;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToBool();
    }

    [Benchmark(Description = "convert_byte_to_bytes")]
    public void byte_to_bytes()
    {
        byte val = 1;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToByte();
    }


    [Benchmark(Description = "convert_byte_to_bytes_unsafe")]
    public void byte_to_bytes_unsafe()
    {
        byte val = 1;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToByteUnsafe();
    }


    [Benchmark(Description = "convert_char_to_bytes")]
    public void char_to_bytes()
    {
        char val = '1';
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToChar();
    }

    [Benchmark(Description = "convert_char_to_bytes_unsafe")]
    public void char_to_bytes_unsafe()
    {
        char val = '1';
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToCharUnsafe();
    }


    [Benchmark(Description = "convert_dateTime_to_bytes")]
    public void datetime_to_bytes()
    {
        DateTime val = new DateTime(2022, 1, 1);
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToDateTime();
    }


    [Benchmark(Description = "convert_datetime_to_bytes_unsafe")]
    public void datetime_to_bytes_unsafe()
    {
        DateTime val = new DateTime(2022, 1, 1);
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToDateTimeUnsafe();
    }

    [Benchmark(Description = "convert_decimal_to_bytes")]
    public void decimal_to_bytes()
    {
        decimal val = 1.1m;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToDecimal();
    }

    //
    [Benchmark(Description = "convert_decimal_to_bytes_unsafe")]
    public void decimal_to_bytes_unsafe()
    {
        decimal val = 1.1m;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToDecimalUnsafe();
    }


    [Benchmark(Description = "convert_double_to_bytes")]
    public void double_to_bytes()
    {
        double val = 1.0;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToDouble();
    }

    [Benchmark(Description = "convert_double_to_bytes_unsafe")]
    public void double_to_bytes_unsafe()
    {
        double val = 1.0;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToDoubleUnsafe();
    }


    [Benchmark(Description = "convert_float_to_bytes")]
    public void float_to_bytes()
    {
        float val = 1.0f;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToFloat();
    }

    [Benchmark(Description = "convert_float_to_bytes_unsafe")]
    public void float_to_bytes_unsafe()
    {
        float val = 1.0f;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToFloatUnsafe();
    }

    [Benchmark(Description = "convert_guid_to_bytes")]
    public void guid_to_bytes()
    {
        Guid val = Guid.NewGuid();
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToGuid();
    }

    [Benchmark(Description = "convert_guid_to_bytes_unsafe")]
    public void guid_to_bytes_unsafe()
    {
        Guid val = Guid.NewGuid();
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToGuid();
    }


    [Benchmark(Description = "convert_int_to_bytes")]
    public void int_to_bytes()
    {
        int val = 1;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToInt();
    }


    [Benchmark(Description = "convert_int_to_bytes_unsafe")]
    public void int_to_bytes_unsafe()
    {
        int val = 1;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToIntUnsafe();
    }


    [Benchmark(Description = "convert_long_to_bytes")]
    public void long_to_bytes()
    {
        long val = 1L;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToLong();
    }


    [Benchmark(Description = "convert_long_to_bytes_unsafe")]
    public void long_to_bytes_unsafe()
    {
        long val = 1L;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToLongUnsafe();
    }

    [Benchmark(Description = "convert_short_to_bytes")]
    public void short_to_bytes()
    {
        short val = 1;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToShort();
    }


    [Benchmark(Description = "convert_short_to_bytes_unsafe")]
    public void short_to_bytes_unsafe()
    {
        short val = 1;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToShortUnsafe();
    }


    [Benchmark(Description = "convert_string_to_bytes")]
    public void string_to_bytes()
    {
        string? val = "1";
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = ConvertUtils.ToString(bytes);
    }


    [Benchmark(Description = "convert_string_to_bytes_unsafe")]
    public void string_to_bytes_unsafe()
    {
        string? val = "1";
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToStringUnsafe();
    }


    [Benchmark(Description = "convert_timespan_to_bytes")]
    public void timespan_to_bytes()
    {
        TimeSpan val = new TimeSpan(1, 1, 1);
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToTimeSpan();
    }


    [Benchmark(Description = "convert_timespan_to_bytes_unsafe")]
    public void timespan_to_bytes_unsafe()
    {
        TimeSpan val = new TimeSpan(1, 1, 1);
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToTimeSpanUnsafe();
    }

    [Benchmark(Description = "convert_uint_to_bytes")]
    public void uint_to_bytes()
    {
        int val = 1;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToUInt();
    }


    [Benchmark(Description = "convert_uint_to_bytes_unsafe")]
    public void uint_to_bytes_unsafe()
    {
        int val = 1;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToUIntUnsafe();
    }


    [Benchmark(Description = "convert_ulong_to_bytes")]
    public void ulong_to_bytes()
    {
        ulong val = 1;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToULong();
    }

    [Benchmark(Description = "convert_ulong_to_bytes_unsafe")]
    public void ulong_to_bytes_unsafe()
    {
        ulong val = 1;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToULongUnsafe();
    }


    [Benchmark(Description = "convert_ushort_to_bytes")]
    public void ushort_to_bytes()
    {
        ushort val = 1;
        byte[]? bytes = ConvertExtensions.ToBytes(val);

        //var val2 = bytes.ToUShort();
    }

    [Benchmark(Description = "convert_ushort_to_bytes_unsafe")]
    public void ushort_to_bytes_unsafe()
    {
        ushort val = 1;
        byte[]? bytes = val.ToBytesUnsafe();

        //var val2 = bytes.ToUShortUnsafe();
    }
}