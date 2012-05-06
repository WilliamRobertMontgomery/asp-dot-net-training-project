using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork.Policlinic.Library.Business;
using My.LabWork.Policlinic.Library.Business.Registry;
using My.LabWork.Policlinic.Library.DataAccess;
using My.LabWork.Policlinic.Library.Extentions;
using System.Threading;

namespace My.LabWork.Policlinic.Presentation
{
	class Program
	{
		public static Registry theRegistry;

		public static void MenuSpecialization()
		{
			Console.WriteLine("0. Quit");
			Console.Write(theRegistry.GetSpecializations().GetString());
		}

		public static void MenuDoctors(int numberSpecialization)
		{
			Console.WriteLine("0. Back up.");
			Console.WriteLine(theRegistry.GetDoctorsSpecialization(numberSpecialization).GetString());
		}

		public static void MenuRegistration(int numberDoctor)
		{
			var time = theRegistry.GetTimeDoctor(numberDoctor);
			Console.WriteLine("{0}: {1:HH:mm}", theRegistry.GetDoctor(numberDoctor), time);
			Console.WriteLine("0. Back up.\n1. Sign on.");
		}

		public static Pacient RegistrationPacient()
		{
			Console.Write("Enter your FirstName: ");
			string firstName = Console.ReadLine();
			Console.Write("Enter your LastName: ");
			string lastName = Console.ReadLine();
			return new Pacient(firstName, lastName);
		}

		static void Main(string[] args)
		{
			theRegistry = new Registry();
			Pacient pacient = RegistrationPacient();
			Console.WriteLine(theRegistry.Greeting(pacient));
			int numberSpecialization = -1;
			int numberDoctor = -1;
			Console.WriteLine("Enter number of specialization, please: ");
			while (numberSpecialization != 0)
			{
				MenuSpecialization();
				numberSpecialization = int.Parse(Console.ReadLine());
				numberDoctor = -1;
				while (numberDoctor != 0 && numberSpecialization != 0)
				{
					MenuDoctors(numberSpecialization);
					numberDoctor = int.Parse(Console.ReadLine());
					if (numberDoctor == 0)
					{
						break;
					}
					MenuRegistration(numberDoctor);
					int n = int.Parse(Console.ReadLine());
					if (n == 1)
					{
						numberSpecialization = 0;
						Console.WriteLine(theRegistry.WriteToReceptionDoctor(numberDoctor, pacient).ToString());
						break;
					}
				}
				new Timer(new TimerCallback(theRegistry.GetDoctor(numberDoctor).Reception), ThreadState.Running, 0, 500);
			}

			//theRegistry.WriteToReceptionDoctor(1, pacient);
			Console.ReadLine();
		}
	}
}
