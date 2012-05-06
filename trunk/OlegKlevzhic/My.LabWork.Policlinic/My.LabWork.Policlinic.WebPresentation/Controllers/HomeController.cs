using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.LabWork.Policlinic.Library.DataAccess;
using My.LabWork.Policlinic.Library.Business.Registry;
using My.LabWork.Policlinic.Library.Business;

namespace My.LabWork.Policlinic.WebPresentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRegistry registry;

		public HomeController() : this(new Registry()) { }

		public HomeController(IRegistry registry)
		{
			this.registry = registry;
		}

		public ActionResult Index()
		{
			return View(registry.GetSpecializations());
		}

		public ActionResult DetailsSpecialization(int id)
		{
			return View(registry.GetSpecialization(id));
		}

		public ActionResult Choose(int id)
		{
			foreach (var doctor in registry.GetDoctorsSpecialization(id))
			{
				ViewData.Add(doctor.Id.ToString(), registry.GetTimeDoctor(doctor.Id).ToString("HH:mm"));
			}
			return View(registry.GetDoctorsSpecialization(id));
		}

		public ActionResult WriteToReception(int id)
		{
			Record record = registry.WriteToReceptionDoctor(1, new Pacient("Вася", "2"));
			ViewData["Record"] = record.ToString();
			return View(record);
		}
	}
}
