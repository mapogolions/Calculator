using System.Collections;
using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Test.Fixtures
{
    public class ValidTokensDataSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "-(17)",
                new List<IToken> { OperatorToken.Negative, OperatorToken.OpenBracket, new NumberToken<int>(17), OperatorToken.CloseBracket } };
            yield return new object[] { "+17",
                new List<IToken> { OperatorToken.Positive, new NumberToken<int>(17) } };
            yield return new object[] { "1 + 2",
                new List<IToken> { new NumberToken<int>(1), OperatorToken.Plus, new NumberToken<int>(2) } };
            yield return new object[] { "1+-2",
                new List<IToken> { new NumberToken<int>(1), OperatorToken.Plus, OperatorToken.Negative, new NumberToken<int>(2) } };
            yield return new object[] { "1 + (2)",
                new List<IToken> { new NumberToken<int>(1), OperatorToken.Plus, OperatorToken.OpenBracket, new NumberToken<int>(2), OperatorToken.CloseBracket } };
            yield return new object[] { "((-1))",
                new List<IToken> { OperatorToken.OpenBracket, OperatorToken.OpenBracket, OperatorToken.Negative, new NumberToken<int>(1), OperatorToken.CloseBracket, OperatorToken.CloseBracket } };
            yield return new object[] { "((-1)) + 0.2",
                new List<IToken> { OperatorToken.OpenBracket, OperatorToken.OpenBracket, OperatorToken.Negative, new NumberToken<int>(1), OperatorToken.CloseBracket,
                    OperatorToken.CloseBracket, OperatorToken.Plus, new NumberToken<double>(0.2) } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
