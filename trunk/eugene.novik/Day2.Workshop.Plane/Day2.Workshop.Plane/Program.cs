using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2.Workshop.Plane
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(">> MilitaryPlane:");

			MilitaryPlane myPlane = new MilitaryPlane();
			myPlane.Name = "Boeing KC-135";
			myPlane.Crew = 4;
			myPlane.Takeoff();
			myPlane.FlyTo("Panama");
			myPlane.Land();
			myPlane.PrintInformation();

			Console.WriteLine("\n>> Fighter:");

			Fighter myFighter = new Fighter("F-35", 1, 1800);
			myFighter.Takeoff();
			myFighter.FlyTo("Military range");
			myFighter.Attack("First target");
			myFighter.Attack("Second target");
			myFighter.FlyTo("Air base");
			myFighter.Land();
			myFighter.PrintInformation();


			Console.WriteLine("\n\n>> IPlane:");

			Console.WriteLine("\n>>MilitaryPlane:");
			IPlane myIPlane = new MilitaryPlane("Ty-160", 4);
			myIPlane.PrintInformation();

			Console.WriteLine("\n>> Fighter:");
			myIPlane = new Fighter("MiG-29", 1, 2180);
			myIPlane.PrintInformation();

			Console.ReadKey();
		}
	}
}
