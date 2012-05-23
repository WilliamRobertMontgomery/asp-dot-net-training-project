using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using System.Web.Security;
using WebProject.DataAccess;
using WebProject.Models;
using WebProject.DataAccess.Entities;
using WebProject.Core;

namespace WebProject.Controllers
{
	[HandleError]
	[Authorize]
	public class UserController : Controller
	{

		private ISession _session;

		public UserController(ISession session)
		{
			_session = session;
		}

		public ActionResult Default(Guid? id)
		{
			DataManager dataManager = new DataManager(_session);
			Profile profile;
			if (id == null)
			{
				profile = new DataManager(_session).ProfileRepository.GetProfileByUserName(User.Identity.Name);
				ViewData["Name"] = dataManager.ProfileRepository.GetFullName(profile);
			}
			else
			{
				profile = dataManager.ProfileRepository.Get((Guid)id);
			}
			return View(profile);
		}

		public ActionResult Details(Guid id)
		{
			DataManager dataManager = new DataManager(_session);
			Profile profile = dataManager.ProfileRepository.Get((Guid)id);
			ViewData["Name"] = dataManager.ProfileRepository.GetFullName(profile);
			return View(profile);
		}

		public ActionResult Edit()
		{
			return View(new DataManager(_session).ProfileRepository.GetProfileByUserName(User.Identity.Name));
		}

		[HttpPost]
		public ActionResult Edit(Profile profile)
		{
			if (ModelState.IsValid)
			{
				new DataManager(_session).ProfileRepository.Save(profile);
				return RedirectToAction("Default", "User");
			}

			return View();
		}
	}
}
