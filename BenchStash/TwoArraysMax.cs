using System;
using System.Buffers;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Attributes;

namespace BenchStash
{
    [MemoryDiagnoser(false)]
    public class TwoArrayMax
    {
        private int[] _arrayA;
        private int[] _arrayB;
        private const int Seed = 234341246;
        private const int Count = 10000000;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random(Seed);

            _arrayA = Enumerable.Range(0, Count).Select(_ => random.Next()).ToArray();
            _arrayB = Enumerable.Range(0, Count).Select(_ => random.Next()).ToArray();
        }

        [Benchmark()]
        public int LinqConcatMax()
        {
            return _arrayA.Concat(_arrayB).Max();
        }
        
        [Benchmark()]
        public int LinqMax()
        {
            return Math.Max(_arrayA.Max(), _arrayB.Max());
        }
        
        [Benchmark()]
        public int LinqZipMax()
        {
            return _arrayA.Zip(_arrayB).Select(zip => Math.Max(zip.First, zip.Second)).Max();
        }

        [Benchmark(Baseline = true)]
        public int ManualMax()
        {
            var result = _arrayA[0];
            var length = _arrayA.Length;
            for (int i = 0; i < length; i++)
            {
                result = Math.Max(result, Math.Max(_arrayA[i], _arrayB[i]));
            }

            return result;
        }

        [Benchmark]
        public unsafe int VectorAvx2Max()
        {
            var resultVector = Vector256<int>.Zero;
            int i = 0;
            var blockSize = Vector256<int>.Count;
            int lastBlockIndex = _arrayA.Length - (_arrayA.Length % blockSize);

            fixed (int* pSourceA = _arrayA)
            {
                fixed (int* pSourceB = _arrayB)
                {
                    while (i < lastBlockIndex)
                    {
                        var left = Avx.LoadVector256(pSourceA + i);
                        var right = Avx.LoadVector256(pSourceB + i);
                        resultVector = Avx2.Max(resultVector, Avx2.Max(left, right));
                        i += blockSize;
                    }    
                }
            }

            var neg = Avx2.Multiply(resultVector, Vector256.Create(-1));
            var y = Avx2.Permute2x128(resultVector,resultVector, 1);
            var m1 = Avx2.Max(resultVector, y);
            var m2 = Avx2.Shuffle(m1, 27);//MmShuffle(0,1,2,3));
            var m = Avx2.Max(m1, m2);
            var result = Math.Max(m.GetElement(0), m.GetElement(1));
            
            for (; i < _arrayA.Length; i++)
            {
                result = Math.Max(result, Math.Max(_arrayA[i], _arrayB[i]));
            }

            return result;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte MmShuffle(byte p3, byte p2, byte p1, byte p0)
            => (byte)((p3 << 6) | (p2 << 4) | (p1 << 2) | p0);

        [Benchmark()]
        public int VectorMax()
        {
            var resultVector = Vector<int>.Zero;
            int i;
            var vectorSize = Vector<int>.Count;
            var arrayLength = _arrayA.Length;
            var size = (arrayLength / vectorSize) * vectorSize;
            for (i = 0; i < size; i += vectorSize)
            {
                var a =  new Vector<int>(_arrayA, i);
                var b = new Vector<int>(_arrayB, i);

                resultVector = Vector.Max(resultVector, Vector.Max(a, b));
            }

            var result = resultVector[0];
            
            for (i = 1; i < vectorSize; i++)
            {
                result = Math.Max(result, resultVector[i]);
            }

            if (size != arrayLength)
            {
                for (i = size; i < arrayLength; i++)
                {
                    result = Math.Max(result, Math.Max(_arrayA[i], _arrayB[i]));
                }

                return result;
            }

            return result;
        }
        
        [Benchmark()]
        public int VectorUnsafeMax()
        {
            var resultVector = Vector<int>.Zero;
            int i = 0;
            var vectorSize = Vector<int>.Count;
            
            var arrayLength = _arrayA.Length;
            ref byte currentA = ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(_arrayA.AsSpan()));
            ref byte currentB = ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(_arrayB.AsSpan()));
            int lastBlockIndex = _arrayA.Length - (_arrayA.Length % vectorSize);
            int vectorSizeByte = vectorSize * 4;
            
