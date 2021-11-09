using System.Collections;
using BenchmarkDotNet.Attributes;

namespace BenchStash
{
    [MemoryDiagnoser]
    public class PalindromicTest
    {
        private const string Input =
            "fthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgffthabccbauugfharradfgf";

        [Benchmark]
        [Arguments(Input)]
        public string LongestPalindromeNew2(string input)
        {
            var prevLine = new BitArray(input.Length);
            var currentLine = new BitArray(input.Length);
            var resultOffset = 0;
            var resultLen = 0;

            for (int i = 0; i < input.Length; i++)
            {
                currentLine[i] = true;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (input[i] == input[j])
                    {
                        var len = i - j;

                        if (len == 1 || prevLine[j + 1])
                        {
                            currentLine[j] = true;

                            if (len > resultLen)
                            {
                                resultLen = len;
                                resultOffset = j;
                            }
                        }
                        else
                        {
                            currentLine[j] = false;
                        }
                    }
                    else
                    {
                        currentLine[j] = false;
                    }
                }

                (prevLine, currentLine) = (currentLine, prevLine);
            }

            return input.Substring(resultOffset, resultLen + 1);
        }
        
        [Benchmark]
        [Arguments(Input)]
        public string LongestPalindromeNew(string input)
        {
            var prevLine = new bool[input.Length];
            var currentLine = new bool[input.Length];
            var resultOffset = 0;
            var resultLen = 0;

            for (int i = 0; i < input.Length; i++)
            {
                currentLine[i] = true;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (input[i] == input[j])
                    {
                        var len = i - j;

                        if (len == 1 || prevLine[j + 1])
                        {
                            currentLine[j] = true;

                            if (len > resultLen)
                            {
                                resultLen = len;
                                resultOffset = j;
                            }
                        }
                        else
                        {
                            currentLine[j] = false;
                        }
                    }
                    else
                    {
                        currentLine[j] = false;
                    }
                }

                (prevLine, currentLine) = (currentLine, prevLine);
            }

            return input.Substring(resultOffset, resultLen + 1);
        }

        [Benchmark]
        [Arguments(Input)]
        public string LongestPalindromeOld(string input)
        {
            if (input.Length < 2)
            {
                return input;
            }

            var str = input.ToCharArray();
            var table = new bool[str.Length, str.Length];
            var palindrome = 0;
            var maxLenght = 1;

            for (int i = str.Length - 1; i > -1; i--)
            {
                table[i, i] = true;
                for (int j = i + 1; j < str.Length; j++)
                {
                    if ((j - i == 1 || table[i + 1, j - 1]) && str[i] == str[j])
                    {
                        table[i, j] = true;
                        var lenght = j - i + 1;
                        if (lenght > maxLenght)
                        {
                            maxLenght = lenght;
                            palindrome = i;
                        }
                    }
                }
            }


            return new string(str, palindrome, maxLenght);
        }
    }
}