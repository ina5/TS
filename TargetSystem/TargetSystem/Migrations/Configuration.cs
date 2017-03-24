namespace TargetSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using TargetSystem.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

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
            this.RolesSeeder(context);
            this.UsersSeeder(context);
            this.PositionsSeeder(context);

        }

        private void PositionsSeeder(TSDbContext context)
        {
            context.Positions.AddOrUpdate(new Position()
            {
                PositionName = "Front-end Developer"
            });
            context.Positions.AddOrUpdate(new Position()
            {
                PositionName = "Back-end Developer"
            });

        }

        private void UsersSeeder(TSDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                };

                userManager.Create(adminUser, "123");
                userManager.AddToRole(adminUser.Id, "admin");
            }
            //TargetManager
            else if (!context.Users.Any(u => u.UserName == "tmanager@abv.bg"))
            {
                var employeeUser = new ApplicationUser
                {
                    UserName = "tmanager@abv.bg",
                    Email = "tmanager@abv.bg",
                };

                userManager.Create(employeeUser, "manager");
                userManager.AddToRole(employeeUser.Id, "manager");
            }
            //Employee
            else if (!context.Users.Any(u => u.UserName == "vani_vanito@abv.bg"))
            {
                var employeeUser = new ApplicationUser
                {
                    UserName = "vani_vanito@abv.bg",
                    Email = "vani_vanito@abv.bg",
                };

                userManager.Create(employeeUser, "vani");
                userManager.AddToRole(employeeUser.Id, "employee");
            }
        }

        private void RolesSeeder(TSDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleAdmin = new IdentityRole() { Name = "admin" };
            var roleTargetManager = new IdentityRole() { Name = "manager" };
            var roleEmployee = new IdentityRole() { Name = "employee" };

            if (!context.Roles.Any(role => role.Name == "admin"))
            {
                roleManager.Create(roleAdmin);
            }

            if (!context.Roles.Any(role => role.Name == "manager"))
            {
                roleManager.Create(roleTargetManager);
            }

            if (!context.Roles.Any(role => role.Name == "employee"))
            {
                roleManager.Create(roleEmployee);
            }
        }
    }
}
