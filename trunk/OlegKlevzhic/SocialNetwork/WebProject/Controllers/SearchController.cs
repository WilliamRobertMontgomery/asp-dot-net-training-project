using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using WebProject.Core;
using WebProject.Models;
using WebProject.DataAccess.Entities;

namespace WebProject.Controllers
{
	[Authorize]
	public class SearchController : Controller
	{
		private ISession _session;

		public SearchController(ISession session)
		{
			_session = session;
		}

		public ActionResult Default()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Default(SearchModel model)
		{

			DataManager dataManger = new DataManager(_session);
			IEnumerable<Profile> profiles = dataManger.ProfileRepository.GetProfilesBySearchModel(model);
			Profile profile = dataManger.ProfileRepository.GetProfileByUserName(User.Identity.Name);
			profiles = profiles.Where(x => x.Id != profile.Id);
			TempData.Add("profiles", profiles);
			return RedirectToAction("ResultSearch");
		}

		public ActionResult ResultSearch()
		{
			return View(TempData["profiles"]);
		}

		public ActionResult Details(Guid id)
		{
			return RedirectToAction("Details", "User", new { id = id });
		}

		public ActionResult CreateMessage(Guid id)
		{
			return RedirectToAction("Create", "Message", new { id = id });
		}

		public ActionResult AddToFriends(Guid id)
		{
			return RedirectToAction("Add", "Friend", new { id = id });
		}

	}
}
