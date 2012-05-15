using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.Lab4.DataAccess;
using My.Lab4.Models;

namespace My.Lab4.Controllers
{
    public class StudentController : Controller
    {
		private DataManager _dataManager;

		public StudentController(DataManager dataManager)
		{
			_dataManager = dataManager;
		}

		public ActionResult List()
		{
			ViewData["groups"] = new SelectList(_dataManager.GroupManager.GetItems(), "Id", "Name");
			var students = _dataManager.StudentManager.GetItems();
			return View(students);
		}

		[HttpPost]
		public ActionResult List(FormCollection collection)
		{
			ViewData["groups"] = new SelectList(_dataManager.GroupManager.GetItems(), "Id", "Name");
			int idGroup = Convert.ToInt32(collection.Get("idGroup"));
			IEnumerable<Student> students = _dataManager.StudentManager.GetItems();
			if (idGroup != 0)
			{
				students = students.Where(x => x.id_group == idGroup);
			}
			if (students.Count() > 0)
			{
				return View(students);
			}
			ViewData["message"] = "По данному запросу ничего не найдено.";
			return View();
		}

        public ActionResult Details(int id)
        {
			var student = _dataManager.StudentManager.GetItem(id);
            return View(student);
        }

        public ActionResult Create()
        {
			ViewData["groups"] = new SelectList(_dataManager.GroupManager.GetItems(),"Id","Name");
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
				student.Group = _dataManager.GroupManager.GetItem(Convert.ToInt32(Request.Form.Get("id_group")));
				_dataManager.StudentManager.Add(student);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Students/Edit/5
 
        public ActionResult Edit(int id)
        {
			Student student = _dataManager.StudentManager.GetItem(id);
			ViewData["groups"] = new SelectList(_dataManager.GroupManager.GetItems(), "Id", "Name");
            return View(student);
        }

        //
        // POST: /Students/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
				student = _dataManager.StudentManager.GetItem(id);
				student.Group = _dataManager.GroupManager.GetItem(Convert.ToInt32(Request.Form.Get("id_group")));
				_dataManager.StudentManager.Update(student);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Students/Delete/5
 
        public ActionResult Delete(int id)
        {
			Student student = _dataManager.StudentManager.GetItem(id);
			return View(student);
        }

        //
        // POST: /Students/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				_dataManager.StudentManager.Remove(id);
				return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
