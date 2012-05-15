using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using My.Lab4.Models;

namespace My.Lab4.DataAccess
{
	public class TeacherRepository : IRepository<Teacher>
	{
		private TimetableDataContext _dataContext;

		public TeacherRepository(TimetableDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public Teacher GetItem(int id)
		{
			return _dataContext.Teachers.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Teacher> GetItems()
		{
			return _dataContext.Teachers.AsEnumerable<Teacher>();
		}

		public void Add(Teacher item)
		{
			_dataContext.Teachers.InsertOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(Teacher item)
		{
			_dataContext.Teachers.DeleteOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Teacher temp = _dataContext.Teachers.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				_dataContext.Teachers.DeleteOnSubmit(temp);
				_dataContext.SubmitChanges();
			}			
		}

		public void Update(Teacher item)
		{
			Teacher itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.name = item.name;
				_dataContext.SubmitChanges();
			}
		}
	}
}
