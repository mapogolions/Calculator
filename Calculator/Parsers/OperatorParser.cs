using System.Collections.Generic;
using System.Linq;
using Calculator.Extensions;
using Calculator.Tokens;

namespace Calculator.Parsers
{
    public class OperatorParser : ITokenParser
    {
        private readonly IEnumerable<Operator> _operators;

        public OperatorParser(IEnumerable<Operator> operators) => _operators = operators;

        public bool TryParse(string chunk, IToken previousToken, out IToken token)
        {
            token = _operators.FirstOrDefault(op => $"{op.Sign}" == chunk
                && op.Associative == op.HeuristicAssociativity(previousToken));
            return token?.EnsureIsValid(previousToken) != null;
        }
    }
}
