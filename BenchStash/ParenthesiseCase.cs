using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchStash
{
    [MemoryDiagnoser]
    public class ParenthesiseCase
    {
        [Benchmark]
        [Arguments(10)]
        public IList<string> GenerateParenthesisSB(int n)
        {
            var result = new List<string>();
            GenerateParenthesisInternal2(n, n, new StringBuilder(), result);
            return result;
        }

        void GenerateParenthesisInternal2(int open, int close, StringBuilder sb, List<string> result)
        {
            if (open == 0 && close == 0)
            {
                result.Add(sb.ToString());
                return;
            }

            if (open > 0)
            {
                var len = sb.Length;
                sb.Append('(');
                GenerateParenthesisInternal2(open - 1, close, sb, result);
                sb.Length = len;
            }
    
            if (open < close)
            {
                var len = sb.Length;
                sb.Append(')');
                GenerateParenthesisInternal2(open, close-1, sb, result);
                sb.Length = len;
            }
        }
        
        [Benchmark]
        [Arguments(10)]
        public IList<string> GenerateParenthesis(int n)
        {
            return GenerateParenthesisInternal(0, n*2).ToList();
        }

        IEnumerable<string> GenerateParenthesisInternal(int openCount, int size)
        {
            if (size == 0)
            {
                yield return "";
                yield break;
            }

            if (openCount < size)
            {
                foreach (var variant in GenerateParenthesisInternal(openCount+1, size - 1))
                {
                    yield return "(" + variant;
                }    
            }
    
            if (openCount > 0)
            {
                foreach (var variant in GenerateParenthesisInternal(openCount-1, size - 1))
                {
                    yield return ")" + variant;
                }
            }
        } 
    }
}