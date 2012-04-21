using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.DataAccess;
using My.Lab1.Entities;
using My.Lab1.BusinessLogic;
using System.Timers;

namespace My.Lab1
{
	class Program
	{
		static DateTime dateTimeStart;
		static DateTime dateTimeFinish;
		static ProcessingTimetable processing;
		static void Main(string[] args)
		{
			dateTimeStart = Convert.ToDateTime("18.04.2012 08:00:00");
			dateTimeFinish = Convert.ToDateTime("18.04.2012 15:00:00");
			processing = new ProcessingTimetable();			
			Start(dateTimeStart,dateTimeFinish, "PM");
			Console.WriteLine();
			Console.WriteLine("Все расписание:");
			Show(processing.ShowTimetableAll()); 
		}

		public static void Start(DateTime dateTimeStart, DateTime dateTimeFinish, string nameGroup)
		{
			bool flag = true;
			Console.WriteLine("Время: {0}", dateTimeStart);
			while (dateTimeStart<dateTimeFinish)
			{
				Console.SetCursorPosition(0, 0);
				Console.WriteLine("Время: {0}", dateTimeStart);
				dateTimeStart = dateTimeStart.AddSeconds(1);
				TimeTable timeTable = processing.ShowTimetableForDateTimeAndGroup(dateTimeStart, nameGroup);
				if (timeTable != null && flag)
				{
					Console.Clear();
					Console.WriteLine("Время: {0}\n", dateTimeStart);
					Console.WriteLine("Началась пара: DateTime:{0}; Group:{1}; Subject:{2}; Teacher:{3}\n", timeTable.DateTime, timeTable.Group.name, timeTable.Subj_Teach.Subject.name, timeTable.Subj_Teach.Teacher.name);
					flag = false;
				}
				else if (timeTable == null && !flag)
				{
					Console.SetCursorPosition(0, 4);
					Console.WriteLine("Пара закончилась: {0}\n", dateTimeStart);
					flag = true;
				}
			}
		}

		public static void Show(IEnumerable<TimeTable> timetable)
		{
			foreach (var item in timetable)
			{
				Console.WriteLine(item.DateTime+" "+item.Group.name+" "+item.Subj_Teach.Subject.name+" "+item.Subj_Teach.Teacher.name);
			}
		}
	}
}
