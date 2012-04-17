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
			Console.WriteLine("MilitaryPlane:");

			MilitaryPlane myPlane = new MilitaryPlane();
			myPlane.Name = "Boeing KC-135";
			myPlane.Crew = 4;
			myPlane.Takeoff();
			myPlane.FlyTo("Panama");
			myPlane.Land();

			Console.WriteLine("\nFighter:");

			Fighter myFighter = new Fighter("F-35", 1, 28000);
			myFighter.Takeoff();
			myFighter.FlyTo("Military range");
			myFighter.Attack("First target");
			myFighter.Attack("Second target");
			myFighter.FlyTo("Air base");
			myFighter.Land();

			Console.ReadKey();
		}
	}
}
