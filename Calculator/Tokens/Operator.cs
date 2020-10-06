using System.Collections.Generic;
using System.Linq;

namespace Calculator.Tokens
{
    public class Operator : IToken
    {
        private Operator(char sign, int precedence, Associative associative)
        {
            Sign = sign;
            Precedence = precedence;
            Associative = associative;
            AvailableOperators.Add(this);
        }

        public static IList<Operator> AvailableOperators { get; } = new List<Operator>();
        public bool IsMultiAssociative =>
            AvailableOperators.Count(x => x.Sign == Sign) > 1;

        public char Sign { get; }
        public int Precedence { get; }
        public Associative Associative { get; }

        public static readonly Operator Positive = new Operator('+', 2, Associative.Right);
        public static readonly Operator Negative = new Operator('-', 2, Associative.Right);
        public static readonly Operator Plus = new Operator('+', 2, Associative.Left);
        public static readonly Operator Minus = new Operator('-', 2, Associative.Left);
        public static readonly Operator Times = new Operator('*', 4, Associative.Left);
        public static readonly Operator Divide = new Operator('/', 4, Associative.Left);
        public static readonly Operator Power = new Operator('^', 5, Associative.Right);
        public static readonly Operator OpenBracket = new Operator('(', 1, Associative.Right);
        public static readonly Operator CloseBracket = new Operator(')', 1, Associative.Right);
    }
}
