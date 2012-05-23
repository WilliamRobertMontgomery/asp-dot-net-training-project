using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using WebProject.Core;
using WebProject.DataAccess.Entities;

namespace WebProject.Controllers
{
	[Authorize]
	public class FriendController : Controller
	{
		private ISession _session;

		public FriendController(ISession session)
		{
			_session = session;
		}

		public ActionResult Default()
		{
			return View(new DataManager(_session).ProfileRepository.GetProfileByUserName(User.Identity.Name).Friends);
		}

		public ActionResult Add(Guid id)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				DataManager _dataManager = new DataManager(_session);
				Profile profile = _dataManager.ProfileRepository.GetProfileByUserName(User.Identity.Name);
				profile.AddFriend(_dataManager.ProfileRepository.Get(id));
				_session.Save(profile);
				transaction.Commit();
			}
			return RedirectToAction("Default");
		}

		public ActionResult Delete(Guid id)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				DataManager _dataManager = new DataManager(_session);
				Profile profile = _dataManager.ProfileRepository.GetProfileByUserName(User.Identity.Name);
				profile.RemoveFriend(_dataManager.ProfileRepository.Get(id));
				_session.Save(profile);
				transaction.Commit();
			}

			return RedirectToAction("Default");
		}

		public ActionResult CreateMessage(Guid id)
		{
			return RedirectToAction("Create", "Message", new { id = id });
		}

		public ActionResult Details(Guid id)
		{
			return RedirectToAction("Details", "User", new { id = id });
		}
	}
}
