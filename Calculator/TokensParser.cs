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

        public TokensParser(IEnumerable<Operator> operators)
        {
            _operators = operators;
        }

        private char[] Separators => _operators.Select(x => x.Sign).ToArray();

        public IEnumerable<IToken> Parse(string source)
        {
            var tokens = new List<IToken>();
            var parts = source.Trim().SplitAndKeep(Separators);
            foreach (var part in parts)
            {
                var normalized = part.Trim();
                var token = _operators
                    .FirstOrDefault(op => $"{op.Sign}" == normalized && op.Associative == Assoc(tokens, op));
                if (token != null)
                {
                    tokens.Add(token);
                    continue;
                }
                if (int.TryParse(normalized, out var num))
                {
                    tokens.Add(new Number<int>(num));
                    continue;
                }
                if (!double.TryParse(normalized, out var floatingPoint))
                    throw new InvalidOperationException("Invalid token");
                tokens.Add(new Number<double>(floatingPoint));
            }
            return tokens;
        }

        private static Associative Assoc(IEnumerable<IToken> tokens, Operator op)
        {
            if (!op.HasMultipleAssociativeForms) return op.Associative;
            var lastToken = tokens.LastOrDefault();
            if (lastToken is null || Equals(lastToken, Operator.OpenBracket))
                return Associative.Right;
            return Associative.Left;
        }
    }
}
