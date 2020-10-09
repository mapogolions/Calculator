using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class BinaryOperator : Operator
    {
        public BinaryOperator(char sign, int precedence, Associative associative)
            : base(sign, precedence, associative) { }

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken is null)
                throw new ParseException("Binary operator can be first");
            if (previousToken == Operator.OpenBracket)
                throw new ParseException("Binary operator can't be follow after open bracket");
            if (previousToken is BinaryOperator _)
                throw new ParseException("Consecutive binary operators");
            if (previousToken is UnaryOperator op && op != Operator.CloseBracket)
                throw new ParseException("Binary operator can't be follow after unary operator");
            return this;
        }
    }
}
