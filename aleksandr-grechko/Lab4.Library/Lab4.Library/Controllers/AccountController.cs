﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Lab4.Library.Models;
using Lab4.Library.BusinessLogic;

namespace Lab4.Library.Controllers
{

	[HandleError]
	public class AccountController : Controller
	{

		public IFormsAuthenticationService FormsService { get; set; }

		private ILibraryClass _library;

		public AccountController(ILibraryClass library)
		{
			_library = library;
		}

		protected override void Initialize(RequestContext requestContext)
		{
			if (FormsService == null) { FormsService = new FormsAuthenticationService(); }

			base.Initialize(requestContext);
		}

		public ActionResult LogOn()
		{
			return View();
		}

		[HttpPost]
		public ActionResult LogOn(LogOnModel model)
		{
			if (ModelState.IsValid)
			{
				Reader reader = _library.GetReader(model.UserName);

				if (reader != null)
				{
					if (_library.AuthorizationReader(reader))
					{
						FormsService.SignIn(model.UserName, model.RememberMe);
						return RedirectToAction("Index", "Home");
					}
					ModelState.AddModelError("", "Пользователь с таким именем уже работает в системе.");
				}
				else
				{
					ModelState.AddModelError("", "Введено несуществующее имя читателя.");
				}
			}
			return View();
		}


		public ActionResult LogOff()
		{
			Reader reader = _library.GetReader(User.Identity.Name);
			if (reader != null)
			{
				_library.ExitReader(reader);
			}

			FormsService.SignOut();

			return RedirectToAction("Index", "Home");
		}


		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				if (_library.GetReader(model.UserName) == null)
				{
					Reader reader = _library.AddReader(model.UserName, model.Address);
					_library.AuthorizationReader(reader);

					FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError("", "Пользователь с таким именем уже зарегистрирован в системе.");
			}

			return View(model);
		}

	}
}
