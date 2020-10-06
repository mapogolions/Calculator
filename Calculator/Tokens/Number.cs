using System;

namespace Calculator.Tokens
{
    public class Number<T> : IToken, IEquatable<Number<T>> where T : struct
    {
        public Number(T value)
        {
            Value = value;
        }
        public T Value { get;  }

        public int Precedence => byte.MaxValue;

        public bool Equals(Number<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Number<T>) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString() => Value.ToString();
    }
}
