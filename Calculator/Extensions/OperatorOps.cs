using Calculator.Tokens;

namespace Calculator.Extensions
{
    public static class OperatorOps
    {
        public static Associative HeuristicAssociativity(this OperatorToken @this, IToken previousToken)
        {
            if (!@this.IsMultiAssociative) return @this.Associative;
            return previousToken switch
            {
                OperatorToken { Sign: ')' } => Associative.Left,
                NumberToken<int> _ => Associative.Left,
                NumberToken<double> _ => Associative.Left,
                _ => Associative.Right
            };
        }
    }
}
