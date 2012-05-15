using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab4.Models;

namespace My.Lab4.DataAccess
{
	public class Subj_TeachRepository:IRepository<Subj_Teach>
	{
		private TimetableDataContext _dataContext;

		public Subj_TeachRepository(TimetableDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public Subj_Teach GetItem(int id)
		{
			return _dataContext.Subj_Teaches.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Subj_Teach> GetItems()
		{
			return _dataContext.Subj_Teaches.AsEnumerable<Subj_Teach>();
		}

		public void Add(Subj_Teach item)
		{
			_dataContext.Subj_Teaches.InsertOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(Subj_Teach item)
		{
			_dataContext.Subj_Teaches.DeleteOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Subj_Teach temp = _dataContext.Subj_Teaches.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				_dataContext.Subj_Teaches.DeleteOnSubmit(temp);
				_dataContext.SubmitChanges();
			}
		}

		public void Update(Subj_Teach item)
		{
			Subj_Teach itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.id_subject = item.id_subject;
				itemUpdate.id_teacher = item.id_teacher;
				_dataContext.SubmitChanges();
			}
		}
	}
}
