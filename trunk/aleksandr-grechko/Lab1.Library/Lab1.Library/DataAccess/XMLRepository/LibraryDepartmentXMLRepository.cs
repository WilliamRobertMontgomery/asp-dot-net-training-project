using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.Xml.Linq;
using System.IO;

namespace Lab1.Library.DataAccess
{
	public class LibraryDepartmentXMLRepository : LibraryDepartmentRepository
	{
		private const string FileName = @"XML\Departments.xml";

		private XDocument document;

		public LibraryDepartmentXMLRepository()
        {
            if (!Directory.GetParent(FileName).Exists) Directory.GetParent(FileName).Create();
			if (File.Exists(FileName))
			{
				document = XDocument.Load(FileName);
			}
			else
			{
				document = new XDocument(
					new XDeclaration("1.0", "utf-8", "yes"),
					new XElement("Departments", null));
				document.Save(FileName);
			}
        }

		public override LibraryDepartment GetItem(Guid id)
		{
			XElement element = document.Root.Elements("Department").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			return element != null ? CreateItem(element) : null;
		}

		public override IEnumerable<LibraryDepartment> GetItems()
		{
			return document.Root.Elements("Department").Select(e => CreateItem(e));
		}

		public override void Save(LibraryDepartment item)
		{
			XElement element = document.Root.Elements("Department").SingleOrDefault(e => e.Attribute("id").Value == item.Id.ToString());
			if (element != null)
			{
				element.Element("Name").Value = item.Name;
				element.Element("IsAbonement").Value = item.IsAbonement.ToString();
			}
			else
			{
				document.Root.Add(
					new XElement("Department",
						new XAttribute("id", item.Id),
						new XElement("Name", item.Name),
						new XElement("IsAbonement", item.IsAbonement)));
			}
			document.Save(FileName);
		}

		public override void Remove(LibraryDepartment item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			XElement element = document.Root.Elements("Department").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			if (element != null)
			{
				element.Remove();
				document.Save(FileName);
			}
		}

		private LibraryDepartment CreateItem(XElement e)
		{
			return new LibraryDepartment(new Guid(e.Attribute("id").Value), e.Element("Name").Value, Convert.ToBoolean(e.Element("IsAbonement").Value));
		}
	}
}
