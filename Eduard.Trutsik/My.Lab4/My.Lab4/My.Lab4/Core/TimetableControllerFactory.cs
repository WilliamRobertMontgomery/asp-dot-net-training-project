using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Routing;
using My.Lab4.DataAccess;
using My.Lab4.Models;

namespace My.Lab4.Core
{
	public class TimetableControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
			DataManager dataManager = new DataManager(new TimetableDataContext());
			return Activator.CreateInstance(controllerType, dataManager) as IController;
		}
	}

}