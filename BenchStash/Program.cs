using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Running;
using BenchStash;




#if DEBUG
{
    var lcs = new TestSubstring();
    Console.WriteLine(lcs.IndexOfNaive(TestSubstring.Input, TestSubstring.Lookup));
    Console.WriteLine(lcs.IndexOfBase(TestSubstring.Input, TestSubstring.Lookup));
    Console.WriteLine(lcs.IndexOfKP(TestSubstring.Input, TestSubstring.Lookup));
}
#else
   // BenchmarkRunner.Run<TestLCS>();
    BenchmarkRunner.Run<TestSubstring>();
#endif

