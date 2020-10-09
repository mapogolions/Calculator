using System.Collections.Generic;

namespace Calculator.Extensions
{
    public static class StringOps
    {
        public static bool IsBalanced(this string @this, char[] pairs)
        {
            var i = 0;
            foreach (var ch in @this)
            {
                if (pairs[0].Equals(ch))
                {
                    i++;
                    continue;
                }
                if (pairs[1].Equals(ch) && (--i) < 0)
                {
                    return false;
                }
            }
            return i == 0;
        }

        public static IEnumerable<string> SplitAndKeep(this string s, char[] separators)
        {
            int start = 0, index;
            while ((index = s.IndexOfAny(separators, start)) != -1)
            {
                if(index-start > 0)
                    yield return s.Substring(start, index - start).Trim();
                yield return s.Substring(index, 1).Trim();
                start = index + 1;
            }
            if (start < s.Length)
            {
                yield return s.Substring(start).Trim();
            }
        }
    }
}
