using Calculator.Tokens;

namespace Calculator.TokenResolvers
{
    public interface ITokensResolver
    {
        bool TryResolve(string chunk, IToken previousToken, out IToken token);
    }
}
