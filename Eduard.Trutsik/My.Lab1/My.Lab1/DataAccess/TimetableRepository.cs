using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using My.Lab1.Entities;

namespace My.Lab1.DataAccess
{
	public class TimetableRepository:IRepository<Timetable>
	{
		private const string fileTimetables = "Timetables.txt";

		public Timetable GetItem(int id)
		{
			return GetItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Timetable> GetItems()
		{
			string[] timetables = File.ReadAllLines(fileTimetables);
			return timetables.Select(s =>
			{
				string[] timetable = s.Split('|');
				return new Timetable(Convert.ToInt32(timetable[0]), Convert.ToDateTime(timetable[1]), new GroupRepository().GetItem(Convert.ToInt32(timetable[2])),new SubjectRepository().GetItem(Convert.ToInt32(timetable[3])),new TeacherRepository().GetItem(Convert.ToInt32(timetable[4])));
			});
		}

		public void Add(Timetable item)
		{
			File.AppendAllText(fileTimetables, string.Join("|", item.id + "|" + item.dateTimeStart + "|" + item.group.id + "|" + item.subject + "|" + item.teacher + "\n"));
		}

		public void Remove(Timetable item)
		{
			IEnumerable<Timetable> temp = GetItems().Where(g => g.id != item.id);
			File.Delete(fileTimetables);
			foreach (Timetable timetable in temp)
			{
				File.AppendAllText(fileTimetables, string.Join("|", item.id + "|" + item.dateTimeStart + "|" + item.group.id + "|" + item.subject + "|" + item.teacher + "\n"));
			}
		}

		public void Remove(int id)
		{
			IEnumerable<Timetable> temp = GetItems().Where(g => g.id != id);
			File.Delete(fileTimetables);
			foreach (Timetable timetable in temp)
			{
				File.AppendAllText(fileTimetables, string.Join("|", timetable.id + "|" + timetable.dateTimeStart + "|" + timetable.group.id + "|" + timetable.subject + "|" + timetable.teacher + "\n"));
			}
		}
	}
}
