using System.Linq;
using System.Collections.Generic;
using Calculator.Contracts;
using Calculator.Extensions;
using Calculator.Tokens;
using Calculator.Exceptions;
using Calculator.TokenResolvers;
using System;

namespace Calculator
{
    public class TokensParser : ITokensParser
    {
        private readonly ITokensResolver _tokensResolver;
        private readonly char[] _separators;

        public TokensParser(ITokensResolver tokensResolver, char[] separators)
        {
            _tokensResolver = tokensResolver;
            _separators = separators;
        }

        public IEnumerable<IToken> Parse(string source)
        {
            if (!source.IsBalanced(new [] { OperatorToken.OpenBracket.Sign, OperatorToken.CloseBracket.Sign }))
            {
                throw new ParseException("Source is unbalanced");
            }
            var tokens = new List<IToken>();
            var chunks = source.Trim().SplitAndKeep(_separators).Where(x => !string.IsNullOrEmpty(x));
            foreach (var chunk in chunks)
            {
                if (!_tokensResolver.TryResolve(chunk.Trim(), tokens.LastOrDefault(), out var token))
                {
                    throw new InvalidOperationException("Invalid token");
                }
                tokens.Add(token);
            }
            var lastToken = tokens.LastOrDefault();
            if (lastToken is null || lastToken is NumberToken<int>
                || lastToken is NumberToken<double> || Equals(lastToken, OperatorToken.CloseBracket))
            {
                return tokens;
            }
            throw new ParseException("Invalid end of source");
        }
    }
}
