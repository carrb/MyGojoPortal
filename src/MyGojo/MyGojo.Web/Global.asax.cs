using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using MyGojo.Data.EF;
using MyGojo.Web.Infrastructure.AutoMapper;
using MyGojo.Web.Infrastructure.Bundles;
using MyGojo.Web.Infrastructure.Filters;
using MyGojo.Web.Infrastructure.Routing;
using MyGojo.Web.Infrastructure.ViewGeneration;
using MyGojo.Web.Infrastructure.WebApi;
using NLog;

namespace MyGojo.Web
{
    public class MvcApplication : HttpApplication
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static IContainer Container { get; set; }


        protected void Application_Start()
        {
            logger.Info("MyGojo.Web - (c) 2012 . ScottWade.net@live.com . All Rights Reserved.");
            logger.Info("HttpApplication startup...");

            InitializeContainer();

            RoutingConfiguration.Configure();
            GlobalWebApisConfiguration.Configure();
            GlobalFiltersConfiguration.Configure();
            ViewGenerationConfiguration.Configure();
            AutoMapperConfiguration.Configure();
            BundlesConfiguration.Configure();

            // Use LocalDB for Entity Framework by default
            //Database.DefaultConnectionFactory = new SqlConnectionFactory("Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");
        }

        protected void Application_Stop()
        {
            logger.Info("Application closing...");
            logger.Info("Terminated.");
        }

        protected void Application_Error()
        {
            logger.Error(Server.GetLastError());
        }


        protected void InitializeContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new MyGojoContextInitializer()).As<IDatabaseInitializer<MyGojoContext>>();

            builder.RegisterType<MyGojoContext>().As<MyGojoContext>()
                .WithParameter(new ResolvedParameter(
                                   (p, c) => p.ParameterType == typeof(IDatabaseInitializer<MyGojoContext>),
                                   (p, c) => c.Resolve<IDatabaseInitializer<MyGojoContext>>()));


            builder.RegisterType<SiteInfoRepository>().As<ISiteInfoRepository>().InstancePerHttpRequest();

            
            // Doing DI with Autofac in ASP.NET WebAPI
            // [ http://weblogs.asp.net/cibrax/ ]
            //
            //
            // Example of how to register all dependencies in the container and use that for resolving all the WebAPI dependencies.
            //
            // The ASP.NET MVC and the ASP.NET MVC WebAPI components both provide a similar model for resolving dependencies using a service locator pattern
            // The problem initially is/was that the AutofacDependencyResolver class implements System.Web.Mvc.IDependencyResolver which works great for ASP.NET MVC
            // while ASP.NET MVC WebAPI expects and implementation of System.Web.Http.Services.IDependencyResolver
            // See \Extensions\WebAPI\AutofacRegistrationExtensions.cs for update to conform to this...
            //
            // The Service Locator can be injected into the WebAPI runtime using the ServiceResolver entry in the global configuration object which supports a Func delegate


            /*
             * builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerHttpRequest();
             * builder.RegisterWebApiControllers(Assembly.GetExecutingAssembly());    // uses the extension method for AutofacRegistration
             * 
             * GlobalConfiguration.Configuration.ServiceResolver.SetResolver(
             *      t => resolver.GetService(t),
             *      t => resolver.GetServices(t));
             * 
             */

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

        }


    }
}