using Calculator.Tokens;

namespace Calculator.Extensions
{
    public static class OperatorOps
    {
        public static Associative HeuristicAssociativity(this Operator @this, IToken previousToken)
        {
            if (!@this.IsMultiAssociative) return @this.Associative;
            return previousToken switch
            {
                Operator { Sign: ')' } => Associative.Left,
                Number<int> _ => Associative.Left,
                Number<double> _ => Associative.Left,
                _ => Associative.Right
            };
        }
    }
}
