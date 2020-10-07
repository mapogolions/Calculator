using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class BinaryOperator : Operator
    {
        public BinaryOperator(char sign, int precedence, Associative associative)
            : base(sign, precedence, associative, OperatorKinds.Binary) { }

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken is null)
                throw new ParserException("Binary operator can be first");
            return this;
        }
    }
}
