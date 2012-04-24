using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab1.Library.Entities;
using Lab1.Library.BusinessLogic;
using Lab1.Library.DataAccess;

namespace Lab1.Library.Test.BusinessLogic
{
	[TestFixture]
	public class LibraryClassTest
	{
		LibraryClass library;

		Repository repository;

		Reader reader;
		Book book;
		Librarian librarian;
		LibraryDepartment department;

		public LibraryClassTest()
		{
			repository = new Repository(new ObjectRepositoryFactory());

			reader = new Reader("Иван Иванов", "Брест");
			repository.ReaderRepository.Save(reader);
			department = new LibraryDepartment("Абонемент", true);
			repository.LibraryDepartmentRepository.Save(department);
			librarian = new Librarian("Мария Иванова", department);
			repository.LibrarianRepository.Save(librarian);
			book = new Book("Михаил Фленов", "Библия C#", 2002, department);
			repository.BookRepository.Save(book);

			library = new LibraryClass(repository);
		}

		[Test]
		public void GetReaderTest()
		{
			Assert.IsNull(library.GetReader("Иван Петров"));
			Reader reader = library.GetReader("Иван Иванов");
			Assert.AreEqual(this.reader, reader);
		}

		[Test]
		public void AddReaderTest()
		{
			Assert.IsNull(library.GetReader("Петр Петров"));
			library.AddReader("Петр Петров", "Минск");
			Reader reader = library.GetReader("Петр Петров");
			Assert.IsNotNull(reader);
			Assert.AreEqual("Петр Петров", reader.FullName);
			Assert.AreEqual("Минск", reader.Address);
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
			Book book2 = new Book("Бен Ватсон", "С# 4.0 на примерах", 2000, department);
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
