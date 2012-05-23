using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.DataAccess;
using NHibernate;
using WebProject.Core;

namespace WebProject.Controllers
{
	[Authorize(Roles = "Administrator,Moderator")]
	public class AdministrationController : Controller
	{
		private ISession _session;

		public AdministrationController(ISession session)
		{
			_session = session;
		}

		public ActionResult Default()
		{
			return View();
		}

		public ActionResult Users()
		{
			return View(new DataManager(_session).UserRepository.GetAll());
		}

		public ActionResult DetailsUser(Guid id)
		{
			return View(new DataManager(_session).UserRepository.Get(id));
		}

		public ActionResult DeleteUser(Guid id)
		{
			new DataManager(_session).UserRepository.Remove(new DataManager(_session).UserRepository.Get(id));
			return RedirectToAction("Users");
		}

		public ActionResult LockUser(Guid id)
		{
			new DataManager(_session).MembershipRepository.LockUser(new DataManager(_session).UserRepository.Get(id).UserName);
			return RedirectToAction("Users");
		}

		public ActionResult UnlockUser(Guid id)
		{
			new DataManager(_session).MembershipRepository.UnlockUser(new DataManager(_session).UserRepository.Get(id).UserName);
			return RedirectToAction("Users");
		}

		public ActionResult Roles()
		{
			ViewData["Roles"] = new DataManager(_session).RoleRepository.GetAllRoles();
			return View();
		}

		public ActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateRole(string roleName)
		{
			if (ModelState.IsValid)
			{
				new DataManager(_session).RoleRepository.CreateRole(roleName);
				return RedirectToAction("Roles");
			}

			return View();
		}

		public ActionResult DeleteRole(string roleName)
		{
			new DataManager(_session).RoleRepository.DeleteRole(roleName, false);
			return RedirectToAction("Roles");
		}
	}
}
