namespace Calculator.Tokens
{
    public class UnaryOperator : Operator
    {
        public UnaryOperator(char sign, int precedence, Associative associative)
            : base(sign, precedence, associative, OperatorKinds.Unary) { }
    }
}
