using System;

namespace ToBytes
{
    internal class ResizableArray<T>
    {
        private T[] m_array;

        public ResizableArray(int? initialCapacity = null)
        {
            m_array = new T[initialCapacity ?? 4]; // or whatever
        }

        internal T[] InternalArray => m_array;

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (Count == m_array.Length)
            {
                Array.Resize(ref m_array, m_array.Length * 2);
            }

            m_array[Count++] = element;
        }
    }
}