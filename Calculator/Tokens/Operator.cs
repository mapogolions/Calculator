using System.Collections.Generic;
using System.Linq;

namespace Calculator.Tokens
{
    public abstract class Operator : IToken
    {
        public static IList<Operator> AllAvailable { get; } = new List<Operator>();
        public static char[] Signs => AllAvailable.Select(x => x.Sign).Distinct().ToArray();

        protected Operator(char sign, int precedence, Associative associative)
        {
            Sign = sign;
            Precedence = precedence;
            Associative = associative;
            AllAvailable.Add(this);
        }
        public char Sign { get; }
        public int Precedence { get; }
        public Associative Associative { get; }
        public bool IsMultiAssociative =>
            AllAvailable.Count(x => x.Sign == Sign) > 1;


        public override string ToString() => $"{Sign}";

        public abstract IToken EnsureIsValid(IToken previousToken);

        public static readonly Operator Plus = new BinaryOperator('+', 2, Associative.Left);
        public static readonly Operator Minus = new BinaryOperator('-', 2, Associative.Left);
        public static readonly Operator Positive = new UnaryOperator('+', 3, Associative.Right);
        public static readonly Operator Negative = new UnaryOperator('-', 3, Associative.Right);
        public static readonly Operator Times = new BinaryOperator('*', 4, Associative.Left);
        public static readonly Operator Divide = new BinaryOperator('/', 4, Associative.Left);
        public static readonly Operator Power = new BinaryOperator('^', 5, Associative.Right);
        public static readonly Operator OpenBracket = OpenBracketOperator.Singleton;
        public static readonly Operator CloseBracket = CloseBracketOperator.Singleton;
    }
}
