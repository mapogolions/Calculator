using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class UnaryOperatorToken : OperatorToken
    {
        public UnaryOperatorToken(char sign, int precedence, Associative associative)
            : base(sign, precedence, associative) { }

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (Equals(previousToken, CloseBracket))
                throw new ParseException("Invalid associativity detection. After close bracket should be binary operator");
            return this;
        }
    }
}
