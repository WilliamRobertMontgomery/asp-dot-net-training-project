using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab2.Library.DataModel;
using Lab2.Library.BusinessLogic;
using Lab2.Library.DataAccess;

namespace Lab2.Library.Test.BusinessLogic
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

			reader = new Reader("Иван Иванов", "Брест");
			repository.ReaderRepository.Save(reader);
			department = new LibraryDepartment("Абонемент", true);
			repository.LibraryDepartmentRepository.Save(department);
			librarian = new Librarian("Мария Иванова", department);
			repository.LibrarianRepository.Save(librarian);
			book = new Book("Михаил Фленов", "Библия C#", 2002, department);
			repository.BookRepository.Save(book);
			book2 = new Book("Бен Ватсон", "С# 4.0 на примерах", 2000, department);
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
			Assert.IsNull(library.GetReader("Иван Петров"));
			Reader reader2 = library.GetReader("Иван Иванов");
			Assert.AreEqual(reader, reader2);
		}

		[Test]
		public void AddReaderTest()
		{
			Assert.IsNull(library.GetReader("Петр Петров"));
			library.AddReader("Петр Петров", "Минск");
			Reader reader2 = library.GetReader("Петр Петров");
			Assert.IsNotNull(reader2);
			Assert.AreEqual("Петр Петров", reader2.FullName);
			Assert.AreEqual("Минск", reader2.Address);
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
