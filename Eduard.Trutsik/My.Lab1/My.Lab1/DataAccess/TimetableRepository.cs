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
		private const string fileStudents = "Timetables.txt";

		public Timetable getItem(int id)
		{
			return getItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Timetable> getItems()
		{
			string[] timetables = File.ReadAllLines(fileStudents);
			return timetables.Select(s =>
			{
				string[] timetable = s.Split('|');
				return new Timetable(Convert.ToInt32(timetable[0]), Convert.ToDateTime(timetable[1]), new GroupRepository().getItem(Convert.ToInt32(timetable[2])),new SubjectRepository().getItem(Convert.ToInt32(timetable[3])),new TeacherRepository().getItem(Convert.ToInt32(timetable[4])));
			});
		}

		public void add(Timetable item)
		{
			File.AppendAllText(fileStudents, string.Join("|", item.id + "|" + item.dateTimeStart + "|" + item.group.id+ "|"+item.subject+ "|" + item.teacher+ "\n"));
		}

		public void remove(Timetable item)
		{
			throw new NotImplementedException();
		}

		public void remove(int id)
		{
			throw new NotImplementedException();
		}
	}
}
