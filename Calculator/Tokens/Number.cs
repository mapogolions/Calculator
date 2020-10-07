using System;
using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class Number<T> : IToken, IEquatable<Number<T>> where T : struct
    {
        public Number(T value)
        {
            Value = value;
        }
        public T Value { get;  }

        public int Precedence => 10;

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

        public IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken == Operator.CloseBracket)
                throw new ParserException("Number can't be follow after close bracket");
            if (previousToken is Number<int>_ || previousToken is Number<double> _)
                throw new ParserException("Number cant' be follow after number");
            return this;
        }

        public override string ToString() => Value.ToString();
    }
}
