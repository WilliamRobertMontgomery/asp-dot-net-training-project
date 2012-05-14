using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Library.BusinessLogic;
using Lab4.Library.Models;
using System.Web.UI;


namespace Lab4.Library.Controllers
{
    public class LibraryController : Controller
    {

		private LibraryClass _library;

		public LibraryController(LibraryClass library)
		{
			_library = library;
		}

        public ActionResult All()
        {
			ViewData["Title"] = "Все книги";
		 	ViewData.Model = _library.GetAllBooks();

			return View("ListBooks");
        }

		public ActionResult Departments()
		{
			ViewData.Model = _library.GetDepartments();

			return View();
		}


		public ActionResult Department(Guid id)
		{
			LibraryDepartment department = _library.GetDepartments().SingleOrDefault(d => d.Id == id);

			if (department == null)
			{
				return RedirectToAction("Departments");
			}
	
			ViewData["Title"] = department.Name;
			ViewData.Model = _library.GetBooksByDepartment(department);

			return View("ListBooks");
		}

		[HttpGet]
		public ActionResult Search()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Search(FormCollection form)
		{

			if (form["SearchText"] == String.Empty)
			{
				ModelState.AddModelError("SearchText", "Строка поиска не должна быть пустой");
			}

			if (!ModelState.IsValid)
			{
				return View();
			}

			if (form["SearchBy"] == "author")
			{
				ViewData["Title"] = "Поиск по автору - " + form["SearchText"];
				ViewData.Model = _library.GetBooksByAuthor(form["SearchText"]);
			}

			if (form["SearchBy"] == "title")
			{
				ViewData["Title"] = "Поиск по названию - " + form["SearchText"];
				ViewData.Model = _library.GetBooksByTitle(form["SearchText"]);
			}

			return View("ListBooks");
		}

		[Authorize]
		public ActionResult Order(Guid id)
		{

			Book book = _library.GetAllBooks().SingleOrDefault(d => d.Id == id);

			Reader reader = _library.GetReader(User.Identity.Name);

			if ((book == null) || (reader == null))
			{
				return RedirectToAction("Index", "Home");
			}

			ViewData["Message"] = _library.OrderBook(book, reader) ? "Читайте на здоровье!" : "Книга уже была выдана.";

			return View();
		}


		[Authorize]
		public ActionResult ReturnList()
		{
			Reader reader = _library.GetReader(User.Identity.Name);
			if (reader == null)
			{
				return RedirectToAction("Index", "Home");
			}

			ViewData.Model = _library.GetBooksOrderedByReader(reader);

			return View();
		}

		[Authorize]
		public ActionResult Return(Guid id)
		{
			Book book = _library.GetAllBooks().SingleOrDefault(d => d.Id == id);

			if (book != null)
			{
				_library.ReturnBook(book);
			}

			return RedirectToAction("ReturnList");
		}

    }
}
