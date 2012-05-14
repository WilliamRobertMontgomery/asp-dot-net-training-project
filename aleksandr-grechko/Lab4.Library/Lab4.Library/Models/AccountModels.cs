using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lab4.Library.Models
{

	#region Models

	public class LogOnModel
	{
		[Required]
		[DisplayName("Полное имя")]
		public string UserName { get; set; }

		[DisplayName("Запомнить?")]
		public bool RememberMe { get; set; }
	}

	public class RegisterModel
	{
		[Required]
		[DisplayName("Полное имя")]
		public string UserName { get; set; }

		[Required]
		[DisplayName("Адрес")]
		public string Address { get; set; }

	}
	#endregion

	#region Services
	// The FormsAuthentication type is sealed and contains static members, so it is difficult to
	// unit test code that calls its members. The interface and helper class below demonstrate
	// how to create an abstract wrapper around such a type in order to make the AccountController
	// code unit testable.

	public interface IFormsAuthenticationService
	{
		void SignIn(string userName, bool createPersistentCookie);
		void SignOut();
	}

	public class FormsAuthenticationService : IFormsAuthenticationService
	{
		public void SignIn(string userName, bool createPersistentCookie)
		{
			if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

			FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
		}

		public void SignOut()
		{
			FormsAuthentication.SignOut();
		}
	}
	#endregion
}
