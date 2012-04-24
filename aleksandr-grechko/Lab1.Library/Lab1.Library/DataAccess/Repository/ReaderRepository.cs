using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;

namespace Lab1.Library.DataAccess
{
	public abstract class ReaderRepository : IRepository<Reader>
	{
		public abstract Reader GetItem(Guid id);

		public abstract IEnumerable<Reader> GetItems();

		public abstract void Save(Reader item);

		public abstract void Remove(Reader item);

		public abstract void Remove(Guid id);

		public abstract IEnumerable<Reader> GetReadersByName(string fullName, bool matchWholeString);
	}
}
