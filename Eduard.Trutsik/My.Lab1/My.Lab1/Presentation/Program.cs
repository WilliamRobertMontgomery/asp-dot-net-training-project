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
		static ProcessingTimetable processing = new ProcessingTimetable();
		static void Main(string[] args)
		{
			dateTimeStart = Convert.ToDateTime("18.04.2012 08:00:00");
			dateTimeFinish = Convert.ToDateTime("18.04.2012 15:00:00");
			Start(dateTimeStart,dateTimeFinish, "group1");
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
				dateTimeStart = dateTimeStart.AddSeconds(3);
				if (processing.ShowTimetableForDateTimeAndGroup(dateTimeStart, "group1") != null && flag)
				{
					Console.Clear();
					Console.WriteLine("Время: {0}\n", dateTimeStart);
					Console.WriteLine("Началась пара:\n{0}", processing.ShowTimetableForDateTimeAndGroup(dateTimeStart, "group1"));
					flag = false;
				}
				else if (processing.ShowTimetableForDateTimeAndGroup(dateTimeStart, "group1") == null && !flag)
				{
					Console.SetCursorPosition(0, 4);
					Console.WriteLine("Пара закончилась: {0}\n", dateTimeStart);
					flag = true;
				}
			}
		}

		public static void Show(IEnumerable<Timetable> timetable)
		{
			foreach (var item in timetable)
			{
				Console.WriteLine(item.ToString());
			}
		}
	}
}
