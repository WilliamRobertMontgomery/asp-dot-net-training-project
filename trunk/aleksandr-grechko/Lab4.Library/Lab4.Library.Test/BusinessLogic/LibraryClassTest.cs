using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab4.Library.Models;
using Lab4.Library.BusinessLogic;
using Lab4.Library.DataAccess;

namespace Lab4.Library.Test.BusinessLogic
{
	[TestFixture]
	public class LibraryClassTest
	{
		LibraryClass library;

		Repository repository;

		Reader reader;
		Book book, book2;
		Librarian librarian;
		LibraryDepartment department;

		public LibraryClassTest()
		{
			repository = new Repository(new MSSQLRepositoryFactory());

			reader = new Reader("First Reader", "Brest");
			repository.ReaderRepository.Save(reader);
			department = new LibraryDepartment("Abonement", true);
			repository.LibraryDepartmentRepository.Save(department);
			librarian = new Librarian("First Librarian ", department);
			repository.LibrarianRepository.Save(librarian);
			book = new Book("First Author", "Title", 2002, department);
			repository.BookRepository.Save(book);
			book2 = new Book("Second Author", "Title", 2000, department);
			repository.BookRepository.Save(book2);

			library = new LibraryClass(repository);
		}

		[TestFixtureTearDown]
		public void ClearRepository()
		{
			foreach (Order order in repository.OrderRepository.GetOrdersByReader(reader, true))
			{
				repository.OrderRepository.Remove(order);
			}
			foreach (Order order in repository.OrderRepository.GetOrdersByReader(reader, false))
			{
				repository.OrderRepository.Remove(order);
			}
			repository.BookRepository.Remove(book);
			repository.BookRepository.Remove(book2);
			repository.LibrarianRepository.Remove(librarian);
			repository.ReaderRepository.Remove(reader);
			repository.LibraryDepartmentRepository.Remove(department);
		}

		[Test]
		public void GetReaderTest()
		{
			Assert.IsNull(library.GetReader("Second Reader"));
			Reader reader2 = library.GetReader("First Reader");
			Assert.AreEqual(reader, reader2);
		}

		[Test]
		public void AddReaderTest()
		{
			Assert.IsNull(library.GetReader("Second Reader"));
			library.AddReader("Second Reader", "Minsk");
			Reader reader2 = library.GetReader("Second Reader");
			Assert.IsNotNull(reader2);
			Assert.AreEqual("Second Reader", reader2.FullName);
			Assert.AreEqual("Minsk", reader2.Address);
			repository.ReaderRepository.Remove(reader2);
		}

		[Test]
		public void AuthorizationReaderTest()
		{
			Assert.IsTrue(library.AuthorizationReader(reader));
			Assert.IsFalse(library.AuthorizationReader(reader));
			library.ExitReader(reader);
		}

		[Test]
		public void ExitReaderTest()
		{
			Assert.IsTrue(library.AuthorizationReader(reader));
			library.ExitReader(reader);
			Assert.IsTrue(library.AuthorizationReader(reader));
			library.ExitReader(reader);
		}

		[Test]
		public void OrderBookTest()
		{
			Assert.IsFalse(library.OrderBook(book, reader));
			library.AuthorizationReader(reader);
			Assert.IsTrue(library.OrderBook(book, reader));
			Assert.IsFalse(library.OrderBook(book, reader));
			library.ReturnBook(book);
			library.ExitReader(reader);
		}

		[Test]
		public void ReturnBookTest()
		{
			library.AuthorizationReader(reader);
			Assert.IsTrue(library.OrderBook(book, reader));
			library.ReturnBook(book);
			Assert.IsTrue(library.OrderBook(book, reader));
			library.ReturnBook(book);
			library.ExitReader(reader);
		}

		[Test]
		public void GetBooksOrderedByReaderTest()
		{
			library.AuthorizationReader(reader);
			library.OrderBook(book, reader);
			IEnumerable<Book> books = library.GetBooksOrderedByReader(reader);
			Assert.AreEqual(1, books.Count());
			library.OrderBook(book2, reader);
			books = library.GetBooksOrderedByReader(reader);
			Assert.AreEqual(2, books.Count());
			Assert.IsTrue(books.Contains(book));
			Assert.IsTrue(books.Contains(book2));
			library.ReturnBook(book);
			library.ReturnBook(book2);
			library.ExitReader(reader);
		}
	}
}
