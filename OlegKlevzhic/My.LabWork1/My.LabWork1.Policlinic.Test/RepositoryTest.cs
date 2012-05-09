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
		[Test]
		public void SaveTest()
		{
			IRepository<Pacient> rep = new Repository<Pacient>();
			int i = rep.GetAll().Count();
			rep.Save(new Pacient() { FirstName = "2", LastName = "3" });
			Assert.AreEqual(i + 1, rep.GetAll().Count());
		}

		[Test]
		public void GetAllTest()
		{
			IRepository<Specialization> rep = new Repository<Specialization>();
			Assert.AreEqual(rep.GetAll().Count(), new List<Specialization>() { new Specialization(1, "Surgeon"), new Specialization(2, "Therapist") }.Count);
		}

		[Test]
		public void DeleteTest()
		{
			IRepository<Pacient> rep = new Repository<Pacient>();
			int i = rep.GetAll().Count();
			rep.Remove(new Pacient() { FirstName = "2", LastName = "3" });
			Assert.AreEqual(rep.GetAll().Count(), i);
		}
	}
}
