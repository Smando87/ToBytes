using System;

namespace ToBytes.Converters
{
    internal class EnumStructConverter : IStructConverter
    {
        public int Version => 1;
        public int Size => sizeof(bool);
        public ValueType Type => ValueType.Struct;

        public byte[] ToBytes(object obj)
        {
            Enum value = (Enum)obj;
            var tp = value.GetTypeCode();
            object val = null;
            var res = new List<byte>()
            {
            };
            switch (tp)
            {
                case TypeCode.Empty:
                    throw new ArgumentOutOfRangeException();
                    break;
                case TypeCode.Object:
                    throw new ArgumentOutOfRangeException();
                    break;
                case TypeCode.DBNull:
                    throw new ArgumentOutOfRangeException();
                    break;
                case TypeCode.Boolean:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.Boolean));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((bool)val));
                    break;
                case TypeCode.Char:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.Char));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((Char)val));
                    break;
                case TypeCode.SByte:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.SByte));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((SByte)val));
                    break;
                case TypeCode.Byte:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.Byte));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((Byte)val));
                    break;
                case TypeCode.Int16:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.Int16));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((Int16)val));
                    break;
                case TypeCode.UInt16:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.UInt16));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((UInt16)val));
                    break;
                case TypeCode.Int32:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.Int32));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((Int32)val));
                    break;
                case TypeCode.UInt32:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.UInt32));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((UInt32)val));
                    break;
                case TypeCode.Int64:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.Int64));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((Int64)val));
                    break;
                case TypeCode.UInt64:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.UInt64));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((UInt64)val));
                    break;
                case TypeCode.Single:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.Single));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((Single)val));
                    break;
                case TypeCode.Double:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.Double));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((Double)val));
                    break;
                case TypeCode.Decimal:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.Decimal));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((Decimal)val));
                    break;
                case TypeCode.DateTime:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.DateTime));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((DateTime)val));
                    break;
                case TypeCode.String:
                    res.AddRange(ConvertExtensions.ToBytes((char)TypeCode.String));
                    val = Convert.ChangeType(value, value.GetTypeCode());
                    res.AddRange(ConvertExtensions.ToBytes((string)val));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return res.ToArray();
        }

        public (object, int) FromBytes(byte[] bytes)
        {
            var tp = (TypeCode)bytes.ToList().GetRange(0, 2).ToArray().ToChar();
            var toConvert = bytes.ToList().GetRange(2, bytes.Length - 2).ToArray();
            object res = null;
            switch (tp)
            {
                case TypeCode.Empty:
                    throw new ArgumentOutOfRangeException();
                    break;
                case TypeCode.Object:
                    throw new ArgumentOutOfRangeException();
                    break;
                case TypeCode.DBNull:
                    throw new ArgumentOutOfRangeException();
                    break;
                case TypeCode.Boolean:
                    res = toConvert.ToBool();
                    break;
                case TypeCode.Char:
                    res = toConvert.ToChar();
                    break;
                case TypeCode.SByte:
                    res = toConvert.ToSByte();
                    break;
                case TypeCode.Byte:
                    res = toConvert.ToByte();
                    break;
                case TypeCode.Int16:
                    res = toConvert.ToShort();
                    break;
                case TypeCode.UInt16:
                    res = toConvert.ToUShort();
                    break;
                case TypeCode.Int32:
                    res = toConvert.ToInt();
                    break;
                case TypeCode.UInt32:
                    res = toConvert.ToUInt();
                    break;
                case TypeCode.Int64:
                    res = toConvert.ToLong();
                    break;
                case TypeCode.UInt64:
                    res = toConvert.ToLong();
                    break;
                case TypeCode.Single:
                    res = toConvert.ToDouble();
                    break;
                case TypeCode.Double:
                    res = toConvert.ToDouble();
                    break;
                case TypeCode.Decimal:
                    res = toConvert.ToDecimal();
                    break;
                case TypeCode.DateTime:
                    res = toConvert.ToDateTime();
                    break;
                case TypeCode.String:
                    res = toConvert.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return (Convert.ChangeType(res, tp), Size);
        }

        public (object, int) FromBytes(byte[] bytes, Type destType)
        {
            (var res, var size) = FromBytes(bytes);

            return (res, size);
        }
    }
}