using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab2.Library.DataModel;
using Lab2.Library.DataAccess;

namespace Lab2.Library.Test.DataAccess
{
	[TestFixture(typeof(MSSQLRepositoryFactory))]
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
		}
			
		[SetUp]
		public void Init()
		{
			department1 = new LibraryDepartment("Абонемент", true);
			department2 = new LibraryDepartment("Читальный зал", false);
		}

		[TearDown]
		public void ClearRepository()
		{
			libraryDepartmentRepository.Remove(department1);
			libraryDepartmentRepository.Remove(department2);
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
		}

		[Test]
		public void UpdateTest()
		{
			libraryDepartmentRepository.Save(department1);
			Assert.AreEqual(department1, libraryDepartmentRepository.GetItem(department1.Id));
			department1.IsAbonement = false;
			libraryDepartmentRepository.Save(department1);
			Assert.AreEqual(department1, libraryDepartmentRepository.GetItem(department1.Id));
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
