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
			department = new LibraryDepartment("Абонемент", true);
			librarian1 = new Librarian("John Doe", department);
			librarian2 = new Librarian("Alex Pupkin", department);
		}

		[TestFixtureTearDown]
		public void ClearRepository()
		{
			libraryDepartmentRepository.Remove(department);
		}


		[Test]
		public void SaveTest()
		{
			librarianRepository.Save(librarian1);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems + 1);
			librarianRepository.Save(librarian2);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems + 2);
			librarianRepository.Save(librarian2);
			Assert.AreEqual(librarianRepository.GetItems().Count(), countItems + 2);
			librarianRepository.Remove(librarian2);
			librarianRepository.Remove(librarian1);
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
			Assert.IsNull(librarianRepository.GetItem(new Librarian("", department).Id));
			librarianRepository.Remove(librarian1);
			librarianRepository.Remove(librarian2);
		}

		[Test]
		public void UpdateTest()
		{
			librarianRepository.Save(librarian1);
			Assert.AreEqual(librarian1, librarianRepository.GetItem(librarian1.Id));
			Librarian r = new Librarian(librarian1.Id, "New Name", librarian1.Department);
			librarianRepository.Save(r);
			Assert.AreEqual(r, librarianRepository.GetItem(r.Id));
			Assert.AreEqual(librarianRepository.GetItem(librarian1.Id), librarianRepository.GetItem(r.Id));
			librarianRepository.Remove(r);
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
