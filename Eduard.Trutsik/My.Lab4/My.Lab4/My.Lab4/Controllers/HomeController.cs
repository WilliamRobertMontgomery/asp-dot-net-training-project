using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.Lab4.DataAccess;
using My.Lab4.Models;
using System.Diagnostics;

namespace My.Lab4.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		private DataManager _dataManager;
		public HomeController(DataManager dataManager)
		{
			_dataManager = dataManager;
		}

		public ActionResult Index()
		{
			var timetables = _dataManager.ProcessingTimetableManager.ShowTimetableForDateTime(DateTime.Now);
			if (timetables.Count()==0)
			{
				ViewData["Message"] = "В данный момент нет пар.";
			}
			else
			{
				ViewData["Message"] = "Пары, которые идут в данный момент:";
			}

			return View(timetables);
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Students()
		{

			return View();
		}
	}
}
