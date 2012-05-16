using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab4.Library.Controllers;
using System.Web.Mvc;
using Moq;
using Lab4.Library.BusinessLogic;
using Lab4.Library.Models;
using System.Web;
using System.Security.Principal;
using System.Web.Routing;


namespace Lab4.Library.Test.Controllers
{
	[TestFixture]
	public class AccountControllerTest
	{
		private AccountController accountController;

		private Mock<ILibraryClass> library;

		private Mock<IFormsAuthenticationService> formAuth;

		[SetUp]
		public void Init()
		{
			library = new Mock<ILibraryClass>();
			formAuth = new Mock<IFormsAuthenticationService>();
			accountController = new AccountController(library.Object) { FormsService = formAuth.Object };
		}

		[Test]
		public void LogOnTest()
		{
			var result = accountController.LogOn() as ViewResult;

			Assert.IsNotNull(result);
		}

		[Test]
		public void LogOn_ModelState_Is_Invalid_Test()
		{
			accountController.ModelState.AddModelError("A Error", "Message");
			LogOnModel logOnModel = new LogOnModel();

			var result = accountController.LogOn(logOnModel) as ViewResult;

			Assert.IsNotNull(result);
		}

		[Test]
		public void LogOn_Reader_Not_Exist_Test()
		{
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(null as Reader);

			LogOnModel logOnModel = new LogOnModel();

			var result = accountController.LogOn(logOnModel) as ViewResult;

			Assert.IsNotNull(result);
			Assert.IsFalse(accountController.ModelState.IsValid);
		}

		[Test]
		public void LogOn_Reader_Authorization_Error_Test()
		{
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(new Reader("name", "adress"));
			library.Setup(lib => lib.AuthorizationReader(It.IsAny<Reader>())).Returns(false);

			LogOnModel logOnModel = new LogOnModel();

			var result = accountController.LogOn(logOnModel) as ViewResult;

			Assert.IsNotNull(result);
			Assert.IsFalse(accountController.ModelState.IsValid);
		}

		[Test]
		public void LogOn_Reader_Authorization_Success_Test()
		{
			LogOnModel logOnModel = new LogOnModel();
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(new Reader("name", "adress"));
			library.Setup(lib => lib.AuthorizationReader(It.IsAny<Reader>())).Returns(true);

			var result = accountController.LogOn(logOnModel) as RedirectToRouteResult;

			formAuth.Verify(f => f.SignIn(logOnModel.UserName, logOnModel.RememberMe));
			Assert.IsNotNull(result);
			Assert.AreEqual("Home", result.RouteValues["Controller"]);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void LogOffTest()
		{
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(new Reader("name", "adress"));
			library.Setup(lib => lib.ExitReader(It.IsAny<Reader>())).Returns(true);

			accountController.ControllerContext = new ControllerContext()
			{
				Controller = accountController,
				RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
			};
			var result = accountController.LogOff() as RedirectToRouteResult;

			formAuth.Verify(f => f.SignOut());
			Assert.IsNotNull(result);
			Assert.AreEqual("Home", result.RouteValues["Controller"]);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}


		[Test]
		public void RegisterTest()
		{
			var result = accountController.Register() as ViewResult;

			Assert.IsNotNull(result);
		}

		[Test]
		public void Register_ModelState_Is_Invalid_Test()
		{
			accountController.ModelState.AddModelError("A Error", "Message");
			RegisterModel registerModel = new RegisterModel();

			var result = accountController.Register(registerModel) as ViewResult;

			Assert.IsNotNull(result);
		}

		[Test]
		public void Register_Reader_Is_Exist_Test()
		{
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(new Reader("name", "adress"));
			RegisterModel registerModel = new RegisterModel();

			var result = accountController.Register(registerModel) as ViewResult;

			Assert.IsNotNull(result);
			Assert.IsFalse(accountController.ModelState.IsValid);
		}

		[Test]
		public void Register_Success_Test()
		{
			RegisterModel registerModel = new RegisterModel();
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(null as Reader);
			library.Setup(lib => lib.AddReader(registerModel.UserName, registerModel.Address)).Returns(new Reader("name", "adress"));

			var result = accountController.Register(registerModel) as RedirectToRouteResult;

			library.Verify(lib => lib.AuthorizationReader(It.IsAny<Reader>()));			
			formAuth.Verify(f => f.SignIn(registerModel.UserName, false));
			Assert.IsNotNull(result);
			Assert.AreEqual("Home", result.RouteValues["Controller"]);
			Assert.AreEqual("Index", result.RouteValues["Action"]);

		}
	}
}
