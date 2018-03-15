using System;
using System.Text.RegularExpressions;

namespace WorkingWithRegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your age");
            string input = Console.ReadLine();
            var ageChecker = new Regex(@"^\d+$");
            if(ageChecker.IsMatch(input)){
                Console.WriteLine("Thank you");
            }else{
                Console.WriteLine("This is not a valid age");
            }
        }
    }
}
