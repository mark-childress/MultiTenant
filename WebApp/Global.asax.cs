using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.Models;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //using (var context =new MultiTenantContext())
            //{
            //    context.Speakers.Add(new Speaker()
            //    {
            //        LastName = Guid.NewGuid().ToString()
            //    });
            //    context.Sessions.Add(new Session()
            //    {
            //        Title = Guid.NewGuid().ToString()
            //    });
            //    context.SaveChanges();

            //}

            //using (var context = new MultiTenantContext())
            //{
            //    var tenants = new List<Tenant>
            //{
            //    new Tenant()
            //    {
            //        Name = "SVCC",
            //        DomainName = "www.siliconvalley-codemap.com",
            //        Id = 1,
            //        Default = true
            //    },
            //    new Tenant()
            //    {
            //        Name = "ANGU",
            //        DomainName = "angularu.com",
            //        Id = 3,
            //        Default = false
            //    },
            //    new Tenant()
            //    {
            //        Name = "CSSC",
            //        DomainName = "codestarsummit.com",
            //        Id = 2,
            //        Default = true
            //    }
            //};

            //    context.Tenants.AddRange(tenants);
            //    context.SaveChanges();
            //}
        }
    }
}
