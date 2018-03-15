using System;
using System.Linq;

namespace ExamplesLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            LingWithArrayOfStrings();
        }

        static void LingWithArrayOfStrings(){
            var names = new string[] { "Michael", "Pam", "Jim","Dwight", "Angela", "Kevin", "Toby", "Creed"};
            //Delgate FUnc das die Methode NameLongerThanFour ausführt
            //var querry = names.Where(new Func<string, bool>(NameLongerThanFour));
            //vereinfachte Schreibweise --> der Compiler erstellt das Delegate für uns
            //var querry = names.Where(NameLongerThanFour);
            //noch mehr vereinfachte Schreibweise mit einer Lambda expression
            var querry = names.Where(n => n.Length > 4)
                            .OrderBy(n => n.Length)
                            .ThenBy(name => name);
            foreach(string item in querry)
            {
                Console.WriteLine(item);
            }

            bool NameLongerThanFour(string name)
            {
                return name.Length > 4;
            }
        }



    }
}
