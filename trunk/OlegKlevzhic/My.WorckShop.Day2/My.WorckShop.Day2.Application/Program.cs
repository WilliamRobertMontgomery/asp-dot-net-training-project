using System;

namespace My.WorckShop.Day2.Application
{
	class Program
	{
		static void Main(string[] args)
		{
			Person person = new ConcretePerson("Sergey", "Sergeev", 2);
			person.IntroduceYourself(person);
			Console.WriteLine();

			person.Age = 30;
			person.IntroduceYourself(person);
			Console.WriteLine();

			Person studentPerson = new StudentConcretePerson("Petr", "Petrov", 24, 3);
			studentPerson.IntroduceYourself(studentPerson);
			Console.WriteLine();

			Person extramuralStudentPerson = new ExtramuralStudentConcretePerson("Ivan", "Ivanov", 20,2);
			extramuralStudentPerson.IntroduceYourself(extramuralStudentPerson);

			Console.ReadKey();
		}
	}
}
