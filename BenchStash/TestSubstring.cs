using System;
using BenchmarkDotNet.Attributes;

namespace BenchStash
{
    public class TestSubstring
    {
       public const string Lookup = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaz";
       public const string Input =
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaazaaaaaaaaaaaaaaaaaaaaa";
        
        [Benchmark]
        [Arguments(Input, Lookup)]
        public int IndexOfNaive(string input, string substring)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int j = 0;
                for (; j < substring.Length; j++)
                {
                    if (input[i + j] != substring[j])
                    {
                        break;               
                    }
                }

                if (j == substring.Length)
                {
                    return i;
                }
            }

            return -1;
        }

        [Benchmark]
        [Arguments(Input, Lookup)]
        public int IndexOfKP(string input, string substring)
        {
            
            var prefixTable = new int[substring.Length];

            for (int i = 1; i < prefixTable.Length; i++)
            {
                var prefix = prefixTable[i - 1];
                while (prefix > 0 && substring[prefix] != substring[i])
                {
                    prefix = prefixTable[prefix - 1];
                }

                if (substring[prefix] == substring[i])
                {
                    prefix++;
                }
                
                prefixTable[i] = prefix;
            }

            var m = 0;
            int j = 0;
            while( j < substring.Length && m < input.Length)
            {
                if (input[m] != substring[j])
                {
                    if (j > 0)
                    {
                        var prefix = prefixTable[j - 1];
                        j = prefix;
                        continue;
                    }
                }
                else
                {
                    j++;
                }
                m++;
            }

            return j == substring.Length ? m - j : -1;
        }

        [Benchmark]
        [Arguments(Input, Lookup)]
        public int IndexOfBase(string input, string substring)
        {
            return input.IndexOf(substring, StringComparison.Ordinal);
        }
    }
}