using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class OpenBracketOperator : UnaryOperator
    {
        private OpenBracketOperator() : base ('(', 1, Associative.None) { }

        public readonly static OpenBracketOperator Singleton = new OpenBracketOperator();

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken == Operator.CloseBracket)
                throw new ParseException("Open bracket can be after close bracket");
            else if (previousToken is Number<int> _ || previousToken is Number<double> _)
                throw new ParseException("Open bracket can be after number");
            return this;
        }
    }
}
