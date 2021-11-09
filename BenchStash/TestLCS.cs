using BenchmarkDotNet.Attributes;

namespace BenchStash
{
    public class TestLCS
    {
        public const string InputA = "aabcdfzddfaaabcdfzddfaaabcdfzddfaaabcdfzddfaaabcdfzddfaaabcdfzddfaaabcdfzddfaaabcdfzddfa";
        public const string InputB = "sdaattybcdfdfzfddfasdaattybcdfdfzfddfasdaattybcdfdfzfddfasdaattybcdfdfzfddfasdaattybcdfdfzfddfasdaattybcdfdfzfddfasdaattybcdfzddfaaabcddfdfzfddfasdaattybcdfdfzfddfasdaattybcdfdfzfddfasdaattybcdfdfzfddfa";
        
        [Benchmark]
        [Arguments(InputA, InputB)]
        public string LCSNaive(string str1, string str2)
        {
            var mainString = str1.Length > str2.Length ? str1 : str2;
            var lookupString = mainString == str1 ? str2 : str1;

            bool HasString(string substring)
            {
                for (int i = 0; i < mainString.Length - substring.Length; i++)
                {
                    int j = 0;
                    for (; j < substring.Length; j++)
                    {
                        if (mainString[i + j] != substring[j])
                        {
                            break;
                        }
                    }

                    if (j == substring.Length)
                    {
                        return true;
                    }
                }

                return false;
            }


            var stringLength = lookupString.Length;

            var result = string.Empty;

            for (int i = 0; i < stringLength; i++)
            {
                for (int j = i; j < stringLength; j++)
                {
                    var lookupStringLength = stringLength;
                    var substring = lookupString.Substring(i, lookupStringLength - j);

                    if (HasString(substring) && substring.Length > result.Length)
                    {
                        result = substring;
                        break;
                    }
                }
            }

            return result;
        }

        [Benchmark]
        [Arguments(InputA, InputB)]
        public string LCSDynamic(string str1, string str2)
        {
            var map = new int[str1.Length, str2.Length];
            var maxLen = 0;
            var resultIndex = -1;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        var len = 1;
                        if (i > 0 && j > 0)
                        {
                            len += map[i - 1, j - 1];
                        }

                        map[i, j] = len;

                        if (len > maxLen)
                        {
                            maxLen = len;
                            resultIndex = i;
                        }
                    }
                }
            }

            return resultIndex > 0 ? str1.Substring(resultIndex - maxLen + 1, maxLen) : string.Empty;
        }
    }
}