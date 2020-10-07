using System.Collections.Generic;
using System.Linq;

namespace Calculator.Tokens
{
    public class Operator : IToken
    {
        public static IList<Operator> AvailableOperators { get; } = new List<Operator>();

        protected Operator(char sign, int precedence, Associative associative,
            OperatorKinds kind)
        {
            Sign = sign;
            Precedence = precedence;
            Associative = associative;
            Kind = kind;
            AvailableOperators.Add(this);
        }
        public char Sign { get; }
        public int Precedence { get; }
        public Associative Associative { get; }
        public OperatorKinds Kind { get; }

        public bool HasMultipleAssociativeForms =>
            AvailableOperators.Count(x => x.Sign == Sign) > 1;

        public override string ToString() => $"{Sign}";

        public static readonly Operator Plus = new BinaryOperator('+', 2, Associative.Left);
        public static readonly Operator Minus = new BinaryOperator('-', 2, Associative.Left);
        public static readonly Operator Positive = new UnaryOperator('+', 3, Associative.Right);
        public static readonly Operator Negative = new UnaryOperator('-', 3, Associative.Right);
        public static readonly Operator Times = new BinaryOperator('*', 4, Associative.Left);
        public static readonly Operator Divide = new BinaryOperator('/', 4, Associative.Left);
        public static readonly Operator Power = new BinaryOperator('^', 5, Associative.Right);
        public static readonly Operator OpenBracket = new UnaryOperator('(', 1, Associative.None);
        public static readonly Operator CloseBracket = new UnaryOperator(')', 1, Associative.None);
    }
}
