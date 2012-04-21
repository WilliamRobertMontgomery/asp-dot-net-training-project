using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.DataAccess;
using My.Lab1.Entities;
using System.Text.RegularExpressions;

namespace My.Lab1.BusinessLogic
{
	public class ProcessingTimetable
	{
		IRepository<TimeTable> tametableRepository;

		public ProcessingTimetable()
		{
			tametableRepository = new TimetableRepository();
		}

		public IEnumerable<TimeTable> ShowTimetableAll()
		{
			return tametableRepository.GetItems();
		}

		public IEnumerable<TimeTable> ShowTimetableForDateTime(DateTime dateTime)
		{
			return tametableRepository.GetItems().Where(x => dateTime >= x.DateTime && dateTime <= x.DateTime.AddHours(1).AddMinutes(20));
		}

		public IEnumerable<TimeTable> ShowTimetableForGroupByName(string nameGroup)
		{
			return tametableRepository.GetItems().Where(x => Regex.Replace(x.Group.name, @"[ \t]+", "") == nameGroup);
		}

		public IEnumerable<TimeTable> ShowTimetableForGroupById(int idGroup)
		{
			return tametableRepository.GetItems().Where(x => x.Group.id == idGroup);
		}

		public IEnumerable<TimeTable> ShowTimetableForTeacherById(int idTeacher)
		{
			return tametableRepository.GetItems().Where(x => x.Subj_Teach.id_teacher == idTeacher);
		}

		public IEnumerable<TimeTable> ShowTimetableForTeacherByName(string teacherName)
		{
			return tametableRepository.GetItems().Where(x => Regex.Replace(x.Subj_Teach.Teacher.name, @"[ \t]+", "") == teacherName);
		}

		public IEnumerable<TimeTable> ShowTimetableForDateAndGroup(int day, int month, int year, string nameGroup)
		{
			return tametableRepository.GetItems().Where(x => x.DateTime.Day == day && x.DateTime.Month == month && x.DateTime.Year == year && Regex.Replace(x.Group.name, @"[ \t]+", "") == nameGroup);
		}

		public TimeTable ShowTimetableForDateTimeAndGroup(DateTime dateTimeNow, string nameGroup)
		{
			return tametableRepository.GetItems().Where(x => dateTimeNow >= x.DateTime && dateTimeNow <= x.DateTime.AddHours(1).AddMinutes(20) && Regex.Replace(x.Group.name, @"[ \t]+", "") == nameGroup).DefaultIfEmpty(null).First();
		}
	}
}
