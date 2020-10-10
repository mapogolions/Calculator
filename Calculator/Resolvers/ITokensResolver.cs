using Calculator.Tokens;

namespace Calculator.Parsers
{
    public interface ITokensResolver
    {
        bool TryResolve(string chunk, IToken previousToken, out IToken token);
    }
}
