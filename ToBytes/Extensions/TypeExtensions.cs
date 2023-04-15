using System;
using System.Collections.Generic;
using System.Linq;

namespace ToBytes
{
    public static class TypeExtensions
    {
        public static Type GetListType(this Type list)
        {
            return list.GetGenericArguments().Single();
        }

        public static Type? GetListTypeFromObj<T>(this T list)
        {
            return list.GetType().GetGenericArguments().Single();
        }

        public static bool IsArray(this Type type)
        {
            return type.IsArray;
        }

        public static bool IsGenericList(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public static bool IsList(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public static bool IsStruct(this Type type)
        {
            return type.IsValueType && !type.IsEnum;
        }

        public static bool IsCustomStruct(this Type type)
        {
            var internalStructs = new List<Type>()
            {
                typeof(int),
                typeof(long),
                typeof(short),
                typeof(byte),
                typeof(sbyte),
                typeof(uint),
                typeof(ulong),
                typeof(ushort),
                typeof(bool),
                typeof(char),
                typeof(double),
                typeof(float),
                typeof(decimal),
                typeof(string),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid),
                typeof(object),
                typeof(void),
            };
            return !internalStructs.Any(ff => ff == type) && type.IsValueType && !type.IsEnum;
        }
    }
}