using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab4.Models;

namespace My.Lab4.DataAccess
{
	public class SubjectRepository: IRepository<Subject>
	{
		private TimetableDataContext _dataContext;

		public SubjectRepository(TimetableDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public Subject GetItem(int id)
		{
			return _dataContext.Subjects.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Subject> GetItems()
		{
			return _dataContext.Subjects.AsEnumerable<Subject>();
		}

		public void Add(Subject item)
		{
			_dataContext.Subjects.InsertOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(Subject item)
		{
			_dataContext.Subjects.DeleteOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Subject temp = _dataContext.Subjects.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				_dataContext.Subjects.DeleteOnSubmit(temp);
				_dataContext.SubmitChanges();
			}
		}

		public void Update(Subject item)
		{
			Subject itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.name = item.name;
				_dataContext.SubmitChanges();
			}
		}
	}
}
