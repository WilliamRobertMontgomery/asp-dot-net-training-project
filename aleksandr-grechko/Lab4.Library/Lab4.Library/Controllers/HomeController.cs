using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Library.BusinessLogic;

namespace Lab4.Library.Controllers
{
    public class HomeController : Controller
    {

		private LibraryClass _library;

		public HomeController(LibraryClass library)
		{
			_library = library;
		}

        public ActionResult Index()
        {
			ViewData["Message"] = "Добро пожаловать в библиотеку";

            return View();
        }

    }
}
