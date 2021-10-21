using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp1
{
    public class TestCase
    {
        private static readonly Random Random = new(420);
        private readonly List<int> _array = Enumerable
            .Range(0, 1000000)
            .Select(_ => Random.Next(500000))
            .ToList();

        [Benchmark]
        public long SumFor()
        {
            var result = 0L;

            for (int i = 0; i < _array.Count; i++)
            {
                result += _array[i];
            }

            return result;
        }

        [Benchmark]
        public long SumForeach()
        {
            var result = 0L;

            foreach (var t in _array)
            {
                result += t;
            }

            return result;
        }

        [Benchmark]
        public long SumLinq()
        {
            return _array.Sum(x=>(long)x);
        }
    }
}