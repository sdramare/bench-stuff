using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace BenchStash
{
    [MemoryDiagnoser(false)]
   // [ShortRunJob]
    public class TestMinCase
    {
        private const int DataCount = 1000000;
        
        private int[] _array;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random(420123);
            _array = Enumerable
                .Range(0, random.Next(DataCount, DataCount * 2))
                .Select(_ => random.Next(0, Int32.MaxValue))
                .ToArray();
        }

        [Benchmark]
        public long MinFor()
        {
            var result = _array[0];

            for (int i = 0; i < _array.Length; i++)
            {
                result = Math.Min(result, _array[i]);;
            }

            return result;
        }
        
        [Benchmark(Baseline = true)]
        public int MinForeach()
        {
            var result = _array[0];

            foreach (var t in _array)
            {
                result = Math.Min(result, t);
            }

            return result;
        }
        
        //[Benchmark]
        public long MinLinq()
        {
            return _array.Min();
        }

        [Benchmark]
        public long SumVectorRef()
        {
            Span<int> array = _array;
            Span<Vector<int>> vectors = MemoryMarshal.Cast<int, Vector<int>>(array);
            var resultVector = vectors[0];

            ref var current = ref MemoryMarshal.GetReference(vectors);
            ref var end = ref Unsafe.Add(ref current, vectors.Length);

            while (Unsafe.IsAddressLessThan(ref current, ref end))
            {
                resultVector = Vector.Min(resultVector, current);
                current = ref Unsafe.Add(ref current, 1);
            }

            Vector.Widen(resultVector, out var high, out var low);
            low = Vector.Min(high, low);

            var i = Vector<int>.Count >> 1;

            while (i > 2)
            {
                Vector.Widen(Vector.AsVectorInt32(low), out high, out low);
                low = Vector.Min(high, low);
                i >>= 1;
            }

            var result = Math.Min(low[0], low[2]);

            var tailIndex = array.Length - array.Length % Vector<int>.Count;
            var tail = array.Slice(tailIndex);
            for (i = 0; i < tail.Length; i++)
            {
                result = Math.Min(result, tail[i]);
            }

            return result;
        }
    }
}