using Calculator.Tokens;

namespace Calculator.Parsers
{
    public interface ITokenParser
    {
        bool TryParse(string chunk, IToken previousToken, out IToken token);
    }
}
