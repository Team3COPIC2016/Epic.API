using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Epic.Domain.Model;
using Epic.Domain.Repositories;
using Epic.Repositories.MongoDB;
using MongoDB.Driver;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Epic.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();

            container.RegisterSingleton<IMongoDatabase>(() => new MongoClient("mongodb://admin:APCo73yjfs@ds023510.mlab.com:23510/epic-cop2016").GetDatabase("epic-cop2016"));
            container.RegisterWebApiRequest<IEmployeeRepository, EmployeeRepository>();
            container.RegisterWebApiRequest<IWorkRepository<Domain.Model.Epic>, WorkRepository<Domain.Model.Epic>>();
            container.RegisterWebApiRequest<WorkRepository<Feature>, WorkRepository<Feature>>();
            container.RegisterWebApiRequest<WorkRepository<Story>, WorkRepository<Story>>();
            container.RegisterWebApiRequest<WorkRepository<Task>, WorkRepository<Task>>();
            container.RegisterWebApiRequest<WorkRepository<GenericWork>, WorkRepository<GenericWork>>();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
