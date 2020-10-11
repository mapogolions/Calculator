using System.Collections;
using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Test.Fixtures
{
    public class ClimbUpLeftAssocOperatorsDataSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] // 1 + 34.3
            {
                new ExpressionsTree()
                    .Insert(new NumberToken<int>(1))
                    .Insert(OperatorToken.Plus)
                    .Insert(new NumberToken<double>(34.3)),
                "1 + 34.3",
                "1 34.3 +"
            };

            yield return new object[] // (1 + 2) * 3
            {
                new ExpressionsTree()
                    .Insert(OperatorToken.OpenBracket)
                    .Insert(new NumberToken<int>(1))
                    .Insert(OperatorToken.Plus)
                    .Insert(new NumberToken<int>(2))
                    .Insert(OperatorToken.CloseBracket)
                    .Insert(OperatorToken.Times)
                    .Insert(new NumberToken<int>(3)),
                "1 + 2 * 3",
                "1 2 + 3 *"
            };

            yield return new object[] // (1 + 2 * 3.1)
            {
                new ExpressionsTree()
                    .Insert(OperatorToken.OpenBracket)
                    .Insert(new NumberToken<int>(1))
                    .Insert(OperatorToken.Plus)
                    .Insert(new NumberToken<int>(2))
                    .Insert(OperatorToken.Times)
                    .Insert(new NumberToken<double>(3.1))
                    .Insert(OperatorToken.CloseBracket),
                "1 + 2 * 3.1",
                "1 2 3.1 * +"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
