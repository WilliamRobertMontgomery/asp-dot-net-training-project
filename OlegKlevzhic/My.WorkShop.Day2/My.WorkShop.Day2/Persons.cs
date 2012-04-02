using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.WorckShop.Day2
{
	public abstract class Person
	{
		private string firstName;
		private string lastName;
		private int age;

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		public abstract bool IsHungry();

		public abstract void IntroduceYourself(Person person);
	}

	public class ConcretePerson : Person
	{
		public ConcretePerson()
		{

		}

		public ConcretePerson(string firstName, string lastName, int age)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
		}

		public override string ToString()
		{
			return "My name is " + FirstName.ToString() + " " + LastName.ToString() + ", I am " + Age.ToString() + " years old.";
		}

		public override bool IsHungry()
		{
			if (new Random().Next(1, 5) == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void IntroduceYourself(Person person)
		{
			if (person.IsHungry() == false)
			{
				Console.WriteLine(person.ToString() + "\nI am not hungry!");
			}
			else
			{
				Console.WriteLine(person.ToString() + "\nI am hungry!");
			}

		}
	}

	public class StudentConcretePerson : ConcretePerson
	{
		private int rate;

		public int Rate
		{
			get { return rate; }
			set { rate = value; }
		}

		public StudentConcretePerson()
		{

		}

		public StudentConcretePerson(string firstName, string lastName, int age, int rate)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
			this.Rate = rate;
		}

		public override bool IsHungry()
		{
			return true; // Student is always hungry :)
		}

		public override string ToString()
		{
			return base.ToString() + " I'm a student. I am a " + Rate.ToString() + " course.";
		}
	}

	public class ExtramuralStudentConcretePerson : StudentConcretePerson
	{
		public ExtramuralStudentConcretePerson()
		{

		}

		public ExtramuralStudentConcretePerson(string firstName, string lastName, int age, int rate)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
			this.Rate = rate;
		}

		public override string ToString()
		{
			return base.ToString() + " I'm a extramural.";
		}

		public override bool IsHungry()
		{
			if (new Random().Next(1, 8) == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
