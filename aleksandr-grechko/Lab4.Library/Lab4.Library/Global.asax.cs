using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lab4.Library.BusinessLogic;
using Lab4.Library.DataAccess;
using Lab4.Library.Core;

namespace Lab4.Library
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);

			LibraryClass library = new LibraryClass(new Repository(new MSSQLRepositoryFactory()));

			ControllerBuilder.Current.SetControllerFactory(new MVCLibraryControllerFactory(library));


		}
	}
}