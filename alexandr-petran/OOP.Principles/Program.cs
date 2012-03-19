using System;
using System.Text;

namespace OOP.Principles
{
	class Program
	{
		static void Main(string[] args)
		{
			ShowDoctorsWork();

			ShowCommonSurgeonsWork();

			ShowGoodSurgeonsWork();

			ShowBadSurgeonsWork();
		}

		private static void ShowBadSurgeonsWork()
		{
			Console.WriteLine(Resources.Separator);
			Console.WriteLine(Resources.BadSurgeon);

			IBadSurgeon badSurgeon = new Surgeon(Resources.DoctorsName, Resources.DoctorsSurname, Resources.Employer);
			Console.WriteLine(badSurgeon.Work());
			Console.WriteLine("{0} is bad - {1}", badSurgeon.Name, badSurgeon.Kill());
		}

		private static void ShowGoodSurgeonsWork()
		{
			Console.WriteLine(Resources.Separator);
			Console.WriteLine(Resources.GoodSurgeon);

			IGoodSurgeon goodSurgeon = new Surgeon(Resources.DoctorsName, Resources.DoctorsSurname, Resources.Employer);
			Console.WriteLine(goodSurgeon.Work());
			Console.WriteLine("{0} is good - {1}",goodSurgeon.Name,goodSurgeon.Cure() );
		}

		private static void ShowCommonSurgeonsWork()
		{
			Console.WriteLine(Resources.Separator);
			Console.WriteLine(Resources.Surgeon);

			Surgeon someSurgeon = new Surgeon(Resources.DoctorsName,Resources.DoctorsSurname,Resources.Employer);
			Console.WriteLine(someSurgeon.Work());
			Console.WriteLine("{0} succeeded in his surgery: {1}",someSurgeon.Name,someSurgeon.Cure());
			Console.WriteLine("{0} failed his surgery: {1}", someSurgeon.Name, someSurgeon.Kill());
		}

		private static void ShowDoctorsWork()
		{
			Console.WriteLine(Resources.Separator);
			Console.WriteLine(Resources.JustDocor);

			Doctor someDoctor = new Doctor
			                    	{
			                    		Name = Resources.DoctorsName,
			                    		Surname = Resources.DoctorsSurname,
			                    		Employer = Resources.Employer
			                    	};
			Console.WriteLine("Name: \t\t{0} \nSurname:\t{1} \nEmployer:\t{2}",someDoctor.Name,someDoctor.Surname,someDoctor.Employer);
			Console.WriteLine(someDoctor.Work());
		}
	}
}
