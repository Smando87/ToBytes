using System;

namespace ToBytes.Cache
{
    internal static class CacherSingleton
    {
        private static readonly Lazy<Cacher> _instance = new(() => new Cacher());
        public static Cacher Instance => _instance.Value;
    }
}