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
                    .Insert(new Number<int>(2))
                    .Insert(Operator.Power)
                    .Insert(new Number<int>(4))
                    .Insert(Operator.Power)
                    .Insert(new Number<int>(3)),
                "2 ^ 4 ^ 3",
                "2 4 3 ^ ^"
            };

            yield return new object[] // -(-(- 2))
            {
                new ExpressionsTree()
                    .Insert(Operator.Negative)
                    .Insert(Operator.OpenBracket)
                    .Insert(Operator.Negative)
                    .Insert(Operator.OpenBracket)
                    .Insert(Operator.Negative)
                    .Insert(new Number<int>(2))
                    .Insert(Operator.CloseBracket)
                    .Insert(Operator.CloseBracket),
                "- - - 2",
                "2 - - -"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
