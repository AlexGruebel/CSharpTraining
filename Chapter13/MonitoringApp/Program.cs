using System;
using System.Text;
using MonitoringLib;
using System.Linq;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Enumerable.Range(1, 50000).ToArray();

            Console.WriteLine("Process StringWithConcat \n");
            Recorder.Start();
            ProcessStringWithConcat(numbers);
            Recorder.Stop();

            Console.WriteLine("\nProcess StringWithBuilder \n");

            Recorder.Start();
            ProcessStringWithBuilder(numbers);
            Recorder.Stop();
        }

        static void ProcessStringWithConcat(int[] numbers){
            string list = "";
            foreach (int item in numbers)
            {
                list += $"item, ";
            }
        }

        static void ProcessStringWithBuilder(int[] numbers){
            StringBuilder builder = new StringBuilder();
            foreach(int item  in numbers){
                builder.Append(item);
                builder.Append(", ");
            }
        }
    }
}
