using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class CloseBracketOperator : UnaryOperator
    {
        private CloseBracketOperator() : base (')', 1, Associative.None) { }

        public static readonly CloseBracketOperator Singleton = new CloseBracketOperator();

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken is null)
                throw new ParserException("Close bracket can't be first token");
            if (previousToken == Operator.OpenBracket)
                throw new ParserException("Close bracket can't be follow after open bracket");
            else if (previousToken is UnaryOperator _ && previousToken != Operator.CloseBracket)
                throw new ParserException("Close bracket can't be follow after unary operator");
            else if (previousToken is BinaryOperator _)
                throw new ParserException("Close bracket can't be follow after binary operator");
            return this;
        }
    }
}
