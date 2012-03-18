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
            Duck Duck1 = new Duck();
            Duck Duck2 = new Duck();
            Duck Duck3 = new Duck(20, 4);

            Duck1.eat();
            Duck1.fly();
            Duck1.layAnEgg();
            Duck1.swim();
            Duck1.walk();
            Duck1.info();
            Console.WriteLine();

            IBird ibird1;
            ibird1 = Duck2;
            ibird1.fly();
            ibird1.eat();
            ibird1.layAnEgg();
            ibird1.walk();
            Console.WriteLine();

            IWaterFowl WF = Duck3;
            WF.eat();
            WF.fly();
            WF.layAnEgg();
            WF.swim();
            WF.walk();
            Console.WriteLine();
            Console.Read();
        }
    }
}
