using System.Linq;
using System.Collections.Generic;
using Calculator.Contracts;
using Calculator.Extensions;
using Calculator.Tokens;
using Calculator.Exceptions;
using Calculator.Parsers;
using System;

namespace Calculator
{
    public class TokensParser : ITokensParser
    {
        private readonly ITokenParser _parser;
        private readonly IEnumerable<Operator> _operators;

        public TokensParser(ITokenParser parser, IEnumerable<Operator> operators)
        {
            _parser = parser;
            _operators = operators;
        }

        private char[] Separators => _operators.Select(x => x.Sign).Distinct().ToArray();

        public IEnumerable<IToken> Parse(string source)
        {
            if (!source.IsBalanced(new [] { Operator.OpenBracket.Sign, Operator.CloseBracket.Sign }))
                throw new ParseException("Source is unbalanced");
            var tokens = new List<IToken>();
            var chunks = source.Trim().SplitAndKeep(Separators).Where(x => !string.IsNullOrEmpty(x));
            foreach (var chunk in chunks)
            {
                var previousToken = tokens.LastOrDefault();
                if (!_parser.TryParse(chunk.Trim(), previousToken, out var token))
                {
                    throw new InvalidOperationException("Invalid token");
                }
                tokens.Add(token);
            }
            // TODO: refactoring
            var lastToken = tokens.LastOrDefault();
            if (lastToken is null || lastToken is Number<int> || lastToken is Number<double> || lastToken == Operator.CloseBracket)
            {
                return tokens;
            }
            throw new ParseException("Invalid end of source");
        }
    }
}