            while (i < lastBlockIndex)
            {
                var a = Unsafe.ReadUnaligned<Vector<int>>(ref currentA);
                var b = Unsafe.ReadUnaligned<Vector<int>>(ref currentB);
                resultVector = Vector.Max(resultVector, Vector.Max(a, b));
                currentA = ref Unsafe.Add(ref currentA, vectorSizeByte);
                currentB = ref Unsafe.Add(ref currentB, vectorSizeByte);
                
                i += vectorSize;
            }

            var result = resultVector[0];
            
            for (int j = 1; j < vectorSize; j++)
            {
                result = Math.Max(result, resultVector[j]);
            }
            
            for (; i < arrayLength; i++)
            {
                result = Math.Max(result, Math.Max(_arrayA[i], _arrayB[i]));
            }
            
            return result;
        }

        [Benchmark]
        public int ParallelVectorMax()
        {
            var chunkCount = Environment.ProcessorCount;
            var chunkSize = Count / Environment.ProcessorCount;
            var buffer = ArrayPool<int>.Shared.Rent(chunkCount);
            var arrayA = _arrayA.AsMemory();
            var arrayB = _arrayB.AsMemory();
            
            Enumerable.Range(0, chunkCount)
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .ForAll(chunk =>
            {
                var max = InternalMax(arrayA.Slice(chunk * chunkSize, chunkSize).Span,
                    arrayB.Slice(chunk * chunkSize, chunkSize).Span);
                buffer[chunk] = max;
            });

            var result = buffer[0];
            for (int i = 0; i < chunkCount; i++)
            {
                result = Math.Max(result, buffer[i]);
            }
            
            ArrayPool<int>.Shared.Return(buffer);
            return result;
        }
        
        [Benchmark]
        public int ParallelManualMax()
        {
            var chunkCount = Environment.ProcessorCount;
            var chunkSize = Count / Environment.ProcessorCount;
            var buffer = ArrayPool<int>.Shared.Rent(chunkCount);
            var arrayA = _arrayA.AsMemory();
            var arrayB = _arrayB.AsMemory();
            
            Enumerable.Range(0, chunkCount)
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .ForAll(chunk =>
                {
                    var max = ManualInternalMax(arrayA.Slice(chunk * chunkSize, chunkSize).Span,
                        arrayB.Slice(chunk * chunkSize, chunkSize).Span);
                    buffer[chunk] = max;
                });

            var result = buffer[0];
            for (int i = 0; i < chunkCount; i++)
            {
                result = Math.Max(result, buffer[i]);
            }
            
            ArrayPool<int>.Shared.Return(buffer);
            return result;
        }
        
        private static int ManualInternalMax(ReadOnlySpan<int> arrayA, ReadOnlySpan<int> arrayB)
        {
            var result = int.MinValue;
            var length = arrayA.Length;
            for (int i = 0; i < length; i++)
            {
                result = Math.Max(result, Math.Max(arrayA[i], arrayB[i]));
            }

            return result;
        }
        
        private static int InternalMax(ReadOnlySpan<int> arrayA, ReadOnlySpan<int> arrayB)
        {
            var resultVector = Vector<int>.Zero;
            int i = 0;
            var vectorSize = Vector<int>.Count;
            var arrayLength = arrayA.Length;
            ref byte currentA = ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(arrayA));
            ref byte currentB = ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(arrayB));
            int lastBlockIndex = arrayLength - (arrayLength % vectorSize);
            int vectorSizeByte = vectorSize * 4;
            
            while (i < lastBlockIndex)
            {
                var a = Unsafe.ReadUnaligned<Vector<int>>(ref currentA);
                var b = Unsafe.ReadUnaligned<Vector<int>>(ref currentB);
                resultVector = Vector.Max(resultVector, Vector.Max(a, b));
                currentA = ref Unsafe.Add(ref currentA, vectorSizeByte);
                currentB = ref Unsafe.Add(ref currentB, vectorSizeByte);
                
                i += vectorSize;
            }

            var result = resultVector[0];
            
            for (int j = 1; j < vectorSize; j++)
            {
                result = Math.Max(result, resultVector[j]);
            }
            
            for (; i < arrayLength; i++)
            {
                result = Math.Max(result, Math.Max(arrayA[i], arrayB[i]));
            }
            
            return result;
        }
    }
}