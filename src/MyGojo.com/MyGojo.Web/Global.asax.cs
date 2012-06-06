using System.Reflection;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using DreamSongs.MongoRepository;
using Gojo.Core.Logging;
using MyGojo.Data.Model;
using MyGojo.Web.Infrastructure.Bundles;
using MyGojo.Web.Infrastructure.Filters;
using MyGojo.Web.Infrastructure.Routing;
using MyGojo.Web.Infrastructure.ViewGeneration;
using MyGojo.Web.Infrastructure.WebApi;

using Utility.Logging.NLog.Autofac;


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

        protected void Application_Stop(ILogger logger)
        {
            logger.Info("Application closing...");
            logger.Info("Terminated.");
        }

        protected void Application_Error(ILogger logger)
        {
            logger.Error(Server.GetLastError());
        }


        protected void BootstrapContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<NLogLoggerAutofacModule>();



            builder.RegisterType<MongoRepository<UserInfo>>().As<MongoRepository<UserInfo>>().InstancePerHttpRequest();
            builder.RegisterType<MongoRepository<SiteInfo>>().As<MongoRepository<SiteInfo>>().InstancePerHttpRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}