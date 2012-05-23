using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.LabWork.Policlinic.Library.DataAccess;
using My.LabWork.Policlinic.Library.Business.Registry;
using My.LabWork.Policlinic.Library.Business;
using My.LabWork.Policlinic.WebPresentation.Models;

namespace My.LabWork.Policlinic.WebPresentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRegistry registry = null;

		public HomeController() : this(new Registry()) { }

		public HomeController(IRegistry registry)
		{
			this.registry = registry;
		}

		public ActionResult Default()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Default(Pacient pacient)
		{
			if (pacient.FirstName != String.Empty && pacient.LastName != String.Empty)
			{
				ThePacient.pacient.FirstName = pacient.FirstName;
				ThePacient.pacient.LastName = pacient.LastName;
				return RedirectToAction("Specializations");
			}
			else
			{
				return Default();
			}
		}

		public ActionResult Specializations()
		{
			ViewData["Message"] = "Hello!";
			return View(registry.GetSpecializations());
		}

		public ActionResult DetailsSpecialization(int id)
		{
			return View(registry.GetSpecialization(id));
		}

		public ActionResult Choose(int id)
		{
			ViewData["Message"] = registry.GetSpecialization(id).NameSpecialization;
			foreach (var doctor in registry.GetDoctorsSpecialization(id))
			{
				ViewData.Add(doctor.Id.ToString(), registry.GetTimeDoctor(doctor.Id).ToString("HH:mm"));
			}
			return View(registry.GetDoctorsSpecialization(id));
		}

		public ActionResult WriteToReception(int id)
		{
			ViewData["Message"] = "Your record.";
			Record record = registry.WriteToReceptionDoctor(id, ThePacient.pacient);
			ViewData["Record"] = record.ToString();
			return View(record);
		}
	}
}
