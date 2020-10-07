namespace Calculator.Tokens
{
    public class BinaryOperator : Operator
    {
        public BinaryOperator(char sign, int precedence, Associative associative)
            : base(sign, precedence, associative, OperatorKinds.Binary) { }
    }
}
