using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Library.DataModel;

namespace Lab2.Library.DataAccess
{
	public class ReaderMSSQLRepository : ReaderRepository
	{

		private LibraryDataContext context;

		public ReaderMSSQLRepository(LibraryDataContext context)
		{
			this.context = context;
		}

		public override Reader GetItem(Guid id)
		{
			return context.Readers.SingleOrDefault(item => item.Id == id);
		}

		public override IEnumerable<Reader> GetItems()
		{
			return context.Readers.AsEnumerable<Reader>();
		}

		public override void Save(Reader item)
		{
			Reader reader = GetItem(item.Id);
			if (reader == null)
			{
				context.Readers.InsertOnSubmit(item);
			}
			else
			{
				reader.FullName = item.FullName;
				reader.Address = item.Address;
			}
			context.SubmitChanges();
		}

		public override void Remove(Reader item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			Reader reader = GetItem(id);
			if (reader != null)
			{
				context.Readers.DeleteOnSubmit(reader);
				context.SubmitChanges();
			}
		}

		public override IEnumerable<Reader> GetReadersByName(string fullName, bool matchWholeString)
		{
			return context.Readers.Where(reader => matchWholeString ? reader.FullName == fullName : reader.FullName.Contains(fullName));
		}
	}
}
