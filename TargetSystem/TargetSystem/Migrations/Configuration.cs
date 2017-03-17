namespace TargetSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using TargetSystem.Models;
    using Microsoft.AspNet.Identity.EntityFramework;


    public sealed class Configuration : DbMigrationsConfiguration<TargetSystem.Models.TSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TargetSystem.Models.TSDbContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TargetSystem.Models.TSDbContext context)
        {

            //if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "AppAdmin" };

            //    manager.Create(role);
            //}

            //if (!context.Users.Any(u => u.UserName == "founder"))
            //{
            //    var store = new UserStore<TargetSystem.Models.ApplicationUser>(context);
            //    var manager = new UserManager<TargetSystem.Models.>(store);
            //    var user = new CustomMembershipSample.IdentityModels.AppUser { UserName = "founder" };

            //    manager.Create(user, "Password");
            //    manager.AddToRole(user.Id, "AppAdmin");
            //}

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
