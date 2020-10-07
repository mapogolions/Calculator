using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class CloseBracketOperator : UnaryOperator
    {
        private CloseBracketOperator() : base (')', 1, Associative.None) { }

        public static readonly CloseBracketOperator Singleton = new CloseBracketOperator();

        public override IToken EnsureIsValid(IToken token)
        {
            if (token is null)
                throw new ParserException("Close bracket can't be first token");
            if (token == Operator.OpenBracket)
                throw new ParserException("Close bracket can't be follow after open bracket");
            else if (token is UnaryOperator _ && token != Operator.CloseBracket)
                throw new ParserException("Close bracket can't be follow after unary operator");
            else if (token is BinaryOperator _)
                throw new ParserException("Close bracket can't be follow after binary operator");
            return this;
        }
    }
}
