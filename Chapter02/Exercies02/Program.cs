using System;

namespace Exercies02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}","Type", "Byte(s)", "MinValue", "MaxValue");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "sbyte", 1, sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "byte", 1, byte.MinValue, byte.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "short", 2, short.MinValue, short.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "ushort", 2, ushort.MinValue, ushort.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "int", 4, int.MinValue, int.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "uint", 4, uint.MinValue, uint.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "lomg", 8, long.MinValue, long.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "ulong", 8, ulong.MinValue, ulong.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "float", 4, float.MinValue, float.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "double", 8, double.MinValue, double.MaxValue);
            Console.WriteLine("{0, -10} {1, 10} {2, 30} {3, 30}", "decimal", 16, decimal.MinValue, decimal.MaxValue);    
        }
    }
}
