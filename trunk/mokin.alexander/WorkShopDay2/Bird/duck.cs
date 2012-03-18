using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bird
{
    public class Duck : IWaterFowl
    {
        private int weight;
        private int age;

        public Duck()
        {
            weight = 20;
            age = 4;
        }

        public Duck(double weight, int age)
        {
            this.age = age;
            if (weight < 10)
            {
                weight = 10;
                Console.WriteLine("Weight is incorrect ({0}), Your duck weight 10 kilos");
            }
        }
        
        public void walk()
        {
            Console.WriteLine("Duck is walking");
        }

        public void fly()
        {
            Console.WriteLine("Duck is flying");
        }

        public void eat()
        {
            Console.WriteLine("Duck is eating");
            weight = weight + 2;
        }

        public void layAnEgg()
        {
            if (weight < 2) 
            { 
                Console.WriteLine("Sorry, but duck can't lay eggs");
                return;
            } 
            Random randomizer = new Random(weight);
            int number = randomizer.Next(weight - weight + 5);
            Console.WriteLine("Duck laid {0} eggs", number);
            weight--;
        }

        public void swim()
        {
            Console.WriteLine("Duck is swimming");
        }

        public void info()
        {
            Console.WriteLine("Your duck weight {0} kilos, and its age is {1} years", weight, age);
        }
    }
}
