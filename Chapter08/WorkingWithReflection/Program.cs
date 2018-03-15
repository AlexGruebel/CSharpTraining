using System;
using System.Reflection;
using System.Linq;

namespace WorkingWithReflection
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine("Assembly metadata");
            Assembly assembly = Assembly.GetEntryAssembly();
            Console.WriteLine($"Full name: {assembly.FullName}");
            Console.WriteLine($"Location: {assembly.Location}");

            var attributes = assembly.GetCustomAttributes();

            Console.WriteLine("Attributes:");
            foreach (var a in attributes){
                Console.WriteLine($" {a.GetType()}");
            }

            //Company & Version Attribut in .csproj Datei gesetzt

            Console.WriteLine("\nCustom Attribute:");
            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            Console.WriteLine($" Company: {company.Company}");

            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            Console.WriteLine($" Version: {version.InformationalVersion}");

            Console.WriteLine("Types:");

            Type[] types = assembly.GetTypes();

            foreach (var type in types){
                Console.WriteLine($" Name {type.FullName}");

                MemberInfo[] members = type.GetMembers();

                foreach (var member in members){
                    Console.WriteLine($" {member.MemberType}: {member.Name} ({member.DeclaringType.Name})");

                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);

                    foreach (CoderAttribute coder in coders){
                        Console.WriteLine($"Modified by {coder.Coder} on {coder.LastModified}");
                    }
                }
            }
        }

        [Coder("Alexander Grümbel", "12.01.2017")]
        [Coder("Alexander Grümbel2", "01.01.2017")]
        public void DoStuff(){
            Console.WriteLine("Do Stuff");
        }
    }
}
