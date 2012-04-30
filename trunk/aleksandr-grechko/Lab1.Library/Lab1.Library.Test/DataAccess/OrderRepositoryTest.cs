﻿using System;
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
	[TestFixture(typeof(XMLRepositoryFactory))]
	public class OrderRepositoryTest<T>
		where T : IRepositoryFactory, new()
	{
		IRepositoryFactory repositoryFactory;
		OrderRepository orderRepository;
		BookRepository bookRepository;
		ReaderRepository readerRepository;
		LibrarianRepository librarianRepository;
		LibraryDepartmentRepository libraryDepartmentRepository;

		Order order1, order2;
		LibraryDepartment department;
		Book book;
		Reader reader;
		Librarian librarian;

		int countItems;

		public OrderRepositoryTest()
		{
			repositoryFactory = new T();
			readerRepository = repositoryFactory.CreateReaderRepository();
			libraryDepartmentRepository = repositoryFactory.CreateLibraryDepartmentRepository();
			bookRepository = repositoryFactory.CreateBookRepository(libraryDepartmentRepository);
			librarianRepository = repositoryFactory.CreateLibrarianRepository(libraryDepartmentRepository);

			orderRepository = repositoryFactory.CreateOrderRepository(readerRepository, bookRepository, libraryDepartmentRepository, librarianRepository);

			countItems = orderRepository.GetItems().Count();

			department = new LibraryDepartment("Абонемент", true);
			reader = new Reader("Reader Name", "Reader Address");
			book = new Book("Author", "Title", 2000, department);
			librarian = new Librarian("Name", department);

			order1 = new Order(reader, book);
			order2 = new Order(reader, book) { TimeGetBook = DateTime.Now, LibrarianOpenOrder = librarian};
		}

		[TestFixtureTearDown]
		public void ClearRepository()
		{
			bookRepository.Remove(book);
			readerRepository.Remove(reader);
			librarianRepository.Remove(librarian);
			libraryDepartmentRepository.Remove(department);
		}

		[Test]
		public void SaveTest()
		{
			orderRepository.Save(order1);
			Assert.AreEqual(orderRepository.GetItems().Count(), countItems + 1);
			orderRepository.Save(order2);
			Assert.AreEqual(orderRepository.GetItems().Count(), countItems + 2);
			orderRepository.Save(order2);
			Assert.AreEqual(orderRepository.GetItems().Count(), countItems + 2);
			orderRepository.Remove(order2);
			orderRepository.Remove(order1);
		}

		[Test]
		public void RemoveTest()
		{
			orderRepository.Save(order1);
			orderRepository.Save(order2);
			Assert.AreEqual(orderRepository.GetItems().Count(), countItems + 2);
			orderRepository.Remove(order2);
			Assert.AreEqual(orderRepository.GetItems().Count(), countItems + 1);
			orderRepository.Remove(order1.Id);
			Assert.AreEqual(orderRepository.GetItems().Count(), countItems);
			orderRepository.Remove(order1);
			Assert.AreEqual(orderRepository.GetItems().Count(), countItems);
		}


		[Test]
		public void GetItemTest()
		{
			orderRepository.Save(order1);
			orderRepository.Save(order2);
			Order r = orderRepository.GetItem(order1.Id);
			Assert.IsNotNull(r);
			Assert.AreEqual(r, order1);
			Assert.IsNotNull(orderRepository.GetItem(order2.Id));
			Assert.IsNull(orderRepository.GetItem(new Order(null, null).Id));
			orderRepository.Remove(order1);
			orderRepository.Remove(order2);
		}

		[Test]
		public void UpdateTest()
		{
			orderRepository.Save(order1);
			Assert.AreEqual(order1, orderRepository.GetItem(order1.Id));
			Order r = new Order(order1.Id, order1.Reader, order1.Book) { Closed = true };
			orderRepository.Save(r);
			Assert.AreEqual(r, orderRepository.GetItem(r.Id));
			Assert.AreEqual(orderRepository.GetItem(order1.Id), orderRepository.GetItem(r.Id));
			orderRepository.Remove(r);
		}

		[Test]
		public void GetItemsTest()
		{
			orderRepository.Save(order1);
			orderRepository.Save(order2);
			Assert.AreEqual(orderRepository.GetItems().Count(), countItems + 2);
			IEnumerable<Order> orders = orderRepository.GetItems();
			Assert.IsNotNull(orders.SingleOrDefault(r => r.Id == order1.Id));
			Assert.IsNotNull(orders.SingleOrDefault(r => r.Id == order2.Id));
			orderRepository.Remove(order1);
			orderRepository.Remove(order2);
			Assert.AreEqual(orderRepository.GetItems().Count(), countItems);
		}

		[Test]
		public void GetOrdersByBook()
		{
			orderRepository.Save(order1);
			orderRepository.Save(order2);
			IEnumerable<Order> orders = orderRepository.GetOrdersByBook(book, false);
			Assert.AreEqual(2, orders.Count());
			orders = orderRepository.GetOrdersByBook(book, true);
			Assert.AreEqual(0, orders.Count());
			orderRepository.Remove(order1);
			orderRepository.Remove(order2);
		}

		[Test]
		public void GetOrdersByReader()
		{
			orderRepository.Save(order1);
			orderRepository.Save(order2);
			IEnumerable<Order> orders = orderRepository.GetOrdersByReader(reader, false);
			Assert.AreEqual(2, orders.Count());
			orders = orderRepository.GetOrdersByReader(reader, true);
			Assert.AreEqual(0, orders.Count());
			orderRepository.Remove(order1);
			orderRepository.Remove(order2);
		}

		[Test]
		public void GetOpenOrders()
		{
			orderRepository.Save(order1);
			orderRepository.Save(order2);
			IEnumerable<Order> orders = orderRepository.GetOpenOrders();
			Assert.AreEqual(2, orders.Count());
		}


	}
}
