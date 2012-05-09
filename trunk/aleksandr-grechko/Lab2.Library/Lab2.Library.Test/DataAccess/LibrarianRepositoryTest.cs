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
	public class LibrarianRepositoryTest<T>
		where T : IRepositoryFactory, new()
	{
		IRepositoryFactory repositoryFactory;
		LibrarianRepository librarianRepository;
		LibraryDepartmentRepository libraryDepartmentRepository;
		Librarian librarian1, librarian2;
		LibraryDepartment department;
		int countItems;

		public LibrarianRepositoryTest()
		{
			repositoryFactory = new T();
			libraryDepartmentRepository = repositoryFactory.CreateLibraryDepartmentRepository();
			librarianRepository = repositoryFactory.CreateLibrarianRepository(libraryDepartmentRepository);
			countItems = librarianRepository.GetItems().Count();
		}

		[SetUp]
		public void Init()
		{
			department = new LibraryDepartment("Абонемент", true);
			librarian1 = new Librarian("John Doe", department);
			librarian2 = new Librarian("Alex Pupkin", department);
		}

		[TearDown]
		public void ClearRepository()
		{
			librarianRepository.Remove(librarian2);
			librarianRepository.Remove(librarian1);
			libraryDepartmentRepository.Remove(department);
		}


		[Test]
		public void SaveTest()
		{
			librarianRepository.Save(librarian1);
			librarianRepository.Save(librarian2);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems + 2);
			librarianRepository.Save(librarian2);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems + 2);
		}

		[Test]
		public void RemoveTest()
		{
			librarianRepository.Save(librarian1);
			librarianRepository.Save(librarian2);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems + 2);
			librarianRepository.Remove(librarian2);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems + 1);
			librarianRepository.Remove(librarian1.Id);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems);
			librarianRepository.Remove(librarian1);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems);
		}


		[Test]
		public void GetItemTest()
		{
			librarianRepository.Save(librarian1);
			librarianRepository.Save(librarian2);
			Librarian r = librarianRepository.GetItem(librarian1.Id);
			Assert.IsNotNull(r);
			Assert.AreEqual(r, librarian1);
			Assert.IsNotNull(librarianRepository.GetItem(librarian2.Id));
		}

		[Test]
		public void UpdateTest()
		{
			librarianRepository.Save(librarian1);
			Assert.AreEqual(librarian1, librarianRepository.GetItem(librarian1.Id));
			librarian1.FullName = "New Name";
			librarianRepository.Save(librarian1);
			Assert.AreEqual(librarian1, librarianRepository.GetItem(librarian1.Id));
		}

		[Test]
		public void GetItemsTest()
		{
			librarianRepository.Save(librarian1);
			librarianRepository.Save(librarian2);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems + 2);
			IEnumerable<Librarian> librarians = librarianRepository.GetItems();
			Assert.IsNotNull(librarians.SingleOrDefault(r => r.Id == librarian1.Id));
			Assert.IsNotNull(librarians.SingleOrDefault(r => r.Id == librarian2.Id));
			librarianRepository.Remove(librarian1);
			librarianRepository.Remove(librarian2);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems);
		}

	}
}
