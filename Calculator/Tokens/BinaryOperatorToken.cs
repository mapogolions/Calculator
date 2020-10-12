using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class BinaryOperatorToken : OperatorToken
    {
        public BinaryOperatorToken(char sign, int precedence, Associative associative)
            : base(sign, precedence, associative) { }

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken is null)
                throw new ParseException("Binary operator can be first");
            if (Equals(previousToken, OperatorToken.OpenBracket))
                throw new ParseException("Binary operator can't be follow after open bracket");
            return previousToken switch
            {
                BinaryOperatorToken _ => throw new ParseException("Consecutive binary operators"),
                UnaryOperatorToken op when op != OperatorToken.CloseBracket => throw new ParseException(
                    "Binary operator can't be follow after unary operator"),
                _ => this
            };
        }
    }
}
