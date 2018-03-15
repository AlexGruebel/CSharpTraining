using System;

namespace Exercies02
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 500;
            Console.WriteLine($"ByteMinValue: {byte.MinValue}");
            #warning this is a endles loop
            int safe = 0;
            for (byte i = 0; i < max; i++){
                safe++;
                Console.WriteLine(i);
                if(safe > 400){
                    break;
                }   
            }
        }
    }
}
