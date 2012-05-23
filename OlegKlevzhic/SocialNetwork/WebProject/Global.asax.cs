using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHcfg = NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using WebProject.Core;
using NHibernate.Context;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;

namespace WebProject
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private static IWindsorContainer _container;

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Имя маршрута
				"{controller}/{action}/{id}", // URL-адрес с параметрами
				new { controller = "Account", action = "LogOn", id = UrlParameter.Optional } // Параметры по умолчанию
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
			BootstrapContainer();
		}

		protected void Application_End()
		{
			_container.Dispose();
		}

		private static void BootstrapContainer()
		{
			var config = SessionHelper.Configuration;

			_container = new WindsorContainer()
				.Register(
					Component.For<ISessionFactory>()
						.UsingFactoryMethod(config.BuildSessionFactory),
					Component.For<ISession>()
						.UsingFactoryMethod(s => s.Resolve<ISessionFactory>().OpenSession())
						.LifeStyle.PerWebRequest)
				.Install(FromAssembly.This());

			var controllerFactory = new WindsorControllerFactory(_container.Kernel);
			ControllerBuilder.Current.SetControllerFactory(controllerFactory);
		}

	}
}