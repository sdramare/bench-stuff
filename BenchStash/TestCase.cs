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
    public class TestCase
    {
        private const int DataCount = 10000000;
        
        private int[] _array;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random(420);
            _array = Enumerable
                .Range(0, DataCount)
                .Select(_ => random.Next(0,500))
                .ToArray();
        }

        [Benchmark(Baseline = true)]
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
        public long SumFor()
        {
            var result = 0L;

            for (int i = 0; i < _array.Length; i++)
            {
                result += _array[i];
            }

            return result;
        }

        [Benchmark]
        public long SumLinq()
        {
            return _array.Sum(x => (long)x);
        }

        [Benchmark]
        public long SumAcc()
        {
            return _array.Aggregate(0L, (acc, x) => acc + x);
        }

        [Benchmark]
        public long SumVector()
        {
            return SumVectorInternal(_array);
        }
        
        [Benchmark]
        public long SumVectorSimple()
        {
            Span<int> array = _array;
            Span<Vector<uint>> vectors = MemoryMarshal.Cast<int, Vector<uint>>(array);
            var result = Vector<uint>.Zero;

            foreach (var vector in vectors)
            {
                result += vector;
            }

            return Vector.Sum(result);
        }

        private static long SumVectorInternal(ReadOnlySpan<int> array)
        {
            var vectorSize = Vector<int>.Count;
            var vectorSizeByte = vectorSize * 4;
            var arraySize = array.Length;
            var vectorLastIndex = arraySize - (arraySize % vectorSize);
            
            ref byte current = ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(array));
            ref byte lastVectorAddress = ref Unsafe.Add(ref current, (arraySize / vectorSize) * vectorSizeByte);
            var resultVector = Vector<uint>.Zero;
            while (Unsafe.IsAddressLessThan(ref current, ref lastVectorAddress))
            {
                var vector = Unsafe.ReadUnaligned<Vector<uint>>(ref current);
                resultVector = Vector.Add(resultVector, vector);
                current = ref Unsafe.Add(ref current, vectorSizeByte);
            }

            long result = Vector.Sum(resultVector);

            for (var i = vectorLastIndex; i < arraySize; i++)
            {
                result += array[i];
            }

            return result;

        }
    }
}