using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using My.Lab4.Models;

namespace My.Lab4.DataAccess
{
	public class TimetableRepository:IRepository<TimeTable>
	{
		private TimetableDataContext _dataContext;

		public TimetableRepository(TimetableDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public TimeTable GetItem(int id)
		{
			return _dataContext.TimeTables.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<TimeTable> GetItems()
		{
			return _dataContext.TimeTables.AsEnumerable<TimeTable>();
		}

		public void Add(TimeTable item)
		{
			_dataContext.TimeTables.InsertOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(TimeTable item)
		{
			Remove(item.id);
		}

		public void Remove(int id)
		{
			TimeTable item = GetItem(id);
			if (item != null)
			{
				_dataContext.TimeTables.DeleteOnSubmit(item);
				_dataContext.SubmitChanges();
			}
		}

		public void Update(TimeTable item)
		{
			TimeTable itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.id_group = item.id_group;
				itemUpdate.id_subj_teach = item.id_subj_teach;
				itemUpdate.DateTime = item.DateTime;
				_dataContext.SubmitChanges();
			}
		}
	}
}
