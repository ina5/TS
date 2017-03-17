using Microsoft.Owin;
using Owin;
using TargetSystem.Migrations;
using TargetSystem.Models;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(TargetSystem.Startup))]
namespace TargetSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TSDbContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
