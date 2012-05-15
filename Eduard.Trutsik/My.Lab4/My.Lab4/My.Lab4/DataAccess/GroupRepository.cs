using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab4.Models;

namespace My.Lab4.DataAccess
{
	public class GroupRepository:IRepository<Group>
	{
		private TimetableDataContext _dataContext;

		public GroupRepository(TimetableDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public Group GetItem(int id)
		{
			return _dataContext.Groups.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Group> GetItems()
		{
			return _dataContext.Groups.AsEnumerable<Group>();
		}

		public void Add(Group item)
		{
			_dataContext.Groups.InsertOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(Group item)
		{
			_dataContext.Groups.DeleteOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Group temp = _dataContext.Groups.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				_dataContext.Groups.DeleteOnSubmit(temp);
				_dataContext.SubmitChanges();
			}
		}

		public void Update(Group item)
		{
			Group itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.name = item.name;
				_dataContext.SubmitChanges();
			}
		}
	}
}
