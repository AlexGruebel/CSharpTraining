using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NestedAndChildTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task starting ...");
                var inner = Task.Factory.StartNew(()=>{
                    Console.WriteLine("Inner Task starting ...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task finished.");
                }, TaskCreationOptions.AttachedToParent);
            }
            );

            outer.Wait();
            Console.WriteLine("Outer task finished.");
            Console.ReadLine();
        }
    }
}
