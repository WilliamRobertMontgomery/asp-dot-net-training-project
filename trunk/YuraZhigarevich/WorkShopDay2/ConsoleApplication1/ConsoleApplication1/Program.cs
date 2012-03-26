using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Person
    {
        private string name;
        private int age;
    
        public virtual void ShowInfo()
        {
            Console.WriteLine("My name is {0}, my age is {1}",name, age);
        }
        
        public Person(string name, int age)
        {
            this.name=name;
            this.age=age;
        }
    }
    public class Student : Person
    {
        private string university;
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("My university is {0}",university);
        }
        public Student(string name, int age, string university):base(name,age)
          {
            this.university = university;
          }
    }

    public class ExStudent : Student
    {
        private string adress;
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("My adress is {0}", adress);
        }
        public ExStudent(string name, int age, string university, string adress):base(name,age,university)
        {
            this.adress=adress;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Person--Student--ExStudent: ");
            Console.WriteLine();
            Person person1 = new Person("Vasia",26);
            Person person2 = new Person("Petia", 25);
            person1.ShowInfo();
            person2.ShowInfo();
            Person person3 = new Student("Vasia", 26,"BSU");
            Person person4 = new Student("Petia", 25, "BrSU");
            Console.WriteLine();
            person3.ShowInfo();
            person4.ShowInfo();
            Person person5 = new ExStudent("Vasia", 26, "BSU", "Brest");
            Person person6 = new ExStudent("Petia", 25, "BrSU", "Minsk");
            Console.WriteLine();
            person5.ShowInfo();
            person6.ShowInfo();

        }
    }
}
