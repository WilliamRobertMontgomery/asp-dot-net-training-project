using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using My.Lab4.Models;
using My.Lab4.BusinessLogic;

namespace My.Lab4.DataAccess
{
	public class DataManager
	{
		private TimetableDataContext _dataContext;

		private ProcessingTimetable processingTimetableRepository;
		private StudentRepository studentRepository;
		private GroupRepository groupRepository;
		private Subj_TeachRepository subj_TeachRepository;
		private SubjectRepository subjectRepository;
		private TeacherRepository teacherRepository;
		private TimetableRepository timetableRepository;

		public DataManager(TimetableDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public StudentRepository StudentManager
		{
			get
			{
				if (studentRepository == null)
				{
					studentRepository = new StudentRepository(_dataContext);
				}
				return studentRepository;
			}
		}

		public GroupRepository GroupManager
		{
			get
			{
				if (groupRepository == null)
				{
					groupRepository = new GroupRepository(_dataContext);
				}
				return groupRepository;
			}
		}

		public Subj_TeachRepository SubjTeacherManager
		{
			get
			{
				if (subj_TeachRepository == null)
				{
					subj_TeachRepository = new Subj_TeachRepository(_dataContext);
				}
				return subj_TeachRepository;
			}
		}

		public SubjectRepository SubjectManager
		{
			get
			{
				if (subjectRepository == null)
				{
					subjectRepository = new SubjectRepository(_dataContext);
				}
				return subjectRepository;
			}
		}

		public TeacherRepository TeacherManager
		{
			get
			{
				if (teacherRepository == null)
				{
					teacherRepository = new TeacherRepository(_dataContext);
				}
				return teacherRepository;
			}
		}
		public TimetableRepository TimetableManager
		{
			get
			{
				if (timetableRepository == null)
				{
					timetableRepository = new TimetableRepository(_dataContext);
				}
				return timetableRepository;
			}
		}

		public ProcessingTimetable ProcessingTimetableManager
		{
			get
			{
				if (processingTimetableRepository == null)
				{
					processingTimetableRepository = new ProcessingTimetable(this);
				}
				return processingTimetableRepository;
			}
		}
	}
}