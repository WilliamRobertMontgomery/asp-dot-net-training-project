using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.Xml.Linq;
using System.IO;

namespace Lab1.Library.DataAccess
{
	public class OrderXMLRepository : OrderRepository
	{

		private const string FileName = @"XML\Orders.xml";

		private XDocument document;

		public OrderXMLRepository(ReaderRepository readerRepository, BookRepository BookRepository, 
			LibraryDepartmentRepository libraryDepartmentRepository, LibrarianRepository librarianRepository)
		{
			this.readerRepository = readerRepository;
			this.bookRepository = BookRepository;
			this.libraryDepartmentRepository = libraryDepartmentRepository;
			this.librarianRepository = librarianRepository;

			if (!Directory.GetParent(FileName).Exists) Directory.GetParent(FileName).Create();
			if (File.Exists(FileName))
			{
				document = XDocument.Load(FileName);
			}
			else
			{
				document = new XDocument(
					new XDeclaration("1.0", "utf-8", "yes"),
					new XElement("Orders", null));
				document.Save(FileName);
			}
		}	
		
		public override Order GetItem(Guid id)
		{
			XElement element = document.Root.Elements("Order").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			return element != null ? CreateItem(element) : null;
		}

		public override IEnumerable<Order> GetItems()
		{
			return document.Root.Elements("Order").Select(e => CreateItem(e));
		}

		public override void Save(Order item)
		{
			XElement element = document.Root.Elements("Order").SingleOrDefault(e => e.Attribute("id").Value == item.Id.ToString());
			if (element != null)
			{
				element.Element("ReaderId").SetValue(item.Reader.Id);
				element.Element("BookId").SetValue(item.Book.Id);
				element.Element("DepartmentId").SetValue(item.Department.Id);
				element.Element("TimeGetBook").SetValue(item.TimeGetBook);
				element.Element("LibrarianOpenOrderId").SetValue(item.LibrarianOpenOrder != null ? item.LibrarianOpenOrder.Id : Guid.Empty);
				element.Element("TimeReturnBook").SetValue(item.TimeReturnBook);
				element.Element("LibrarianClosedOrderId").SetValue(item.LibrarianClosedOrder != null ? item.LibrarianClosedOrder.Id : Guid.Empty);
				element.Element("Closed").SetValue(item.Closed);
			}
			else
			{
				document.Root.Add(
					new XElement("Order",
						new XAttribute("id", item.Id),
						new XElement("ReaderId", item.Reader.Id),
						new XElement("BookId", item.Book.Id),
						new XElement("DepartmentId", item.Department.Id),
						new XElement("TimeGetBook", item.TimeGetBook),
						new XElement("LibrarianOpenOrderId", item.LibrarianOpenOrder != null ? item.LibrarianOpenOrder.Id : Guid.Empty),
						new XElement("TimeReturnBook", item.TimeReturnBook),
						new XElement("LibrarianClosedOrderId", item.LibrarianClosedOrder != null ? item.LibrarianClosedOrder.Id : Guid.Empty),
						new XElement("Closed", item.Closed)));
			}
			document.Save(FileName);

			readerRepository.Save(item.Reader);
			bookRepository.Save(item.Book);
			if (item.LibrarianOpenOrder != null) librarianRepository.Save(item.LibrarianOpenOrder);
			if (item.LibrarianClosedOrder != null) librarianRepository.Save(item.LibrarianClosedOrder);

		}

		public override void Remove(Order item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			XElement element = document.Root.Elements("Order").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			if (element != null)
			{
				element.Remove();
				document.Save(FileName);
			}
		}

		public override IEnumerable<Order> GetOrdersByBook(Book book, bool closed)
		{
			return document.Root.Elements("Order")
				.Where(e => e.Element("BookId").Value == book.Id.ToString() && Convert.ToBoolean(e.Element("Closed").Value) == closed)
				.Select(e => CreateItem(e));
		}

		public override IEnumerable<Order> GetOrdersByReader(Reader reader, bool closed)
		{
			return document.Root.Elements("Order")
				.Where(e => e.Element("ReaderId").Value == reader.Id.ToString() && Convert.ToBoolean(e.Element("Closed").Value) == closed)
				.Select(e => CreateItem(e));
		}

		public override IEnumerable<Order> GetOpenOrders()
		{
			return document.Root.Elements("Order")
				.Where(e => !Convert.ToBoolean(e.Element("Closed").Value))
				.Select(e => CreateItem(e));
		}

		private Order CreateItem(XElement e)
		{
			Reader reader = readerRepository.GetItem(new Guid(e.Element("ReaderId").Value));
			Book book = bookRepository.GetItem(new Guid(e.Element("BookId").Value));

			Order order = new Order(new Guid(e.Attribute("id").Value), reader, book);

			order.TimeGetBook = Convert.ToDateTime(e.Element("TimeGetBook").Value);
			order.LibrarianOpenOrder = librarianRepository.GetItem(new Guid(e.Element("LibrarianOpenOrderId").Value));
			order.TimeReturnBook = Convert.ToDateTime(e.Element("TimeReturnBook").Value);
			order.LibrarianClosedOrder = librarianRepository.GetItem(new Guid(e.Element("LibrarianClosedOrderId").Value));
			order.Closed = Convert.ToBoolean(e.Element("Closed").Value);

			return order;
		}

	}
}
