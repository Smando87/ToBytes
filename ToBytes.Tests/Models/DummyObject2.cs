using System;
using System.Collections.Generic;

namespace ObjectSerializer
{
    public class DummyObject3
    {
        public DateTime DateTime { get; set; }

        protected bool Equals(DummyObject3 other)
        {
            return DateTime.Equals(other.DateTime);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((DummyObject3)obj);
        }

        public override int GetHashCode()
        {
            return DateTime.GetHashCode();
        }
    }

    public class DummyObject2
    {
        public DummyObject2 ZDummyObjectC { get; set; }
        public int Integer { get; set; }

        public static IEqualityComparer<DummyObject2> ZDummyObjectCIntegerComparer { get; } =
            new ZDummyObjectCIntegerEqualityComparer();

        protected bool Equals(DummyObject2 other)
        {
            return Equals(ZDummyObjectC, other.ZDummyObjectC) && Integer == other.Integer;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((DummyObject2)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ZDummyObjectC, Integer);
        }

        public override string ToString()
        {
            return $"{nameof(ZDummyObjectC)}: {ZDummyObjectC}, {nameof(Integer)}: {Integer}";
        }

        private sealed class ZDummyObjectCIntegerEqualityComparer : IEqualityComparer<DummyObject2>
        {
            public bool Equals(DummyObject2 x, DummyObject2 y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.ZDummyObjectC.Equals((object?)y.ZDummyObjectC) && x.Integer == y.Integer;
            }

            public int GetHashCode(DummyObject2 obj)
            {
                return HashCode.Combine(obj.ZDummyObjectC, obj.Integer);
            }
        }
    }
}