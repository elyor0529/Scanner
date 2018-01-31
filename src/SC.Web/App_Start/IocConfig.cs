using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SC.Web.Modules;

namespace SC.Web
{
    public static class IocConfig
    {
        /// <summary>
        /// Autofac Configuration
        /// </summary>
        public static void Configure()
        {

            var builder = new Autofac.ContainerBuilder();

            //controller
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            //repo
            builder.RegisterModule(new RepositoryModule());

            //serv
            builder.RegisterModule(new ServiceModule());

            //db
            builder.RegisterModule(new EFModule());

            //packaging
            var container = builder.Build();

            //setup continer
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}