using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ToBytes.Cache;

namespace ToBytes.Extensions
{
    public static class ObjectExtensions
    {
        public static object ConstructDictionary(Type KeyType, Type ValueType)
        {
            Type[] TemplateTypes =
            {
                KeyType, ValueType
            };
            Type DictionaryType = typeof(Dictionary<,>).MakeGenericType(TemplateTypes);

            return Activator.CreateInstance(DictionaryType);
        }

        public static object GetPropValue<T>(this object src, string propName)
        {
            IPropertyCallAdapter<T>? ist = PropertyCallAdapterProvider<T>.GetInstance(propName);
            return ist?.InvokeGet((T)src);
        }

        public static Array GetUnderlyingArray(this IList list)
        {
            FieldInfo? field = list.GetType().GetField("_items",
                BindingFlags.Instance |
                BindingFlags.NonPublic);
            return (Array)field.GetValue(list);
        }

        public static void SetPropValue(this object obj, string propName, object val)
        {
            PropertyInfo? prop = obj.GetType().GetProperty(propName);
            if (prop != null)
            {
                prop.SetValue(obj, val);
            }
        }
    }
}