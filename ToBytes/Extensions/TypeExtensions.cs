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

        public static Type GetListTypeFromObj<T>(this T list)
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
    }
}