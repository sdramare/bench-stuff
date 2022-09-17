using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using BenchmarkDotNet.Running;
using BenchStash;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using ShellProgressBar;


#if DEBUG
{
    var test = new TestMinCase();
    test.Setup();
    
    Print(test.MinFor());
    Print(test.MinForeach());
    Print(test.MinLinq());
    Print(test.SumVectorRef());
    /*var test = new TwoArrayMax();
    test.Setup();

    Print(test.ManualMax());
    Print(test.LinqMax());
    Print(test.LinqConcatMax());
    Print(test.LinqMax());
    Print(test.VectorMax());
    Print(test.VectorAvx2Max());
    Print(test.VectorUnsafeMax());
    Print(test.ParallelVectorMax());
    Print(test.ParallelManualMax());*/
}

void Print<T>(T value, [CallerArgumentExpression("value")] string expression = default) =>
    Console.WriteLine($"{expression}: {value}");
#else
BenchmarkRunner.Run<TestMinCase>();
#endif

