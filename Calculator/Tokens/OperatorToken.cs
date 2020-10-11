using System.Collections.Generic;
using System.Linq;

namespace Calculator.Tokens
{
    public abstract class OperatorToken : IToken
    {
        public static IList<OperatorToken> AllAvailable { get; } = new List<OperatorToken>();
        public static char[] Signs => AllAvailable.Select(x => x.Sign).Distinct().ToArray();

        protected OperatorToken(char sign, int precedence, Associative associative)
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

        public static readonly OperatorToken Plus = new BinaryOperatorToken('+', 2, Associative.Left);
        public static readonly OperatorToken Minus = new BinaryOperatorToken('-', 2, Associative.Left);
        public static readonly OperatorToken Positive = new UnaryOperatorToken('+', 3, Associative.Right);
        public static readonly OperatorToken Negative = new UnaryOperatorToken('-', 3, Associative.Right);
        public static readonly OperatorToken Times = new BinaryOperatorToken('*', 4, Associative.Left);
        public static readonly OperatorToken Divide = new BinaryOperatorToken('/', 4, Associative.Left);
        public static readonly OperatorToken Power = new BinaryOperatorToken('^', 5, Associative.Right);
        public static readonly OperatorToken OpenBracket = OpenBracketToken.Singleton;
        public static readonly OperatorToken CloseBracket = CloseBracketToken.Singleton;
    }
}
