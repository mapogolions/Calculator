using System.Collections.Generic;
using System.Linq;
using Calculator.Extensions;
using Calculator.Tokens;

namespace Calculator.TokenResolvers
{
    public class OperatorTokenResolver : ITokensResolver
    {
        private readonly IEnumerable<OperatorToken> _operators;

        public OperatorTokenResolver(IEnumerable<OperatorToken> operators) => _operators = operators;

        public bool TryResolve(string chunk, IToken previousToken, out IToken token)
        {
            token = _operators.FirstOrDefault(op => $"{op.Sign}" == chunk
                && op.Associative == op.HeuristicAssociativity(previousToken));
            return token?.EnsureIsValid(previousToken) != null;
        }
    }
}
