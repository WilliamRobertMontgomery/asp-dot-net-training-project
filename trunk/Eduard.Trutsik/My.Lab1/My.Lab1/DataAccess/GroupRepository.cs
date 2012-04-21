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
		private const string fileGroups = "Groups.txt";

		public Group GetItem(int id)
		{
			return GetItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Group> GetItems()
		{
			string[] groups = File.ReadAllLines(fileGroups);
			return groups.Select(s =>
			{
				string[] group = s.Split('|');
				return new Group(Convert.ToInt32(group[0]), group[1]);
			});
		}

		public void Add(Group item)
		{
			File.AppendAllText(fileGroups, String.Join("|", item.id + "|" + item.name + "\n"));
		}

		public void Remove(Group item)
		{
			IEnumerable<Group> temp = GetItems().Where(g => g.id != item.id);
			File.Delete(fileGroups);
			foreach (Group group in temp)
			{
				File.AppendAllText(fileGroups, String.Join("|", group.id + "|" + group.name + "\n"));
			}
		}

		public void Remove(int id)
		{
			IEnumerable<Group> temp = GetItems().Where(g => g.id != id);
			File.Delete(fileGroups);
			foreach (Group group in temp)
			{
				File.AppendAllText(fileGroups, String.Join("|", group.id + "|" + group.name + "\n"));
			}
		}
	}
}
