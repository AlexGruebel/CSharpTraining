using System;

namespace Exercies03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Page 137
            //fizzBuzzIF();
            for (int i = 0; i < 200; i++){
                string output = "";

                switch(i.ToString()){
                    case String a when a.ToString().Contains("3"):
                        output+="fizz";
                    break;
                    
                    case  String b when b.ToString().Contains("5") :
                        output+="buzz";
                    break;
                    default:
                        output=i.ToString();
                    break;
                }

                Console.WriteLine(output);
            }
        }

        private static void fizzBuzzIF()
        {
            for (int i = 0; i < 200; i++)
            {
                string output = "";
                if (i.ToString().Contains("3"))
                {
                    output += "fizz";
                }

                if (i.ToString().Contains("5"))
                {
                    output += "buzz";
                }

                if (output.Equals(""))
                {
                    output = i.ToString();
                }

                Console.WriteLine(output);
            }
        }
    }
}
