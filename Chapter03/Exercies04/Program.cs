using System;

namespace Exercies04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a Nummber between 0 and 255: ");
            string operand1 = Console.ReadLine();
            Console.Write("Enter another Nummber between 0 and 255: ");   
            string operand2 = Console.ReadLine();      

            byte op1;
            byte op2;

            try{
                op1 = Convert.ToByte(operand1);
                op2 = Convert.ToByte(operand2);
                Console.WriteLine($"{op1} divided by {op2} is {op1/op2}");
            }catch(FormatException ex){
                Console.WriteLine($"{ex.GetType()} input string was not in correct from");
            }catch(OverflowException ex){
                Console.WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            
        }
    }
}
