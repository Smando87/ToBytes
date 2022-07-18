using System;
using System.Collections.Generic;
using System.Reflection;

namespace ToBytes.Cache
{
    public interface IPropertyCallAdapter<T>
    {
        object InvokeGet(T obj);
        //add void InvokeSet(TThis @this, object value) if necessary
    }

    public class PropertyCallAdapter<TThis, TResult> : IPropertyCallAdapter<TThis>
    {
        private readonly Func<TThis, TResult> _getterInvocation;

        public PropertyCallAdapter(Func<TThis, TResult> getterInvocation)
        {
            _getterInvocation = getterInvocation;
        }

        public object InvokeGet(TThis @this)
        {
            return _getterInvocation.Invoke(@this);
        }
    }

    public class PropertyCallAdapterProvider<TThis>
    {
        private static readonly Dictionary<string, IPropertyCallAdapter<TThis>> _instances =
            new();

        public static IPropertyCallAdapter<TThis> GetInstance(string forPropertyName)
        {
            IPropertyCallAdapter<TThis> instance;
            if (!_instances.TryGetValue(forPropertyName, out instance))
            {
                PropertyInfo? property = typeof(TThis).GetProperty(
                    forPropertyName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                MethodInfo getMethod;
                Delegate getterInvocation = null;
                if (property != null && (getMethod = property.GetGetMethod(true)) != null)
                {
                    Type? openGetterType = typeof(Func<,>);
                    Type? concreteGetterType = openGetterType
                        .MakeGenericType(typeof(TThis), property.PropertyType);

                    getterInvocation =
                        Delegate.CreateDelegate(concreteGetterType, null, getMethod);
                }

                Type? openAdapterType = typeof(PropertyCallAdapter<,>);
                if (property != null)
                {
                    Type? concreteAdapterType = openAdapterType
                        .MakeGenericType(typeof(TThis), property.PropertyType);
                    instance = Activator
                            .CreateInstance(concreteAdapterType, getterInvocation)
                        as IPropertyCallAdapter<TThis>;

                    _instances.Add(forPropertyName, instance);
                }
            }
            else
            {
                return instance;
            }

            return instance;
        }
    }
}