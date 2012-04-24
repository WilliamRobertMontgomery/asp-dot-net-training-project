using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2.Workshop.Plane
{
	class MilitaryPlane : IPlane
	{
		private string name;
		private int crew;


		public MilitaryPlane()
		{
			Console.WriteLine("MilitaryPlane.DefaultConstructor");
		}

		public MilitaryPlane(string name, int crew)
		{
			this.name = name;
			this.crew = crew;
			Console.WriteLine("MilitaryPlane.ConstructorWithParameters: name = {0}, crew = {1}", name, crew);
		}

		public string Name{
			get { return name; }
			set { name = value; }
		}

		public int Crew{
			get { return crew; }
			set { crew = value; }
		}

		public void Takeoff() 
		{
			Console.WriteLine("MilitaryPlane.Takeoff()");
		}

		public void FlyTo(string target) 
		{
			Console.WriteLine("MilitaryPlane.FlyTo( {0} )", target);
		}

		public void Land()
		{
			Console.WriteLine("MilitaryPlane.Land()");	
		}

		public virtual void PrintInformation()
		{
			Console.WriteLine(	"MilitaryPlane Information:\n" +
								" name: {0}\n crew: {1}", Name, Crew );
		}
	}
}
