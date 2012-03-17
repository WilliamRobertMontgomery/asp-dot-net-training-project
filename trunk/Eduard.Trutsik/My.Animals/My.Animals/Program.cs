using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Animals
{
	class Program
	{
		static void Main(string[] args)
		{
			IAnimal animalDog = new Dog("AnimalDog");
			Pet petDog = new Dog("PetDog");
			Dog dog = new Dog("Dog");
			animalDog.Voice();
			animalDog.Sleep();
			Console.WriteLine();

			petDog.Voice();
			petDog.Walk();
			petDog.Play();
			Console.WriteLine("Hungry: {0}",petDog.isHungry());
			petDog.Sleep();
			Console.WriteLine();

			dog.Voice();
			dog.LikeEat();
			dog.Walk();
			dog.Play();
			Console.WriteLine("Hungry: {0}", dog.isHungry());
			dog.Sleep();

			Console.ReadKey();
		}
	}
}
