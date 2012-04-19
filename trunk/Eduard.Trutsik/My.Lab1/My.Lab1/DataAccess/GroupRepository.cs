using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using My.Lab1.Entities;

namespace My.Lab1.DataAccess
{
	public class GroupRepository : IRepository<Group>
	{
		private const string fileStudents = "Groups.txt";


		public Group getItem(int id)
		{
			return getItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Group> getItems()
		{
			string[] groups = File.ReadAllLines(fileStudents);
			return groups.Select(s =>
			{
				string[] group = s.Split('|');
				return new Group(Convert.ToInt32(group[0]), group[1]);
			});
		}

		public void add(Group item)
		{
			File.AppendAllText(fileStudents, string.Join("|", item.id + "|" + item.name + "\n"));
		}

		public void remove(Group item)
		{
			throw new NotImplementedException();
		}

		public void remove(int id)
		{
			throw new NotImplementedException();
		}
	}
}
