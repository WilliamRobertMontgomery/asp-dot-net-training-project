using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2.Workshop.Plane
{
	class Fighter : MilitaryPlane
	{
		private int armsWeight;

		public Fighter() 
			: base()
		{
			Console.WriteLine("Fighter.DefaultConstructor");
		}

		public Fighter(string name, int crew, int armsWeight)
			: base(name, crew)
		{
			this.armsWeight = armsWeight;
			Console.WriteLine("Fighter.ConstructorWithParameters: name = {0}, crew = {1}, arms weight = {2}", name, crew, armsWeight);
		}

		public int ArmsWeight
		{
			get	{ return armsWeight; }
			set { armsWeight = value; }
		}

		public void Attack( string target )
		{
			Console.WriteLine("Fighter.Attack( {0} )", target);
		}

		public override void PrintInformation()
		{
			Console.WriteLine(	"Fighter Information:\n" +
								" name: {0}\n crew: {1}\n arms weight: {2}", Name, Crew, ArmsWeight);
		}

	}
}
