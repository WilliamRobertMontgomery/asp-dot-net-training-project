using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.Xml.Linq;
using System.IO;

namespace Lab1.Library.DataAccess
{
	public class BookXMLRepository : BookRepository
	{

		private const string FileName = @"XML\Books.xml";

		private XDocument document;

		public BookXMLRepository(LibraryDepartmentRepository libraryDepartmentRepository)
		{
			this.libraryDepartmentRepository = libraryDepartmentRepository;

			if (!Directory.GetParent(FileName).Exists) Directory.GetParent(FileName).Create();
			if (File.Exists(FileName))
			{
				document = XDocument.Load(FileName);
			}
			else
			{
				document = new XDocument(
					new XDeclaration("1.0", "utf-8", "yes"),
					new XElement("Books", null));
				document.Save(FileName);
			}

		}

		public override Book GetItem(Guid id)
		{
			XElement element = document.Root.Elements("Book").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			return element != null ? CreateItem(element) : null;
		}

		public override IEnumerable<Book> GetItems()
		{
			return document.Root.Elements("Book").Select(e => CreateItem(e));
		}

		public override void Save(Book item)
		{
			XElement element = document.Root.Elements("Book").SingleOrDefault(e => e.Attribute("id").Value == item.Id.ToString());
			if (element != null)
			{
				element.Element("Author").Value = item.Author;
				element.Element("Title").Value = item.Title;
				element.Element("Year").SetValue(item.Year);
				element.Element("DepartmentId").SetValue(item.Department.Id);
			}
			else
			{
				document.Root.Add(
					new XElement("Book",
						new XAttribute("id", item.Id),
						new XElement("Author", item.Author),
						new XElement("Title", item.Title),
						new XElement("Year", item.Year),
						new XElement("DepartmentId", item.Department.Id)));
			}
			document.Save(FileName);
			libraryDepartmentRepository.Save(item.Department);
		}

		public override void Remove(Book item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			XElement element = document.Root.Elements("Book").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			if (element != null)
			{
				element.Remove();
				document.Save(FileName);
			}
		}

		public override IEnumerable<Book> GetBooksByAuthor(string author, bool matchWholeString)
		{
			return document.Root.Elements("Book")
				.Where(e => matchWholeString ? e.Element("Author").Value == author : e.Element("Author").Value.Contains(author))
				.Select(e => CreateItem(e));
		}

		public override IEnumerable<Book> GetBooksByTitle(string title, bool matchWholeString)
		{
			return document.Root.Elements("Book")
				.Where(e => matchWholeString ? e.Element("Title").Value == title : e.Element("Title").Value.Contains(title))
				.Select(e => CreateItem(e));
		}

		public override IEnumerable<Book> GetBooksByDepartment(LibraryDepartment department)
		{
			return document.Root.Elements("Book")
				.Where(e => e.Element("DepartmentId").Value == department.Id.ToString())
				.Select(e => CreateItem(e));
		}

		private Book CreateItem(XElement e)
		{
			LibraryDepartment department = libraryDepartmentRepository.GetItem(new Guid(e.Element("DepartmentId").Value));
			return new Book(new Guid(e.Attribute("id").Value), e.Element("Author").Value, e.Element("Title").Value, Convert.ToInt32(e.Element("Year").Value), department);
		}
	
	}
}
