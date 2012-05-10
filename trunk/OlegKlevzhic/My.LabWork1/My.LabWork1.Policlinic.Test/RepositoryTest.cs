using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using My.LabWork1.Policlinic.DataAccess;
using My.LabWork1.Policlinic.Entities;

namespace My.LabWork1.Policlinic.Test
{
	[TestFixture]
	class RepositoryTest
	{
		private static string path = @"e:\#Worckspace\#Training\OlegKlevzhic\My.LabWork1\My.LabWork1.Policlinic.Test\Data\";

		[Test]
		public void AddTest()
		{
			IRepository<Pacient> rep = new Repository<Pacient>(path);
			int i = rep.GetAll().Count();
			rep.Save(new Pacient() { Id = 10, FirstName = "2", LastName = "3" });
			Assert.AreEqual(i + 1, rep.GetAll().Count());
		}

		[Test]
		public void GetAllTest()
		{
			IRepository<Specialization> rep = new Repository<Specialization>(path);
			Assert.AreEqual(rep.GetAll().Count(), new List<Specialization>() { new Specialization(1, "Surgeon"), new Specialization(2, "Therapist") }.Count);
		}

		[Test]
		public void DeleteTest()
		{
			IRepository<Pacient> rep = new Repository<Pacient>(path);
			int i = rep.GetAll().Count();
			rep.Remove(10);
			if (i > 0)
			{
				i--;
			}
			else
			{
				i = 0;
			}
			Assert.AreEqual(rep.GetAll().Count(), i);
		}
	}
}
