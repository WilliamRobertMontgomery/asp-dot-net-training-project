using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab4.Library.Controllers;
using System.Web.Mvc;


namespace Lab4.Library.Test.Controllers
{
	[TestFixture]
	public class HomeControllerTest
	{
		[Test]
		public void IndexTest()
		{
			var homeController = new HomeController(null);

			var result = homeController.Index() as ViewResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Добро пожаловать в библиотеку", result.ViewData["Message"]);
		}
	}
}
