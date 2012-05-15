using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.Lab4.DataAccess;
using My.Lab4.Models;

namespace My.Lab4.Controllers
{
    public class TimeTableController : Controller
    {
        
		private DataManager _dataManager;

		public TimeTableController(DataManager dataManager)
		{
			_dataManager = dataManager;
		}

		public ActionResult List()
		{
			var timetables = _dataManager.TimetableManager.GetItems();
			SetInfo();
			return View(timetables);
		}

		[HttpPost]
		public ActionResult List(FormCollection collection)
		{
			DateTime dateTime;
			int idGroup = Convert.ToInt32(collection.Get("idGroup"));
			int idTeacher = Convert.ToInt32(collection.Get("idTeacher"));
			SetInfo();
			IEnumerable<TimeTable> timetables = _dataManager.TimetableManager.GetItems();
			try
			{
				dateTime = Convert.ToDateTime(collection.Get("dateTime"));
				if (dateTime != null)
				{
					timetables = _dataManager.ProcessingTimetableManager.ShowTimetableForDateTime(dateTime);
				}
			}
			catch (Exception) { }

			if (idGroup != 0 && timetables.Count()>0)
			{
				timetables = timetables.Where(x => x.id_group == idGroup);
			}
			if (idTeacher != 0 && timetables.Count() > 0)
			{
				timetables = timetables.Where(x => x.Subj_Teach.id_teacher == idTeacher);
			}			
			if (timetables.Count() > 0)
			{
				return View(timetables);
			}
			else
			{
				ViewData["message"] = "По данному запросу ничего не найдено.";
				timetables = _dataManager.TimetableManager.GetItems();
				return View();
			}
		}

		public void SetInfo()
		{
			ViewData["Groups"] = new SelectList(_dataManager.GroupManager.GetItems(), "Id", "Name");
			ViewData["Subjects"] = new SelectList(_dataManager.SubjTeacherManager.GetItems().Select(x => x.Subject), "Id", "Name");
			ViewData["Teachers"] = new SelectList(_dataManager.SubjTeacherManager.GetItems().Select(x => x.Teacher), "Id", "Name");
		}

        public ActionResult Create()
        {
			SetInfo();
            return View();
        } 

        [HttpPost]
        public ActionResult Create(TimeTable timetable)
        {
			try
			{
				timetable.Group = _dataManager.GroupManager.GetItem(Convert.ToInt32(Request.Form.Get("id_group")));
				timetable.Subj_Teach.Teacher = _dataManager.TeacherManager.GetItem(timetable.Subj_Teach.id_teacher);
				timetable.Subj_Teach.Subject = _dataManager.SubjectManager.GetItem(timetable.Subj_Teach.id_subject);
				_dataManager.TimetableManager.Add(timetable);
				return RedirectToAction("List");
			}
			catch
			{
			}
			SetInfo();
			ViewData["message"] = "Не корректно введены данные!";
			return View();
        }
 
        public ActionResult Edit(int id)
        {
			TimeTable timetable = _dataManager.TimetableManager.GetItem(id);
			ViewData["groups"] = new SelectList(_dataManager.GroupManager.GetItems(), "Id", "Name",timetable.Group.id);
			ViewData["subject"] = new SelectList(_dataManager.SubjTeacherManager.GetItems().Select(x=>x.Subject), "Id", "Name",timetable.Subj_Teach.Subject.id);
			ViewData["teacher"] = new SelectList(_dataManager.SubjTeacherManager.GetItems().Select(x => x.Teacher), "Id", "Name", timetable.Subj_Teach.Teacher.id);
			return View(timetable);
        }

        [HttpPost]
        public ActionResult Edit(int id, TimeTable timetable)
        {
            try
            {
				timetable = _dataManager.TimetableManager.GetItem(id);
				timetable.Group = _dataManager.GroupManager.GetItem(Convert.ToInt32(Request.Form.Get("id_group")));
				timetable.Subj_Teach.Subject = _dataManager.SubjectManager.GetItem(Convert.ToInt32(Request.Form.Get("id_subject")));
				timetable.Subj_Teach.Teacher = _dataManager.TeacherManager.GetItem(Convert.ToInt32(Request.Form.Get("id_teacher")));
				_dataManager.TimetableManager.Update(timetable);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
 
        public ActionResult Delete(int id)
        {
			TimeTable timetable = _dataManager.TimetableManager.GetItem(id);
			return View(timetable);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				_dataManager.TimetableManager.Remove(id);
				return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
