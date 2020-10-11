using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class UnaryOperatorToken : OperatorToken
    {
        public UnaryOperatorToken(char sign, int precedence, Associative associative)
            : base(sign, precedence, associative) { }

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken == OperatorToken.CloseBracket)
                throw new ParseException("Invalid associativity detection. After close bracket shold be binary operator");
            return this;
        }
    }
}
