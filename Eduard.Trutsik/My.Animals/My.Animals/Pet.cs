using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Animals
{
	class Pet:IAnimal
	{
		public string name;

		public Pet()
		{
			name = "Pet";
		}

		public Pet(string name)
		{
			this.name = name;
		}

		public void Play()
		{
			Console.WriteLine("{0} plays.", name);
		}

		public void Walk()
		{
			Console.WriteLine("{0} for a walk.", name);
		}

		public virtual void Voice()
		{
			Console.WriteLine("{0} is a pet", name);
		}

		public bool isHungry()
		{
			Random rand = new Random();
			if (rand.Next(10) < 5)
			{
				return false;
			}
			else
			{
				return true;
			}

		}

		public void Sleep()
		{
			Console.WriteLine("ZZZzzz...");
		}
	}
}
