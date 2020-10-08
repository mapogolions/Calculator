using System.Collections;
using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Test.Fixtures
{
    public class ClimbUpRightAssocOperatorsDataSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new ExpressionsTree()
                    .Insert(new Number<int>(2))
                    .Insert(Operator.Plus)
                    .Insert(new Number<int>(2))
                    .Insert(Operator.Power)
                    .Insert(new Number<int>(3)),
                "2+2^3",
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
