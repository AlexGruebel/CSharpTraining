using System;
using static System.Console;
using System.Collections.Generic;
namespace PacktLibrary
{
    public class Person : IComparable<Person>{
    // fields
    public string Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new List<Person>();


    public Person(string n){
        this.Name = n;
    }

    public Person(){

    }

    // methods
    public virtual void WriteToConsole(){
        WriteLine($"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");
    }

    // methods to "multiply"
    public static Person Procreate(Person p1, Person p2){
    var baby = new Person{
        Name = $"Baby of {p1.Name} and {p2.Name}"
    };

    p1.Children.Add(baby);
    p2.Children.Add(baby);
    return baby;
    }

    public Person ProcreateWith(Person partner){
        return Procreate(this, partner);
    }

    public static Person operator*(Person p1, Person p2){
        return Person.Procreate(p1, p2);
    }


    public event EventHandler Shout;
    
    // field
    public int AngerLevel;
    // method
    public void Poke(){
    AngerLevel++;
    if (AngerLevel >= 3){
    // if something is listening...
    // ...then raise the event
    //?.Invoke check if the event is not null
    Shout?.Invoke(this, EventArgs.Empty);
        
    }

    }
        public int CompareTo(Person other){
            return Name.CompareTo(other.Name);
        }
    public override string ToString(){
        return $"{Name} is a {base.ToString()}";
    }
    
    }
    
}