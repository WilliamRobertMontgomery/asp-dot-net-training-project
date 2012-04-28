using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab1.Library.Entities;
using Lab1.Library.DataAccess;

namespace Lab1.Library.Test.DataAccess
{
	[TestFixture(typeof(ObjectRepositoryFactory))]
    [TestFixture(typeof(TextRepositoryFactory))]
	public class LibraryDepartmentRepositoryTest<T>
		where T : IRepositoryFactory, new()
	{
		IRepositoryFactory repositoryFactory;
		LibraryDepartmentRepository libraryDepartmentRepository;
		LibraryDepartment department1, department2;
		int countItems;

		public LibraryDepartmentRepositoryTest()
		{
			repositoryFactory = new T();
			libraryDepartmentRepository = repositoryFactory.CreateLibraryDepartmentRepository();
			countItems = libraryDepartmentRepository.GetItems().Count();
			department1 = new LibraryDepartment("Абонемент", true);
			department2 = new LibraryDepartment("Читальный зал", false);
		}

		[Test]
		public void SaveTest()
		{
			libraryDepartmentRepository.Save(department1);
			Assert.AreEqual(libraryDepartmentRepository.GetItems().Count(), countItems + 1);
			libraryDepartmentRepository.Save(department2);
			Assert.AreEqual(libraryDepartmentRepository.GetItems().Count(), countItems + 2);
			libraryDepartmentRepository.Save(department2);
			Assert.AreEqual(libraryDepartmentRepository.GetItems().Count(), countItems + 2);
			libraryDepartmentRepository.Remove(department2);
			libraryDepartmentRepository.Remove(department1);
		}

		[Test]
		public void RemoveTest()
		{
			libraryDepartmentRepository.Save(department1);
			libraryDepartmentRepository.Save(department2);
			Assert.AreEqual(libraryDepartmentRepository.GetItems().Count(), countItems + 2);
			libraryDepartmentRepository.Remove(department2);
			Assert.AreEqual(libraryDepartmentRepository.GetItems().Count(), countItems + 1);
			libraryDepartmentRepository.Remove(department1.Id);
			Assert.AreEqual(libraryDepartmentRepository.GetItems().Count(), countItems);
			libraryDepartmentRepository.Remove(department1);
			Assert.AreEqual(libraryDepartmentRepository.GetItems().Count(), countItems);
		}


		[Test]
		public void GetItemTest()
		{
			libraryDepartmentRepository.Save(department1);
			libraryDepartmentRepository.Save(department2);
			LibraryDepartment r = libraryDepartmentRepository.GetItem(department1.Id);
			Assert.IsNotNull(r);
			Assert.AreEqual(r, department1);
			Assert.IsNotNull(libraryDepartmentRepository.GetItem(department2.Id));
			Assert.IsNull(libraryDepartmentRepository.GetItem(new LibraryDepartment("", false).Id));
			libraryDepartmentRepository.Remove(department1);
			libraryDepartmentRepository.Remove(department2);
		}

		[Test]
		public void UpdateTest()
		{
			libraryDepartmentRepository.Save(department1);
			Assert.AreEqual(department1, libraryDepartmentRepository.GetItem(department1.Id));
			LibraryDepartment r = new LibraryDepartment(department1.Id, department1.Name, false);
			libraryDepartmentRepository.Save(r);
			Assert.AreEqual(r, libraryDepartmentRepository.GetItem(r.Id));
			Assert.AreEqual(libraryDepartmentRepository.GetItem(department1.Id), libraryDepartmentRepository.GetItem(r.Id));
			libraryDepartmentRepository.Remove(r);
		}

		[Test]
		public void GetItemsTest()
		{
			libraryDepartmentRepository.Save(department1);
			libraryDepartmentRepository.Save(department2);
			Assert.AreEqual(libraryDepartmentRepository.GetItems().Count(), countItems + 2);
			IEnumerable<LibraryDepartment> libraryDepartments = libraryDepartmentRepository.GetItems();
			Assert.IsNotNull(libraryDepartments.SingleOrDefault(r => r.Id == department1.Id));
			Assert.IsNotNull(libraryDepartments.SingleOrDefault(r => r.Id == department2.Id));
			libraryDepartmentRepository.Remove(department1);
			libraryDepartmentRepository.Remove(department2);
			Assert.AreEqual(libraryDepartmentRepository.GetItems().Count(), countItems);
		}

	}
}
