using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.IO;
using System.Xml.Linq;

namespace Lab1.Library.DataAccess
{
	public class ReaderXMLRepository : ReaderRepository
	{

		private const string FileName = @"XML\Readers.xml";

		private XDocument document;

        public ReaderXMLRepository()
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
					new XElement("Readers", null));
				document.Save(FileName);
			}
        }

		public override Reader GetItem(Guid id)
		{
			XElement element = document.Root.Elements("Reader").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			return element != null ? CreateItem(element) : null;
		}

		public override IEnumerable<Reader> GetItems()
		{
			return document.Root.Elements("Reader").Select(e => CreateItem(e));
		}

		public override void Save(Reader item)
		{
			XElement element = document.Root.Elements("Reader").SingleOrDefault(e => e.Attribute("id").Value == item.Id.ToString());
			if (element != null)
			{
				element.Element("FullName").Value = item.FullName;
				element.Element("Address").Value = item.Address;
			}
			else
			{
				document.Root.Add(
					new XElement("Reader",
						new XAttribute("id", item.Id),
						new XElement("FullName", item.FullName),
						new XElement("Address", item.Address)));
			}
			document.Save(FileName);
		}

		public override void Remove(Reader item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			XElement element = document.Root.Elements("Reader").SingleOrDefault(e => e.Attribute("id").Value == id.ToString());
			if (element != null)
			{
				element.Remove();
				document.Save(FileName);
			}
		}

		public override IEnumerable<Reader> GetReadersByName(string fullName, bool matchWholeString)
		{
			return document.Root.Elements("Reader")
				.Where(e => matchWholeString ? e.Element("FullName").Value == fullName : e.Element("FullName").Value.Contains(fullName))
				.Select(e => CreateItem(e));
		}

		private Reader CreateItem(XElement e)
		{
			return new Reader(new Guid(e.Attribute("id").Value), e.Element("FullName").Value, e.Element("Address").Value);
		}
	}
}
