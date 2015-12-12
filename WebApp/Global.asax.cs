using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using StackExchange.Profiling.Mvc;
using WebApp.Example;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MiniProfilerEF6.Initialize();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterType<Context>().InstancePerRequest();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalFilters.Filters.Add(new ProfilingActionFilter());
        }

        protected void Application_BeginRequest()
        {
            MiniProfiler.Settings.Results_List_Authorize = ReturnTrue;
            MiniProfiler.Settings.Results_Authorize = ReturnTrue;
            
            MiniProfiler.Start();
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

        private bool ReturnTrue(HttpRequest httpRequest)
        {
            return true;
        }
    }
}
