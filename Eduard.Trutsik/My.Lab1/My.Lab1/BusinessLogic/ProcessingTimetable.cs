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
		IRepository<Student> studentRepository;
		IRepository<Teacher> teachertRepository;
		IRepository<Group> groupRepository;
		IRepository<Subject> subjectRepository;
		IRepository<Timetable> tametableRepository;

		public ProcessingTimetable()
		{
			studentRepository = new StudentRepository();
			teachertRepository = new TeacherRepository();
			groupRepository = new GroupRepository();
			subjectRepository = new SubjectRepository();
			tametableRepository = new TimetableRepository();
		}

		public IEnumerable<Timetable> ShowTimetableAll()
		{
			return tametableRepository.getItems();
		}

		public IEnumerable<Timetable> ShowTimetableForDateTime(DateTime dateTime)
		{
			return tametableRepository.getItems().Where(x => dateTime >= x.dateTimeStart && dateTime <= x.dateTimeStart.AddHours(1).AddMinutes(20));
		}

		public IEnumerable<Timetable> ShowTimetableForGroupByName(string nameGroup)
		{
			return tametableRepository.getItems().Where(x => x.group.name==nameGroup);
		}

		public IEnumerable<Timetable> ShowTimetableForGroupById(int idGroup)
		{
			return tametableRepository.getItems().Where(x => x.group.id == idGroup);
		}

		public IEnumerable<Timetable> ShowTimetableForTeacherById(int idTeacher)
		{
			return tametableRepository.getItems().Where(x => x.teacher.id == idTeacher);
		}

		public IEnumerable<Timetable> ShowTimetableForTeacherByName(string teacherName)
		{
			return tametableRepository.getItems().Where(x => x.teacher.name == teacherName);
		}

		public IEnumerable<Timetable> ShowTimetableForDateAndGroup(int day, int month, int year, string nameGroup)
		{			 
			return tametableRepository.getItems().Where(x=>x.dateTimeStart.Day==day && x.dateTimeStart.Month==month && x.dateTimeStart.Year==year && x.group.name==nameGroup);
		}

		public Timetable ShowTimetableForDateTimeAndGroup(DateTime dateTimeNow, string nameGroup)
		{
			return tametableRepository.getItems().Where(x => dateTimeNow >= x.dateTimeStart && dateTimeNow <= x.dateTimeStart.AddHours(1).AddMinutes(20) && x.group.name == nameGroup).DefaultIfEmpty(null).First();
		}
	}
}
