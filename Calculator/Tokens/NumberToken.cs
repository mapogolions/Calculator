using System;
using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class NumberToken<T> : IToken, IEquatable<NumberToken<T>> where T : struct
    {
        public NumberToken(T value)
        {
            Value = value;
        }
        public T Value { get;  }

        public int Precedence => 10;

        public Associative Associative => Associative.None;

        public bool Equals(NumberToken<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((NumberToken<T>) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public IToken EnsureIsValid(IToken previousToken)
        {
            if (Equals(previousToken, OperatorToken.CloseBracket))
                throw new ParseException("Number can't be follow after close bracket");
            if (previousToken is NumberToken<int>_ || previousToken is NumberToken<double> _)
                throw new ParseException("Number cant' be follow after number");
            return this;
        }

        public override string ToString() => Value.ToString();
    }
}
