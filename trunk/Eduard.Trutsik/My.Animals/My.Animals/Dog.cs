using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Animals
{
	class Dog :Pet
	{
		public Dog(string name)
		{
			this.name = name;
		}

		public Dog():base("Dog")
		{

		}

		public void LikeEat()
		{
			Console.WriteLine("I like bones.");
		}

		public void Voise()
		{
			Console.WriteLine("I am a dog.");
		}
 
	}
}
