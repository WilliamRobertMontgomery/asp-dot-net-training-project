using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;

namespace Lab1.Library.DataAccess
{
	public class ReaderObjectRepository : ReaderRepository
	{
		private List<Reader> readers;

		public ReaderObjectRepository()
		{
			readers = new List<Reader>();
		}

		public override Reader GetItem(Guid id)
		{
			return readers.SingleOrDefault(reader => reader.Id == id);
		}

		public override IEnumerable<Reader> GetItems()
		{
			return readers;
		}

		public override void Save(Reader item)
		{
			Reader reader = GetItem(item.Id);
			if (reader != null)
			{
				readers[readers.IndexOf(reader)] = item;
			}
			else
			{
				readers.Add(item);
			}
		}

		public override void Remove(Reader item)
		{
			readers.Remove(item);
		}

		public override void Remove(Guid id)
		{
			readers.Remove(GetItem(id));
		}

		public override IEnumerable<Reader> GetReadersByName(string fullName, bool matchWholeString)
		{
			return readers.Where(reader => matchWholeString ? reader.FullName == fullName : reader.FullName.Contains(fullName));
		}
	}
}
