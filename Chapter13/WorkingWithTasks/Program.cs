using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WorkingWithTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //RunMethodSynchronously();
            //RunMethodAsyncronously();
            RunTaskOneByOne();
        }

        static void RunMethodSynchronously()
        {
            var timer = Stopwatch.StartNew();
            MethodA();
            MethodB();
            MethodC();
            Console.WriteLine($"{timer.ElapsedMilliseconds} ms elappsed");
        }

        static void RunMethodAsyncronously()
        {
            var timer = Stopwatch.StartNew();
            Task taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new Action(MethodC));
            Task[] tasks = {taskA, taskB, taskC};
            Task.WaitAll(tasks);
            Console.WriteLine($"{timer.ElapsedMilliseconds} ms elappsed");
            //Console.ReadLine();
        }

        static void MethodA()
        {
            Console.WriteLine("Starting Method A...");
            Thread.Sleep(3000);
            Console.WriteLine("Finished Method A.");
        }

        static void MethodB()
        {
            Console.WriteLine("Starting Method B...");
            Thread.Sleep(2000);
            Console.WriteLine("Finished Method B..");
        }

        static void MethodC()
        {
            Console.WriteLine("Starting Method C...");
            Thread.Sleep(1000);
            Console.WriteLine("Finished Method C..");
        }


        static void RunTaskOneByOne(){
            var task = Task.Factory.StartNew(ReturnMethod).ContinueWith(pTask => GetValue(pTask.Result));
            Task.WaitAny(task);
        }

        static int ReturnMethod(){
            Console.WriteLine("Run a Method that return sth");
            Thread.Sleep(1000);
            return 20;
        }

        static void GetValue(int value)
        {   
            Console.WriteLine($"Run a Method that has a parameter {value}");
        }
    }
}
