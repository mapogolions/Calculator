using Calculator.Exceptions;

namespace Calculator.Tokens
{
    public class UnaryOperator : Operator
    {
        public UnaryOperator(char sign, int precedence, Associative associative)
            : base(sign, precedence, associative) { }

        public override IToken EnsureIsValid(IToken previousToken)
        {
            if (previousToken == Operator.CloseBracket)
                throw new ParserException("Invalid associativity detection. After close bracket shold be binary operator");
            return this;
        }
    }
}
