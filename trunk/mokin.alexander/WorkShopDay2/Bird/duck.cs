using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bird
{
    public class Duck : IWaterFowl
    {
        public Duck()
        {
            Weight = 20;
            Age = 4;
        }

        public Duck(int weight, int age)
        {
            Age = age;
            if (weight < 10)
            {
                Weight = 10;
                Console.WriteLine("Weight is incorrect ({0}), Your duck weight 10 kilos");
            }
            else
            {
                Weight = weight;
            }
        }
        
        public void Walk()
        {
            Console.WriteLine("Duck is walking");
        }

        public void Fly()
        {
            Console.WriteLine("Duck is flying");
        }

        public void Eat()
        {
            Console.WriteLine("Duck is eating");
            Weight = Weight + 2;
        }

        public void LayAnEgg()
        {
            if (Weight < 2) 
            { 
                Console.WriteLine("Sorry, but duck can't lay eggs");
                return;
            } 
            Random randomizer = new Random(Weight);
            int number = randomizer.Next(Weight - Weight + 5);
            Console.WriteLine("Duck laid {0} eggs", number);
            Weight--;
        }

        public void Swim()
        {
            Console.WriteLine("Duck is swimming");
        }

        public int Weight { get; set; }

        public int Age { get; set; }
    }
}
