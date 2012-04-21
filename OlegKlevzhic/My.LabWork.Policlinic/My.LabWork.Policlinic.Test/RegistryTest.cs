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
			Assert.AreEqual(registry.Greeting(thePacient), "Hello,Pacient: FirstName LastName!");
		}

		[Test]
		public void GetSpecializationTest()
		{
			Assert.AreEqual(registry.GetSpecialization(), "1. Surgeon\n2. Therapist\n");
		}

		[Test]
		public void GetDoctorTest()
		{
			Assert.AreEqual(registry.GetDoctor(1).ToString(), "Doctor: Michael Jhonson. Surgeon");
		}

		[Test]
		public void GetDoctorsSpecializationTest()
		{
			Assert.AreEqual(registry.GetDoctorsSpecialization(1), "1. Doctor: Michael Jhonson. Surgeon\n2. Doctor: Anna Nicolson. Surgeon\n");
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
	}
}
