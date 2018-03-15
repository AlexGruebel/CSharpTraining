using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace LINQingInParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine("Press Enter to start: ");
            Console.ReadLine();
            watch.Start();

            IEnumerable<int> numbers = Enumerable.Range(1, 200_000_000);
            var squares = numbers.AsParallel().Select(n => n * 2).ToArray();
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds");
        }
    }
}
