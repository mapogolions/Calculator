using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class OpenBracketToken : UnaryOperatorToken
    {
        private OpenBracketToken() : base ('(', 1, Associative.None) { }

        public static readonly OpenBracketToken Singleton = new OpenBracketToken();

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken == OperatorToken.CloseBracket)
                throw new ParseException("Open bracket can be after close bracket");
            else if (previousToken is NumberToken<int> _ || previousToken is NumberToken<double> _)
                throw new ParseException("Open bracket can be after number");
            return this;
        }
    }
}
