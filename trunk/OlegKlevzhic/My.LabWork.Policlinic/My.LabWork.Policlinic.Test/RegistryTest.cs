using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using My.LabWork.Policlinic.Library.DataAccess;
using My.LabWork.Policlinic.Library.Business;
using My.LabWork.Policlinic.Library.Business.Registry;

namespace My.LabWork.Policlinic.Test
{
	[TestFixture]
	public class RegistryTest
	{
		private IRegistry registry = new Registry();

		[Test]
		public void GreetingTest()
		{
			Pacient thePacient = new Pacient("FirstName", "LastName");
			Assert.AreEqual(registry.Greeting(thePacient), "Hello,FirstName LastName!");
		}

		[Test]
		public void GetTimeDoctoTest()
		{
			Assert.AreEqual(registry.GetTimeDoctor(1), DateTime.Now.AddMinutes(2));
		}

		[Test]
		public void GetTimeSpecializationTest()
		{
			Assert.AreEqual(registry.GetTimeSpecialization(1), DateTime.Now.AddMinutes(2));
		}

		[Test]
		public void GetDoctorTest()
		{
			Assert.AreEqual(new Doctor("Anna", "Nicolson", 2) { Id = 2 }, registry.GetDoctor(2));
		}

		[Test]
		public void WriteToReceptionTest()
		{
			var tmp = DateTime.Now;
			var actual = new Record(2, 1, tmp);
			var expected = registry.WriteToReceptionDoctor(2, new Pacient("FirstName", "LastName") { Id = 1 }).Time = tmp;
			Assert.AreEqual(actual, expected);
		}

		[Test]
		public void GetSpecializationTest()
		{
			Assert.AreEqual(registry.GetSpecialization(1), new Specialization() { Id = 1, NameSpecialization = "Surgeon" });
		}

		[Test]
		public void GetSpecializationsTest()
		{
			Assert.AreEqual(registry.GetSpecializations(), new List<Specialization>() { new Specialization() { Id = 1, NameSpecialization = "Surgeon" }, new Specialization() { Id = 2, NameSpecialization = "Therapist" } });
		}
	}
}
