using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WorkingWithLists
{
    class Program
    {
        static void Main(string[] args){
            var cites = new List<string>();
            cites.Add("München");
            cites.Add("Frankfuhrt");
            cites.Add("Köln");
            cites.Add("New York");

            foreach(string city in cites){
                Console.WriteLine(city);
            }
            
            cites.Insert(0, "Sydney");

            cites.RemoveAt(1);
            cites.Remove("Köln");


            Console.WriteLine("\nAfter removing two cites and adding one");

            foreach(string city in cites){
                Console.WriteLine(city);
            }

            var immutableCities = cites.ToImmutableList();
            var newList = immutableCities.Add("Rio");

            Console.Write("\nImmutable City: ");

            foreach (var item in immutableCities){
                Console.Write($" {item} ");
            }

            Console.Write("\nNew citys.....: ");

            foreach (var item in newList){
                Console.Write($" {item} ");
            }

            Console.WriteLine();
        }
    }
}
