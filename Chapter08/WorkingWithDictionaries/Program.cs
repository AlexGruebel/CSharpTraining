using System;
using System.Collections.Generic;

namespace WorkingWithDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var keywords = new Dictionary<string, string>();
            keywords.Add("int", "32-bit integer data type");
            keywords.Add("long", "64-bit integer data type");
            keywords.Add("float", "Singe precision floating point number");
            Console.WriteLine("Keywords and their Definitions");

            foreach (var item in keywords)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Console.WriteLine($"The definition of long is {keywords["long"]}");
        }
    }
}
