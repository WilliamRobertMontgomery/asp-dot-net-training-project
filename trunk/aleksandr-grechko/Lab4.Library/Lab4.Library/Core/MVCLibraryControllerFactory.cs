using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Library.BusinessLogic;

namespace Lab4.Library.Core
{
	public class MVCLibraryControllerFactory : DefaultControllerFactory
	{
		LibraryClass _library;

		public MVCLibraryControllerFactory(LibraryClass library)
		{
			_library = library;
		}

		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			return Activator.CreateInstance(controllerType, _library) as IController;
		}
	}
}