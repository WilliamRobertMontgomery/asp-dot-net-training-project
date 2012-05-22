using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MvcWebProjectNEW.ContainerInstaller;
using Castle.MicroKernel.Registration;
using NHibernate;
using MvcWebProjectNEW.Models.VesenniDataAccess;
using MvcWebProjectNEW.Models;
using Models.DataAccess;

namespace MvcWebProjectNEW
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{id}/{action}", // URL with parameters
                new { controller = "Home", action = "index", id = "Index" } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BootstrapContainer();
        }

        protected void Application_End()
        {
            _container.Dispose();
        }


        #region Windsor infrastructure

        private static IWindsorContainer _container;

        private static void BootstrapContainer()
        {
            var config = NHibernateHelper.BuildDatabaseConfig();
            _container = new WindsorContainer()
                .Register(
                    Component.For<ISessionFactory>()
                        .UsingFactoryMethod(config.BuildSessionFactory),
                    Component.For<IRepository>()
                        .UsingFactoryMethod(s => new Repository(s.Resolve<ISessionFactory>().OpenSession()))
                        .LifeStyle.PerWebRequest)
                .Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        #endregion

    }
}