using System;
using PacktLibrary;
namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            void Harry_Shout(object sender, System.EventArgs e){
                Person p = (Person)sender;
                Console.WriteLine($"Person {p.Name} is this angry {p.AngerLevel}");
            }
            
            var p1 = new Person("Harry");
            var p2 = new Person("Lizzey");
            
            p1.Shout+=Harry_Shout;
            p1.Poke();
            p1.Poke();
            p1.Poke();
            p1.Poke();
            p1.Poke();
            var baby = p1 * p2;

            Console.WriteLine($"{baby.Name}");
             
            Console.WriteLine($"{p1.Children[0].Name}");


            Person[] people = {
                new Person("Richart"),
                new Person("Franz"),
                new Person("Emilia")
            };
            Console.WriteLine("Initial list of people:");
            foreach (var person in people){
                Console.WriteLine($"{person.Name}");
            }
            Console.WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (var person in people){
                Console.WriteLine($"{person.Name}");
            }
            */

            Employee e1 = new Employee{
                Name = "John",
                DateOfBirth = new DateTime(1990, 7, 28)
            };

            e1.EmployeeCode = "JJ001";
            e1.HireDate = new DateTime(2014, 11, 23);
            Console.WriteLine($"{e1.Name} was hired on {e1.HireDate:dd/MM/yy}");
        }
    }
}
            
