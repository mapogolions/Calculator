using System.Collections;
using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Test.Fixtures
{
    public class ClimbUpRightAssocOperatorsDataSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] // 2 ^ 4 ^ 3
            {
                new ExpressionsTree()
                    .Insert(new NumberToken<int>(2))
                    .Insert(OperatorToken.Power)
                    .Insert(new NumberToken<int>(4))
                    .Insert(OperatorToken.Power)
                    .Insert(new NumberToken<int>(3)),
                "2 ^ 4 ^ 3",
                "2 4 3 ^ ^"
            };

            yield return new object[] // -(-(- 2))
            {
                new ExpressionsTree()
                    .Insert(OperatorToken.Negative)
                    .Insert(OperatorToken.OpenBracket)
                    .Insert(OperatorToken.Negative)
                    .Insert(OperatorToken.OpenBracket)
                    .Insert(OperatorToken.Negative)
                    .Insert(new NumberToken<int>(2))
                    .Insert(OperatorToken.CloseBracket)
                    .Insert(OperatorToken.CloseBracket),
                "- - - 2",
                "2 - - -"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
