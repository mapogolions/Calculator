using Calculator.Tokens;

namespace Calculator.TokenResolvers
{
    public class NumberTokenResolver : ITokensResolver
    {
        public bool TryResolve(string chunk, IToken previousToken, out IToken token)
        {
            token = null;
            if (int.TryParse(chunk, out var num))
            {
                token = new NumberToken<int>(num).EnsureIsValid(previousToken);
                return true;
            }
            if (double.TryParse(chunk, out var floatingPoint))
            {
                token = new NumberToken<double>(floatingPoint).EnsureIsValid(previousToken);
                return true;
            }
            return false;
        }
    }
}
