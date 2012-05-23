using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebProject.Models;
using NHibernate;
using WebProject.DataAccess;
using WebProject.Core;

namespace WebProject.Controllers
{

	[HandleError]
	public class AccountController : Controller
	{

		public IFormsAuthenticationService FormsService { get; set; }
		public IMembershipService MembershipService { get; set; }
		public ISession _session;

		public AccountController(ISession session)
		{
			_session = session;
		}

		protected override void Initialize(RequestContext requestContext)
		{
			if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
			if (MembershipService == null) { MembershipService = new AccountMembershipService(); }
			base.Initialize(requestContext);
		}

		public ActionResult LogOn()
		{
			if (!Request.IsAuthenticated)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Default", "User");
			}
		}

		[HttpPost]
		public ActionResult LogOn(LogOnModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (new DataManager(_session).MembershipRepository.ValidateUser(model.UserName, model.Password))
				{
					FormsService.SignIn(model.UserName, model.RememberMe);
					if (!String.IsNullOrEmpty(returnUrl))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction("Default", "User");
					}
				}
				else
				{
					ModelState.AddModelError("", "Имя пользователя или пароль указаны неверно.");
				}
			}

			// Появление этого сообщения означает наличие ошибки; повторное отображение формы
			return View(model);
		}

		public ActionResult LogOff()
		{
			FormsService.SignOut();
			return RedirectToAction("LogOn", "Account");
		}

		public ActionResult Register()
		{
			ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				// Попытка зарегистрировать пользователя
				MembershipCreateStatus status;
				new DataManager(_session).MembershipRepository.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out status);


				if (status == MembershipCreateStatus.Success)
				{
					FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
					return RedirectToAction("Edit", "User");
				}
				else
				{
					ModelState.AddModelError("", AccountValidation.ErrorCodeToString(status));
				}
			}

			// Появление этого сообщения означает наличие ошибки; повторное отображение формы
			ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
			return View(model);
		}

		[Authorize]
		public ActionResult ChangePassword()
		{
			ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
			return View();
		}

		[Authorize]
		[HttpPost]
		public ActionResult ChangePassword(ChangePasswordModel model)
		{
			if (ModelState.IsValid)
			{
				if (new DataManager(_session).MembershipRepository.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
				{
					return RedirectToAction("ChangePasswordSuccess");
				}
				else
				{
					ModelState.AddModelError("", "Неправильный текущий пароль или недопустимый новый пароль.");
				}
			}

			// Появление этого сообщения означает наличие ошибки; повторное отображение формы
			ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
			return View(model);
		}

		public ActionResult ChangePasswordSuccess()
		{
			return View();
		}

	}
}
