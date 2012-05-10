using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using My.LabWork1.Policlinic.Business;
using My.LabWork1.Policlinic.Entities;
using My.LabWork1.Policlinic.DataAccess;
using System.IO;
using System.Threading;

namespace My.LabWork1.Policlinic.Test
{
	[TestFixture]
	public class RegistryTest
	{
		private static string path = @"e:\#Worckspace\#Training\OlegKlevzhic\My.LabWork1\My.LabWork1.Policlinic.Test\Data\";
		Registry reg = new Registry(path);

		void Rest()
		{
			new FileStream(path + "Records.txt", FileMode.Create).Close();
			new FileStream(path + "Pacients.txt", FileMode.Create).Close();
			new FileStream(path + "Specializations.txt", FileMode.Create).Close();
			new FileStream(path + "Doctors.txt", FileMode.Create).Close();
			new Repository<Specialization>(path).Save(new Specialization(1, "Surgeon"));
			new Repository<Specialization>(path).Save(new Specialization(2, "Therapist"));

			new Repository<Doctor>(path).Save(new Doctor(1) { FirstName = "Michael", LastName = "Jhonson", Id_Specialization = 1 });
			new Repository<Doctor>(path).Save(new Doctor(2) { FirstName = "Anna", LastName = "Nicolson", Id_Specialization = 1 });
			new Repository<Doctor>(path).Save(new Doctor(3) { FirstName = "Mic", LastName = "Jho", Id_Specialization = 2 });
			new Repository<Doctor>(path).Save(new Doctor(4) { FirstName = "Nick", LastName = "Rone", Id_Specialization = 2 });
		}

		[Test]
		public void GreetingTest()
		{
			Pacient pacient = new Pacient() { FirstName = "1", LastName = "2" };
			Assert.AreEqual(reg.Greeting(pacient), String.Format("Hello,{0}!", "1 2"));
		}

		[Test]
		public void MenuSpecializationsTest()
		{
			Rest();
			Assert.AreEqual(reg.MenuSpecializations(), String.Format("0. Quit\n{0}", "1. Surgeon\n2. Therapist\n"));
		}

		[Test]
		public void MenuDoctorsTest()
		{
			Rest();
			Assert.AreEqual(reg.MenuDoctors(1), String.Format("0. Back up.\n{0}", "1. Michael Jhonson\n2. Anna Nicolson\n"));
		}

		[Test]
		public void GetTimeDoctor()
		{
			Rest();
			Assert.AreEqual(reg.GetTimeDoctor(4), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute + 2, 0));
		}

		[Test]
		public void WriteToReception()
		{
			Rest();
			var actual = new Record(new Repository<Doctor>(path).Get(4), new Pacient() { Id = 1, FirstName = "1", LastName = "1" }, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute + 2, 0));
			var expected = reg.WriteToReceptionDoctor(4, new Pacient() { Id = 1, FirstName = "1", LastName = "1" });
			Assert.AreEqual(actual.DateTime, expected.DateTime);
			Assert.AreEqual(actual.Pacient.FirstName, expected.Pacient.FirstName);
			Assert.AreEqual(actual.Doctor.Id, expected.Doctor.Id);
		}
	}
}
