using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.DataAccess;
using My.Lab1.Entities;

namespace My.Lab1.BusinessLogic
{
	public class ProcessingTimetable
	{
		IRepository<Timetable> tametableRepository;

		public ProcessingTimetable(IRepository<Timetable> tametableRepository)
		{
			this.tametableRepository = tametableRepository;
		}

		public IEnumerable<Timetable> ShowTimetableAll()
		{
			return tametableRepository.GetItems();
		}

		public IEnumerable<Timetable> ShowTimetableForDateTime(DateTime dateTime)
		{
			return tametableRepository.GetItems().Where(x => dateTime >= x.dateTimeStart && dateTime <= x.dateTimeStart.AddHours(1).AddMinutes(20));
		}

		public IEnumerable<Timetable> ShowTimetableForGroupByName(string nameGroup)
		{
			return tametableRepository.GetItems().Where(x => x.group.name==nameGroup);
		}

		public IEnumerable<Timetable> ShowTimetableForGroupById(int idGroup)
		{
			return tametableRepository.GetItems().Where(x => x.group.id == idGroup);
		}

		public IEnumerable<Timetable> ShowTimetableForTeacherById(int idTeacher)
		{
			return tametableRepository.GetItems().Where(x => x.teacher.id == idTeacher);
		}

		public IEnumerable<Timetable> ShowTimetableForTeacherByName(string teacherName)
		{
			return tametableRepository.GetItems().Where(x => x.teacher.name == teacherName);
		}

		public IEnumerable<Timetable> ShowTimetableForDateAndGroup(int day, int month, int year, string nameGroup)
		{			 
			return tametableRepository.GetItems().Where(x=>x.dateTimeStart.Day==day && x.dateTimeStart.Month==month && x.dateTimeStart.Year==year && x.group.name==nameGroup);
		}

		public Timetable ShowTimetableForDateTimeAndGroup(DateTime dateTimeNow, string nameGroup)
		{
			return tametableRepository.GetItems().Where(x => dateTimeNow >= x.dateTimeStart && dateTimeNow <= x.dateTimeStart.AddHours(1).AddMinutes(20) && x.group.name == nameGroup).DefaultIfEmpty(null).First();
		}
	}
}
