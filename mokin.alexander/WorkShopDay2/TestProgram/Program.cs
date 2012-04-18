using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bird;
namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck duck = new Duck();
            duck.Eat();
            duck.Fly();
            duck.LayAnEgg();
            duck.Swim();
            duck.Walk();
            Console.WriteLine("**Duck is checked\n");

            Swan swan = new Swan();
            swan.Eat();
            swan.Fly();
            swan.LayAnEgg();
            swan.Swim();
            swan.Walk();
            Console.WriteLine("**Swan is checked\n");

            Console.WriteLine("**Duck as a IBird");
            IBird bird = new Duck(20, 10);
            bird.Eat();
            bird.Fly();
            bird.LayAnEgg();
            bird.Walk();

            Console.WriteLine("\n**Swan as a IBird");
            bird = new Swan(20, 10);
            bird.Eat();
            bird.Fly();
            bird.LayAnEgg();
            bird.Walk();

            Console.WriteLine("\n**Duck as a IWaterFowl");
            IWaterFowl waterFowl = new Duck(20, 1);
            waterFowl.Eat();
            waterFowl.Fly();
            waterFowl.LayAnEgg();
            waterFowl.Walk();
            waterFowl.Swim();

            Console.WriteLine("\n**Swan as a IWaterFowl");
            waterFowl = new Swan(10, 1);
            waterFowl.Eat();
            waterFowl.Fly();
            waterFowl.LayAnEgg();
            waterFowl.Walk();
            waterFowl.Swim();                  
        }
    }
}
