using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork1.Policlinic.DataAccess;
using My.LabWork1.Policlinic.Entities;
using My.LabWork1.Policlinic.Business;
using System.Threading;

namespace My.LabWork1.Policlinic
{
	class Program
	{
		public static Pacient RegistrationPacient()
		{
			Console.Write("Enter your FirstName: ");
			string firstName = Console.ReadLine();
			Console.Write("Enter your LastName: ");
			string lastName = Console.ReadLine();
			return new Pacient() { FirstName = firstName, LastName = lastName };
		}
		public static string path = @"e:\#Worckspace\#Training\OlegKlevzhic\My.LabWork1\My.LabWork1\Data\";

		static void Main(string[] args)
		{
			
			/*new Repository<Specialization>(path).Save(new Specialization(1, "Surgeon"));
			new Repository<Specialization>(path).Save(new Specialization(2, "Therapist"));

			new Repository<Doctor>(path).Save(new Doctor(1) { FirstName = "Michael", LastName = "Jhonson", Id_Specialization = 1 });
			new Repository<Doctor>(path).Save(new Doctor(2) { FirstName = "Anna", LastName = "Nicolson", Id_Specialization = 1 });
			new Repository<Doctor>(path).Save(new Doctor(3) { FirstName = "Mic", LastName = "Jho", Id_Specialization = 2 });
			new Repository<Doctor>(path).Save(new Doctor(4) { FirstName = "Nick", LastName = "Rone", Id_Specialization = 2 });*/
			

			Registry registry = new Registry();
			Pacient pacient = RegistrationPacient();
			Console.WriteLine(registry.Greeting(pacient));
			int numberSpecialization = -1;
			int numberDoctor = -1;
			Console.WriteLine("Enter number of specialization, please: ");
			while (numberSpecialization != 0)
			{
				Console.WriteLine(registry.MenuSpecializations());
				numberSpecialization = int.Parse(Console.ReadLine());
				numberDoctor = -1;
				while (numberDoctor != 0 && numberSpecialization != 0)
				{
					Console.WriteLine(registry.MenuDoctors(numberSpecialization));
					numberDoctor = int.Parse(Console.ReadLine());
					if (numberDoctor == 0)
					{
						break;
					}
					Console.WriteLine(registry.MenuRegistration(numberDoctor));
					int n = int.Parse(Console.ReadLine());
					if (n == 1)
					{
						numberSpecialization = 0;
						Console.WriteLine(registry.WriteToReceptionDoctor(numberDoctor, pacient).ToString());
						break;
					}
				}
				var d = new Repository<Doctor>(@"e:\#Worckspace\#Training\OlegKlevzhic\My.LabWork1\My.LabWork1\Data\").Get(numberDoctor);
				Console.WriteLine("Wait please...");
				new Timer(new TimerCallback(d.Reception), ThreadState.Running, 0, 500);
			}
			Console.ReadLine();
		}
	}
}
