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
			Console.WriteLine("MilitaryPlane.ConstructorWithParameters: name = {0}, crew = {1}", name, crew);
			this.name = name;
			this.crew = crew;
		}

		public string Name{
			get
			{
				Console.WriteLine("MilitaryPlane.Name.get( {0} )", name);
				return name;
			}
			
			set
			{
				Console.WriteLine("MilitaryPlane.Name.set( {0} )", value);
				name = value;
			}
		}

		public int Crew{
			get
			{
				Console.WriteLine("MilitaryPlane.Crew.get( {0} )", crew);
				return crew;
			}

			set
			{
				Console.WriteLine("MilitaryPlane.Crew.set( {0} )", value);
				crew = value;
			}
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

	}
}
