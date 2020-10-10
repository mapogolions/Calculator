using Calculator.Tokens;

namespace Calculator.Parsers
{
    public class NumberResolver : ITokensResolver
    {
        public bool TryResolve(string chunk, IToken previousToken, out IToken token)
        {
            token = null;
            if (int.TryParse(chunk, out var num))
            {
                token = new Number<int>(num).EnsureIsValid(previousToken);
                return true;
            }
            if (double.TryParse(chunk, out var floatingPoint))
            {
                token = new Number<double>(floatingPoint).EnsureIsValid(previousToken);
                return true;
            }
            return false;
        }
    }
}
