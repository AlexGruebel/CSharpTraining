using System;
using System.Threading;
using System.Threading.Tasks;
using MonitoringLib;

namespace SynchronizingResourceAccess
{
    class Program
    {

        static string text = "";

        static int Counter;

        static object conch = new object();

        static void Main(string[] args)
        {

            Recorder.Start();
            Task a = Task.Factory.StartNew(new Action(AddAToText));
            Task b = Task.Factory.StartNew(new Action(AddBToText));
            Task.WaitAll(a, b);

            Console.WriteLine(text);
            Console.WriteLine(Counter);
            Recorder.Stop();
        }

        static void AddAToText(){
            //use monitor class instead of lock to prevent deadlocks
            try
            {
                Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
                for(int i = 0; i<5;i++)
                {
                    text+="a";
                    Thread.Sleep(1000);
                    Interlocked.Increment(ref Counter);
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }

        
        static void AddBToText(){
            try
            {
                Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
                for(int i = 0; i<5;i++)
                {
                    text+="b";
                    Thread.Sleep(1000);
                    Interlocked.Increment(ref Counter);
                }
            }finally
            {
                Monitor.Exit(conch);
            }
        }
    }
}
