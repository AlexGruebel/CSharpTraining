using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace exercies02
{
    class Program
    {
        static void Main(string[] args){
            var defaultExp = new Regex(@"\d+");
            
            WriteLine("The default regular Expression checks for at least one digit");
            
            while(true){
                Write("Enter a regular expression (or press ENTER to use the default): ");
                string exp = ReadLine();
                Write("Enter some input: ");
                string text = ReadLine();
                Regex expr = null;
                if(exp == ""){
                    expr = defaultExp;
                }else{
                    expr = new Regex(@exp);
                }
                Write($"{text} matches {expr.ToString()} {expr.IsMatch(text)}\n");
                Write("Press ESC to end or any key to try again.");
                var key = ReadKey();
                if(ConsoleKey.Escape.Equals(key.Key)){
                    Write("\n");
                    break;
                }
            }
                          
        }
    }
}
