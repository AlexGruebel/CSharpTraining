using System;
using System.Numerics;
using static System.Console;

namespace exercies03
{
    class Program
    {
        static void Main(string[] args){
            BigInteger i = new BigInteger(905652);
            //BigInteger i = new BigInteger(65);
            WriteLine(i.ToWords());
        }
    }
}
