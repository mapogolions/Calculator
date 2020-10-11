using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class CloseBracketToken : UnaryOperatorToken
    {
        private CloseBracketToken() : base (')', 1, Associative.Right) { }

        public static readonly CloseBracketToken Singleton = new CloseBracketToken();

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken is null)
                throw new ParseException("Close bracket can't be first token");
            if (previousToken == OperatorToken.OpenBracket)
                throw new ParseException("Close bracket can't be follow after open bracket");
            else if (previousToken is UnaryOperatorToken _ && previousToken != OperatorToken.CloseBracket)
                throw new ParseException("Close bracket can't be follow after unary operator");
            else if (previousToken is BinaryOperatorToken _)
                throw new ParseException("Close bracket can't be follow after binary operator");
            return this;
        }
    }
}
