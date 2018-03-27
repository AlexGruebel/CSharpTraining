using System;
using System.Diagnostics;
using static System.Console;

namespace MonitoringLib
{
    public static class Recorder
    {
        static Stopwatch timer = new Stopwatch();
        static long bytesPhysicalBefore = 0;
        static long bytesVirtualBefore = 0;

        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            bytesPhysicalBefore = Process.GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = Process.GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }

        public static void Stop()
        {
            timer.Stop();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long bytesPhysicalAfter = Process.GetCurrentProcess().WorkingSet64;
            long bytesVirtualAfter = Process.GetCurrentProcess().VirtualMemorySize64;
            WriteLine("Stopped recording");
            WriteLine($"{bytesPhysicalAfter - bytesPhysicalBefore} pyscial bytes used");
            WriteLine($"{bytesVirtualAfter - bytesVirtualBefore} virtual bytes used");

            WriteLine($"{timer.Elapsed} time span ellapsed");
            WriteLine($"{timer.ElapsedMilliseconds} total millisecounds ellapsed");
        }

    }
}
