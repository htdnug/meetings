using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ClassLibrary.Repositories;
using ClassLibrary.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace WebMvcApplication
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            this.ConfigureContainer(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private void ConfigureContainer(Container container)
        {
            this.RegisterDataRepositories(container);
            this.RegisterBusinessServices(container);
        }

        private void RegisterDataRepositories(Container container)
        {
            var repositoryAssembly = typeof(MyRepository).Assembly;
            const string interfaceNamespace = "ClassLibrary.Repositories";

            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where
                    type.Namespace == "ClassLibrary.Repositories"
                    && type.GetInterfaces().Any(x => x.Namespace == interfaceNamespace)
                select new { Service = type.GetInterfaces().Single(x => x.Namespace == interfaceNamespace), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }
        }

        private void RegisterBusinessServices(Container container)
        {
            var repositoryAssembly = typeof(MyService).Assembly;
            const string interfaceNamespace = "ClassLibrary.Services";

            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where
                    type.Namespace == "ClassLibrary.Services"
                    && type.GetInterfaces().Any(x => x.Namespace == interfaceNamespace)
                select new { Service = type.GetInterfaces().Single(x => x.Namespace == interfaceNamespace), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }
        }
    }
}
