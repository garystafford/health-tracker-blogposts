﻿using System.Data.Entity;
using HealthTracker.DataAccess.Classes;

namespace HealthTracker.DataAccess
{
    public class HealthTrackerContext : DbContext
    {
        public HealthTrackerContext()
            : base("name=HealthTrackerConnection")
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Hydration> Hydrations { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonSummaryView> PersonSummaryViews { get; set; }
    }
}
