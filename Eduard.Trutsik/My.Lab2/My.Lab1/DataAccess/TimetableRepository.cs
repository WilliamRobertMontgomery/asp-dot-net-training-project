using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using My.Lab1.Entities;

namespace My.Lab1.DataAccess
{
	public class TimetableRepository:IRepository<TimeTable>
	{
		private TimetableDataContext timetableDataContext;

		public TimetableRepository()
		{
			timetableDataContext = new TimetableDataContext();
		}

		public TimeTable GetItem(int id)
		{
			return timetableDataContext.TimeTables.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<TimeTable> GetItems()
		{
			return timetableDataContext.TimeTables.AsEnumerable<TimeTable>();
		}

		public void Add(TimeTable item)
		{
			timetableDataContext.TimeTables.InsertOnSubmit(item);
			timetableDataContext.SubmitChanges();
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
				timetableDataContext.TimeTables.DeleteOnSubmit(item);
				timetableDataContext.SubmitChanges();
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
				timetableDataContext.SubmitChanges();
			}
		}
	}
}
