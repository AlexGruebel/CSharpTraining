using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqWithSets
{
    class Program
    {
        static void Output(IEnumerable<string> cohort, string description)
        {
            if(!string.IsNullOrEmpty(description)){
                Console.WriteLine(description);
            }
            Console.WriteLine(" ");
            Console.WriteLine(string.Join(", ", cohort.ToArray()));
        }

        static void Main(string[] args)
        {
            var cohort1 = new string[]{"Rachel", "Gareth", "Jonathan", "George" };
            var cohort2 = new string[]{"Jack", "Stephen", "Daniel", "Jack", "Jared"};
            var cohort3 = new string[]{"Declan", "Jack", "Jack", "Jasmine", "Conor" };
            Output(cohort1, "chort1");
            Output(cohort2, "chort3");
            Output(cohort3, "chort3");

            Output(cohort2.Distinct(), "distinct chort3");
            Output(cohort2.Union(cohort3), "union chort2 and 3");
            Output(cohort2.Concat(cohort3), "concat --> with duplicates");
            Output(cohort2.Intersect(cohort3), "Schnittmenge");
        }
    }
}
