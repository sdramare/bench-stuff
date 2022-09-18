using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace BenchStash
{
    [MemoryDiagnoser()]
   // [ShortRunJob]
    public class TestLambdaMemory
    {
        private ConcurrentDictionary<int, int> _map = new(1,10000000);
        private int _objectVar = 3;
        
        private readonly Func<int, int> _factory;

        private int Factory(int x) => x * this._objectVar;

        public TestLambdaMemory()
        {
            _factory = Factory;
        }

        [Benchmark(Baseline = true)]
        [Arguments(10000000)]
        public void CreateLambda(int size)
        {
            var localVar = 3;
            for (int i = 0; i < size; i++)
            {
                DoWork(i, localVar);
            }
        }
        
        [Benchmark()]
        [Arguments(10000000)]
        public void CreateLambdaStatic(int size)
        {
            var localVar = 3;
            for (int i = 0; i < size; i++)
            {
                DoWorkStatic(i, localVar);
            }
        }
        
        [Benchmark()]
        [Arguments(10000000)]
        public void CreateLambdaInline(int size)
        {
            const int localVar = 3;
            for (int i = 0; i < size; i++)
            {
                _map.GetOrAdd(i, x => x * localVar);
            }
        }
        
        [Benchmark()]
        [Arguments(10000000)]
        public void CreateLambdaInlineObject(int size)
        {
            
            for (int i = 0; i < size; i++)
            {
                _map.GetOrAdd(i, x => x * this._objectVar);
            }
        }
        
        [Benchmark]
        [Arguments(10000000)]
        public void CreateLambdaNoAllocations(int size)
        {
            for (int i = 0; i < size; i++)
            {
                DoWork2(i);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void DoWork(int i, int localVar)
        {
            _map.GetOrAdd(i, _ => i * localVar);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DoWorkStatic(int i, int localVar)
        {
            _map.GetOrAdd(i, static (x, mul) => x * mul, localVar);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void DoWork2(int i)
        {
            _map.GetOrAdd(i, _factory);
        }
    }
}