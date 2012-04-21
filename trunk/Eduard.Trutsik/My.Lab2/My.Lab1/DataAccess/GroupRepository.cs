using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.Entities;

namespace My.Lab1.DataAccess
{
	public class GroupRepository:IRepository<Group>
	{
		private TimetableDataContext groupDataContext;

		public GroupRepository()
		{
			groupDataContext = new TimetableDataContext();
		}

		public Group GetItem(int id)
		{
			return groupDataContext.Groups.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Group> GetItems()
		{
			return groupDataContext.Groups.AsEnumerable<Group>();
		}

		public void Add(Group item)
		{
			groupDataContext.Groups.InsertOnSubmit(item);
			groupDataContext.SubmitChanges();
		}

		public void Remove(Group item)
		{
			groupDataContext.Groups.DeleteOnSubmit(item);
			groupDataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Group temp = groupDataContext.Groups.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				groupDataContext.Groups.DeleteOnSubmit(temp);
				groupDataContext.SubmitChanges();
			}
		}

		public void Update(Group item)
		{
			Group itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.name = item.name;
				groupDataContext.SubmitChanges();
			}
		}
	}
}
