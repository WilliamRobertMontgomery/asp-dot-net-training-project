using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Animals
{
	interface IAnimal
	{
		void Voice();
		bool isHungry();
		void Sleep();
	}
}
