using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;
using DreamSongs.MongoRepository;
using MyGojo.Web.Infrastructure.Bundles;
using MyGojo.Web.Infrastructure.Filters;
using MyGojo.Web.Infrastructure.Routing;
using MyGojo.Web.Infrastructure.ViewGeneration;
using MyGojo.Web.Infrastructure.WebApi;


namespace MyGojo.Web
{
    public class MvcApplication : HttpApplication
    {
        public static IContainer Container { get; set; }


        protected void Application_Start()
        {
            BootstrapContainer();

            Filters.ConfigureAndRegister();
            Routing.ConfigureAndRegister();
            WebAPI.ConfigureAndRegister();
            ViewGeneration.ConfigureAndRegister();
            Bundles.ConfigureAndRegister();
        }

        protected void Application_Stop()
        {
            //logger.Info("Application closing...");
            //logger.Info("Terminated.");
        }

        protected void Application_Error()
        {
            //logger.Error(Server.GetLastError());
        }


        protected void BootstrapContainer()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<MongoRepository<UserInfo>>().As<MongoRepository<UserInfo>>().InstancePerHttpRequest();
            //builder.RegisterType<MongoRepository<SiteInfo>>().As<MongoRepository<SiteInfo>>().InstancePerHttpRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}