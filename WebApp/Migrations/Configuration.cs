using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Models.MultiTenantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApp.Models.MultiTenantContext";
        }

        protected override void Seed(WebApp.Models.MultiTenantContext context)
        {
            var tenants = new List<Tenant>
            {
                new Tenant()
                {
                    Name = "SVCC",
                    DomainName = "www.siliconvalley-codecamp.com",
                    Id = 1,
                    Default = true
                },
                new Tenant()
                {
                    Name = "ANGU",
                    DomainName = "angularu.com",
                    Id = 3,
                    Default = false
                },
                new Tenant()
                {
                    Name = "CSSC",
                    DomainName = "codestarssummit.com",
                    Id = 2,
                    Default = false
                }
            };
            tenants.ForEach(a => context.Tenants.Add(a));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
