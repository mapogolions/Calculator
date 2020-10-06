using System.Collections.Generic;
using System.Linq;

namespace Calculator.Tokens
{
    public class Operator : IToken
    {
        public static IList<Operator> AvailableOperators { get; } = new List<Operator>();

        private Operator(char sign, int precedence, Associative associative = Associative.Left,
            OperatorKinds operatorKinds = OperatorKinds.Binary)
        {
            Sign = sign;
            Precedence = precedence;
            Associative = associative;
            OperatorKinds = operatorKinds;
            AvailableOperators.Add(this);
        }

        public bool HasMultipleAssociativeForms =>
            AvailableOperators.Count(x => x.Sign == Sign) > 1;

        public char Sign { get; }
        public int Precedence { get; }
        public Associative Associative { get; }
        public OperatorKinds OperatorKinds { get; }

        public static readonly Operator Plus = new Operator('+', 2);
        public static readonly Operator Minus = new Operator('-', 2);
        public static readonly Operator Positive = new Operator('+', 3, Associative.Right, OperatorKinds.Unary);
        public static readonly Operator Negative = new Operator('-', 3, Associative.Right, OperatorKinds.Unary);
        public static readonly Operator Times = new Operator('*', 4);
        public static readonly Operator Divide = new Operator('/', 4);
        public static readonly Operator Power = new Operator('^', 5, Associative.Right);
        public static readonly Operator OpenBracket = new Operator('(', 1, Associative.Right, OperatorKinds.Unary);
        public static readonly Operator CloseBracket = new Operator(')', 1, Associative.Right, OperatorKinds.Unary);
    }
}
