using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab4.Library.Models;
using Lab4.Library.DataAccess;

namespace Lab4.Library.Test.DataAccess
{
	[TestFixture(typeof(MSSQLRepositoryFactory))]
	public class BookRepositoryTest<T> 
		where T : IRepositoryFactory, new()
	{
		IRepositoryFactory repositoryFactory;
		BookRepository bookRepository;
		LibraryDepartmentRepository libraryDepartmentRepository;
		Book book1, book2;
		LibraryDepartment department;
		int countItems;

		public BookRepositoryTest()
		{
			repositoryFactory = new T();
			libraryDepartmentRepository = repositoryFactory.CreateLibraryDepartmentRepository();
			bookRepository = repositoryFactory.CreateBookRepository(libraryDepartmentRepository);
			countItems = bookRepository.GetItems().Count();
		}

		[SetUp]
		public void Init()
		{
			department = new LibraryDepartment("Абонемент", true);
			book1 = new Book("John Doe", "Book", 2000, department);
			book2 = new Book("Alex Pupkin", "Book2", 2001, department);
		}

		[TearDown]
		public void ClearRepository()
		{
			bookRepository.Remove(book2);
			bookRepository.Remove(book1);
			libraryDepartmentRepository.Remove(department);
		}

		[Test]
		public void SaveTest()
		{
			bookRepository.Save(book1);
			bookRepository.Save(book2);
			Assert.AreEqual(countItems + 2, bookRepository.GetItems().Count());
			bookRepository.Save(book2);
			Assert.AreEqual(countItems + 2, bookRepository.GetItems().Count());
		}

		[Test]
		public void RemoveTest()
		{
			bookRepository.Save(book1);
			bookRepository.Save(book2);
			Assert.AreEqual(bookRepository.GetItems().Count(), countItems + 2);
			bookRepository.Remove(book2);
			Assert.AreEqual(bookRepository.GetItems().Count(), countItems + 1);
			bookRepository.Remove(book1.Id);
			Assert.AreEqual(bookRepository.GetItems().Count(), countItems);
			bookRepository.Remove(book1);
			Assert.AreEqual(bookRepository.GetItems().Count(), countItems);
		}


		[Test]
		public void GetItemTest()
		{
			bookRepository.Save(book1);
			bookRepository.Save(book2);
			Book r = bookRepository.GetItem(book1.Id);
			Assert.IsNotNull(r);
			Assert.AreEqual(r, book1);
			Assert.IsNotNull(bookRepository.GetItem(book2.Id));
		}

		[Test]
		public void UpdateTest()
		{
			bookRepository.Save(book1);
			Assert.AreEqual(book1, bookRepository.GetItem(book1.Id));
			book1.Author = "New Author";
			bookRepository.Save(book1);
			Assert.AreEqual(book1, bookRepository.GetItem(book1.Id));
		}

		[Test]
		public void GetItemsTest()
		{
			bookRepository.Save(book1);
			bookRepository.Save(book2);
			Assert.AreEqual(bookRepository.GetItems().Count(), countItems + 2);
			IEnumerable<Book> books = bookRepository.GetItems();
			Assert.IsNotNull(books.SingleOrDefault(r => r.Id == book1.Id));
			Assert.IsNotNull(books.SingleOrDefault(r => r.Id == book2.Id));
			bookRepository.Remove(book1);
			bookRepository.Remove(book2);
			Assert.AreEqual(bookRepository.GetItems().Count(), countItems);
		}

		[Test]
		public void GetBooksByAuthorTest()
		{
			bookRepository.Save(book1);
			bookRepository.Save(book2);
			IEnumerable<Book> books = bookRepository.GetBooksByAuthor("John Doe", true);
			Assert.AreEqual(books.Count(), 1);
			Assert.AreEqual(books.First(), book1);
			books = bookRepository.GetBooksByAuthor("n", false);
			Assert.AreEqual(books.Count(), 2);
			Assert.IsNotNull(books.SingleOrDefault(r => r.Id == book1.Id));
			Assert.IsNotNull(books.SingleOrDefault(r => r.Id == book2.Id));
		}

		[Test]
		public void GetBooksByTitleTest()
		{
			bookRepository.Save(book1);
			bookRepository.Save(book2);
			IEnumerable<Book> books = bookRepository.GetBooksByTitle("Book", true);
			Assert.AreEqual(books.Count(), 1);
			Assert.AreEqual(books.First(), book1);
			books = bookRepository.GetBooksByTitle("Book", false);
			Assert.AreEqual(books.Count(), 2);
			Assert.IsNotNull(books.SingleOrDefault(r => r.Id == book1.Id));
			Assert.IsNotNull(books.SingleOrDefault(r => r.Id == book2.Id));
		}
		
		[Test]
		public void GetBooksByDepartmentTest()
		{
			bookRepository.Save(book1);
			bookRepository.Save(book2);
			IEnumerable<Book> books = bookRepository.GetBooksByDepartment(department);
			Assert.AreEqual(books.Count(), 2);
			Assert.IsNotNull(books.SingleOrDefault(r => r.Id == book1.Id));
			Assert.IsNotNull(books.SingleOrDefault(r => r.Id == book2.Id));
			books = bookRepository.GetBooksByDepartment(new LibraryDepartment("", true));
			Assert.AreEqual(books.Count(), 0);
		}
	}
}
