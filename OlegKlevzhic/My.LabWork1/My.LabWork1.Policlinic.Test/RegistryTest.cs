using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using My.LabWork1.Policlinic.Business;
using My.LabWork1.Policlinic.Entities;

namespace My.LabWork1.Policlinic.Test
{
	[TestFixture]
	public class RegistryTest
	{
		Registry reg = new Registry();

		[Test]
		public void GreetingTest()
		{
			Pacient pacient = new Pacient() { FirstName = "1", LastName = "2" };
			Assert.AreEqual(reg.Greeting(pacient), String.Format("Hello,{0}!", "1 2"));
		}

		[Test]
		public void MenuSpecializationsTest()
		{
			Assert.AreEqual(reg.MenuSpecializations(), String.Format("0. Quit\n{0}", "1. Surgeon\n2. Therapist\n"));
		}

		[Test]
		public void MenuDoctorsTest()
		{
			Assert.AreEqual(reg.MenuDoctors(1), String.Format("0. Back up.\n{0}", "1. Michael Jhonson\n2. Anna Nicolson\n"));
		}
	}
}
