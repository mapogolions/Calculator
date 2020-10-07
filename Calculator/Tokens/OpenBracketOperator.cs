using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class OpenBracketOperator : UnaryOperator
    {
        private OpenBracketOperator() : base ('(', 1, Associative.None) { }

        public readonly static OpenBracketOperator Singleton = new OpenBracketOperator();

        public override IToken EnsureIsValid(IToken token)
        {
            if (token == Operator.CloseBracket)
                throw new ParserException("Open bracket can be after close bracket");
            else if (token is Number<int> _ || token is Number<double> _)
                throw new ParserException("Open bracket can be after number");
            return this;
        }
    }
}
