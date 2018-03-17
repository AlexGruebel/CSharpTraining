using System;
using System.Linq;

namespace Exercies02
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new Northwind())
            {
                Console.WriteLine("Our Customer are living in following Citys: ");

                foreach(var vcity in db.Customers.Select(c => c.City).Distinct().ToArray<string>())
                {
                    Console.WriteLine(vcity);
                }


                Console.Write("Enter a City name: ");
                string city = Console.ReadLine();

                var custumersInCity = db.Customers.Where(c => c.City == city).ToArray();

                Console.WriteLine($"There a {custumersInCity.Count()} Customers in {city}");

                foreach (var item in db.Customers.Where(c => c.City == city).ToArray())
                {
                    Console.WriteLine(item.CompanyName);
                }

                Console.ReadKey();
            }
        }
    }
}
