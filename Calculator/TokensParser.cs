using System;
using System.Linq;
using System.Collections.Generic;
using Calculator.Contracts;
using Calculator.Extensions;
using Calculator.Tokens;

namespace Calculator
{
    public class TokensParser : ITokensParser
    {
        private readonly IEnumerable<Operator> _operators;

        public TokensParser(IEnumerable<Operator> operators) => _operators = operators;

        private char[] Separators => _operators.Select(x => x.Sign).Distinct().ToArray();

        public IEnumerable<IToken> Parse(string source)
        {
            var tokens = new List<IToken>();
            var parts = source.Trim().SplitAndKeep(Separators).Where(x => !string.IsNullOrEmpty(x));
            foreach (var part in parts)
            {
                var normalized = part.Trim();
                var previousToken = tokens.LastOrDefault();
                var operatorToken = _operators
                    .FirstOrDefault(op => $"{op.Sign}" == normalized && op.Associative == op.HeuristicAssociativity(previousToken));
                if (operatorToken != null)
                {
                    tokens.Add(operatorToken.EnsureIsValid(previousToken));
                    continue;
                }
                if (int.TryParse(normalized, out var num))
                {
                    tokens.Add(new Number<int>(num).EnsureIsValid(previousToken));
                    continue;
                }
                if (!double.TryParse(normalized, out var floatingPoint))
                    throw new InvalidOperationException("Invalid token");
                tokens.Add(new Number<double>(floatingPoint).EnsureIsValid(previousToken));
            }
            return tokens;
        }
    }
}
