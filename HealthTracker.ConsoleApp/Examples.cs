using System;
using System.Globalization;
using System.Linq;
using HealthTracker.DataAccess;
using HealthTracker.DataAccess.Classes;

namespace HealthTracker.ConsoleApp
{
    public class Examples
    {
        private static readonly DateTime Today = DateTime.Now.Date;

        /// <summary>
        /// Example of finding a Person in database.
        /// </summary>
        /// <param name="name">Name of the Person</param>
        /// <returns>Person's unique PersonId</returns>
        public static int FindPerson(string name)
        {
            using (var db = new HealthTrackerContext())
            {
                var personId = db.Persons.Where(person => person.Name == name)
                    .Select(person => person.PersonId).FirstOrDefault();

                if (personId == 0)
                    Console.WriteLine("Person, {0}, could not be found...", name);
                else
                    Console.WriteLine("PersonId {0} retrieved...", personId);

                return personId;
            }
        }

        /// <summary>
        /// Example of Adding a new Person
        /// </summary>
        /// <param name="name">Name of the Person</param>
        public static void CreatePerson(string name)
        {
            using (var db = new HealthTrackerContext())
            {
                // Add a new Person
                db.Persons.Add(new Person { Name = name });
                db.SaveChanges();
                Console.WriteLine("New Person, {0}, added...", name);
            }
        }

        /// <summary>
        /// Example of updating existing Hydration count.
        /// Else adding new Hydration if it doesn't exist.
        /// </summary>
        /// <param name="personId">Person's unique PersonId</param>
        public static void UpdateOrAddHydration(int personId)
        {
            using (var db = new HealthTrackerContext())
            {
                var existingHydration = db.Hydrations.FirstOrDefault(
                    hydration => hydration.PersonId == personId
                        && hydration.Date == Today);

                if (existingHydration != null && existingHydration.HydrationId > 0)
                {
                    existingHydration.Count++;
                    db.SaveChanges();
                    Console.WriteLine("Existing Hydration count increased to {0}...",
                        existingHydration.Count.ToString(CultureInfo.InvariantCulture));
                    return;
                }

                db.Hydrations.Add(new Hydration
                {
                    PersonId = personId,
                    Date = Today,
                    Count = 1
                });
                db.SaveChanges();
                Console.WriteLine("New Hydration added...");
            }
        }

        /// <summary>
        /// Example of adding two Meals.
        /// </summary>
        /// <param name="personId">Person's unique PersonId</param>
        public static void CreateMeals(int personId)
        {
            using (var db = new HealthTrackerContext())
            {
                db.Meals.Add(new Meal
                {
                    PersonId = personId,
                    Date = Today,
                    Type = MealType.Breakfast,
                    Description = "(2) slices toast, (1) glass orange juice"
                });

                db.Meals.Add(new Meal
                {
                    PersonId = personId,
                    Date = Today,
                    Type = MealType.Lunch,
                    Description = "(1) protein shake, (1) apple"
                });

                db.SaveChanges();
                Console.WriteLine("Two new Meals added...");
            }
        }

        /// <summary>
        /// Example of adding an Activity
        /// </summary>
        /// <param name="personId">Person's unique PersonId</param>
        public static void CreateActivity(int personId)
        {
            using (var db = new HealthTrackerContext())
            {
                db.Activities.Add(new Activity
                {
                    PersonId = personId,
                    Date = Today,
                    Type = ActivityType.Treadmill,
                    Notes = "30 minutes, 500 calories"
                });

                db.SaveChanges();
                Console.WriteLine("New Activity added...");
            }
        }
    }
}