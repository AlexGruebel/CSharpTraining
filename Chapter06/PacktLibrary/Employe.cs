using System;
using static System.Console;
using System.Collections.Generic;
namespace PacktLibrary
{
    public class Employee : Person{
   
        public string EmployeeCode {get; set;}
        public DateTime HireDate {get; set;}

        public override void WriteToConsole(){
            Console.WriteLine($"{Name}'s birth date is {DateOfBirth:dd/MM/yy} and hiredate was {HireDate:dd/MM/yy}");
        }

        
    }
}