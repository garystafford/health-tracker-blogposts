using System;
using System.Globalization;
using System.Linq;
using HealthTracker.DataAccess;
using HealthTracker.DataAccess.Classes;

namespace HealthTracker.WcfService
{
    public class HealthTrackerService : IHealthTrackerService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        private readonly DateTime _today = DateTime.Now.Date;

        /// <summary>
        /// Example of finding a Person in database.
        /// </summary>
        /// <param name="name">Name of the Person</param>
        /// <returns>Person's unique PersonId</returns>
        public int FindPerson(string name)
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
        /// <returns>True of success</returns>
        public bool CreatePerson(string name)
        {
            using (var db = new HealthTrackerContext())
            {
                // Add a new Person
                db.Persons.Add(new Person { Name = name });
                db.SaveChanges();
                Console.WriteLine("New Person, {0}, added...", name);
                return true;
            }
        }

        /// <summary>
        /// Example of updating existing Hydration count.
        /// Else adding new Hydration if it doesn't exist.
        /// </summary>
        /// <param name="personId">Person's unique PersonId</param>
        /// <returns>True of success</returns>
        public bool UpdateOrAddHydration(int personId)
        {
            using (var db = new HealthTrackerContext())
            {
                var existingHydration = db.Hydrations.FirstOrDefault(
                    hydration => hydration.PersonId == personId
                        && hydration.Date == _today);

                if (existingHydration != null && existingHydration.HydrationId > 0)
                {
                    existingHydration.Count++;
                    db.SaveChanges();
                    Console.WriteLine("Existing Hydration count increased to {0}...",
                        existingHydration.Count.ToString(CultureInfo.InvariantCulture));
                    return true;
                }

                db.Hydrations.Add(new Hydration
                {
                    PersonId = personId,
                    Date = _today,
                    Count = 1
                });
                db.SaveChanges();
                Console.WriteLine("New Hydration added...");
                return true;
            }
        }

        /// <summary>
        /// Example of adding two Meals.
        /// </summary>
        /// <param name="personId">Person's unique PersonId</param>
        /// <returns>True of success</returns>
        public bool CreateMeals(int personId)
        {
            using (var db = new HealthTrackerContext())
            {
                db.Meals.Add(new Meal
                {
                    PersonId = personId,
                    Date = _today,
                    Type = MealType.Breakfast,
                    Description = "(2) slices toast, (1) glass orange juice"
                });

                db.Meals.Add(new Meal
                {
                    PersonId = personId,
                    Date = _today,
                    Type = MealType.Lunch,
                    Description = "(1) protein shake, (1) apple"
                });

                db.SaveChanges();
                Console.WriteLine("Two new Meals added...");
                return true;
            }
        }

        /// <summary>
        /// Example of adding an Activity
        /// </summary>
        /// <param name="personId">Person's unique PersonId</param>
        /// <returns>True of success</returns>
        public bool CreateActivity(int personId)
        {
            using (var db = new HealthTrackerContext())
            {
                db.Activities.Add(new Activity
                {
                    PersonId = personId,
                    Date = _today,
                    Type = ActivityType.Treadmill,
                    Notes = "30 minutes, 500 calories"
                });

                db.SaveChanges();
                Console.WriteLine("New Activity added...");
                return true;
            }
        }
    }
}
