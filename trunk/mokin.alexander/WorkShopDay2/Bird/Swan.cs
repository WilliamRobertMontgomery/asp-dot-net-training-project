using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bird
{
    public class Swan : IWaterFowl
    {
        public Swan()
        {
            Age = 10;
            Weight = 20;
        }

        public Swan(int age, int weight)
        {
            Age = age;
            Weight = weight;
        }

        public void Walk()
        {
            Console.WriteLine("Swan is walking");
        }

        public void Fly()
        {
            Console.WriteLine("Swan is flying");
        }

        public void Eat()
        {
            Console.WriteLine("Swan is eating");
            Weight = Weight + 2;
        }

        public void LayAnEgg()
        {
            if (Weight < 2)
            {
                Console.WriteLine("Sorry, but Swan can't lay eggs");
                return;
            }
            Random randomizer = new Random(Weight);
            int number = randomizer.Next(Weight - Weight + 5);
            Console.WriteLine("Swan laid {0} eggs", number);
            Weight--;
        }

        public void Swim()
        {
            Console.WriteLine("Swan is swimming");
        }

        public int Weight { get; set; }

        public int Age { get; set; }
    }
}
