using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2.Workshop.Plane
{
	class Fighter : MilitaryPlane
	{
		public Fighter() 
			: base()
		{
			Console.WriteLine("Fighter.DefaultConstructor");
		}

		public Fighter(string name, int crew, int armsWeight)
			: base(name, crew)
		{
			Console.WriteLine("Fighter.ConstructorWithParameters: name = {0}, crew = {1}, arms weight = {2}", name, crew, armsWeight);
			this.armsWeight = armsWeight;
		}

		private int armsWeight;

		public int ArmsWeight
		{
			get
			{
				Console.WriteLine("Fighter.ArmsWeight.get( {0} )", armsWeight);
				return armsWeight;
			}

			set
			{
				Console.WriteLine("Fighter.ArmsWeight.set( {0} )", value);
				armsWeight = value;
			}
		}

		public void Attack( string target )
		{
			Console.WriteLine("Fighter.Attack( {0} )", target);
		}
	}
}
