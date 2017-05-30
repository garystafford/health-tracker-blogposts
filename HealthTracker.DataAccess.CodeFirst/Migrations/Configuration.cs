using System.Data.Entity.Migrations;
using HealthTracker.DataAccess.Classes;

namespace HealthTracker.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HealthTrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HealthTrackerContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Persons.AddOrUpdate(
                p => p.Name,
                new Person { Name = "Andrew Peters" },
                new Person { Name = "Brice Lambson" },
                new Person { Name = "Rowan Miller" }
            );
        }
    }
}
