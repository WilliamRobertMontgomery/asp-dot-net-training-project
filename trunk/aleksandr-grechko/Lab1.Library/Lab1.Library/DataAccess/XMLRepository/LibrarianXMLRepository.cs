using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.Xml.Linq;
using System.IO;

namespace Lab1.Library.DataAccess
{
	public class LibrarianXMLRepository : LibrarianRepository
	{

		private const string FileName = @"XML\Librarians.xml";

		private XDocument document;

		public LibrarianXMLRepository(LibraryDepartmentRepository libraryDepartmentRepository)
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
					new XElement("Librarians", null));
				document.Save(FileName);
			}

		}

		public override Librarian GetItem(Guid id)
		{
			XElement element = document.Root.Elements("Librarian").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			return element != null ? CreateItem(element) : null;
		}

		public override IEnumerable<Librarian> GetItems()
		{
			return document.Root.Elements("Librarian").Select(e => CreateItem(e));
		}

		public override void Save(Librarian item)
		{
			XElement element = document.Root.Elements("Librarian").SingleOrDefault(e => e.Attribute("id").Value == item.Id.ToString());
			if (element != null)
			{
				element.Element("FullName").Value = item.FullName;
				element.Element("DepartmentId").SetValue(item.Department.Id);
			}
			else
			{
				document.Root.Add(
					new XElement("Librarian",
						new XAttribute("id", item.Id),
						new XElement("FullName", item.FullName),
						new XElement("DepartmentId", item.Department.Id)));
			}
			document.Save(FileName);
			libraryDepartmentRepository.Save(item.Department);
		}

		public override void Remove(Librarian item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			XElement element = document.Root.Elements("Librarian").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			if (element != null)
			{
				element.Remove();
				document.Save(FileName);
			}
		}

		private Librarian CreateItem(XElement e)
		{
			LibraryDepartment department = libraryDepartmentRepository.GetItem(new Guid(e.Element("DepartmentId").Value));
			return new Librarian(new Guid(e.Attribute("id").Value), e.Element("FullName").Value, department);
		}
	}
}
