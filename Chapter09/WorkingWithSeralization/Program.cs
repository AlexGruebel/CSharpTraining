using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Packt;
using Newtonsoft.Json;

namespace WorkingWithSeralization
{
    class Program
    
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WorkingWithSeralization");
            var people = new List<Person>{
                new Person(2500){FirstName = "Alice", LastName = "Fischer", DateOfBirth = new DateTime(1974, 3, 14)},
                new Person(40000M) { FirstName = "Bob", LastName = "Jones", DateOfBirth = new DateTime(1969, 11, 23) },
                new Person(20000M) { FirstName = "Charlie", LastName = "Rose", DateOfBirth = new DateTime(1964, 5, 4),
                Children = new HashSet<Person>{ new Person(0M) { FirstName = "Sally", LastName = "Rose", DateOfBirth = new DateTime(1990, 7, 12)}} }
            };

            //SerializationXML(people);
            SerializeJson(people);
        }


        static void SerializationXML(List<Person> people)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "example2.xml");
            using(FileStream stream = File.Create(path)){
                var xml = new XmlSerializer(typeof(List<Person>));
                xml.Serialize(stream, people);
            }
        }
        
        static void SerializeJson(List<Person> people){
            string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "example.json");
            StreamWriter jsonStream = File.CreateText(jsonPath);
            var jss = new JsonSerializer();
            jss.Serialize(jsonStream, people);
            jsonStream.Close();
        }
    }
}
