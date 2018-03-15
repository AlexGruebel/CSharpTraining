using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Packt
{
    public class Person
    {
        public Person(decimal salery){
            this.Salary = salery;
        }

        public Person(){

        }

        [XmlAttribute("fname")]
        public string FirstName{get; set;}
        [XmlAttribute("lname")]
        public string LastName{get; set;}
        [XmlAttribute("dbirth")]
        public DateTime DateOfBirth {get; set;}
        public HashSet<Person> Children {get; set;}
        protected decimal Salary {get; set;}


    }
}