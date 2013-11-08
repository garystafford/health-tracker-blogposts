using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using HealthTracker.DataAccess.DbFirst;

namespace HealthTracker.WcfService
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class HealthTrackerWcfService : IHealthTrackerWcfService
    {
        private readonly DateTime _today = DateTime.Now.Date;

        #region Service Operations
        /// <summary>
        /// Example of Adding a new Person.
        /// </summary>
        /// <param name="person">New Person Object</param>
        /// <returns>True if successful</returns>
        public bool InsertPerson(Person person)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    dbContext.People.Add(new DataAccess.DbFirst.Person { Name = person.Name });
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        /// <summary>
        /// Example of Updating a Person.
        /// </summary>
        /// <param name="person">New Person Object</param>
        /// <returns>True if successful</returns>
        public bool UpdatePerson(Person person)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var personToUpdate = dbContext.People.First(p => p.PersonId == person.PersonId);
                    if (personToUpdate == null) return false;
                    personToUpdate.Name = person.Name;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        /// <summary>
        /// Example of deleting a Person.
        /// </summary>
        /// <param name="personId">PersonId</param>
        /// <returns>True if successful</returns>
        public bool DeletePerson(int personId)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var personToDelete = dbContext.People.First(p => p.PersonId == personId);
                    if (personToDelete == null) return false;
                    dbContext.People.Remove(personToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        /// <summary>
        /// Example of finding a Person's Id.
        /// </summary>
        /// <param name="personName">Name of the Person to find</param>
        /// <returns>Person's unique Id (PersonId)</returns>
        public int GetPersonId(string personName)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var personId = dbContext.People
                                            .Where(person => person.Name == personName)
                                            .Select(person => person.PersonId)
                                            .First();
                    return personId;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return -1;
            }
        }

        /// <summary>
        /// Returns a list of all People.
        /// </summary>
        /// <returns>List of People</returns>
        public List<Person> GetPeople()
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var people = (dbContext.People.Select(p => p));
                    var peopleList = people.Select(p => new Person
                                                            {
                                                                PersonId = p.PersonId,
                                                                Name = p.Name
                                                            }).ToList();

                    return peopleList;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }
        /// <summary>
        /// Example of adding a Meal.
        /// </summary>
        /// <param name="meal">New Meal Object</param>
        /// <returns>True if successful</returns>
        public bool InsertMeal(Meal meal)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    dbContext.Meals.Add(new DataAccess.DbFirst.Meal
                                            {
                                                PersonId = meal.PersonId,
                                                Date = _today,
                                                MealTypeId = meal.MealTypeId,
                                                Description = meal.Description
                                            });
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        /// <summary>
        /// Example of deleting a Meal.
        /// </summary>
        /// <param name="mealId">MealId</param>
        /// <returns>True if successful</returns>
        public bool DeleteMeal(int mealId)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var mealToDelete = dbContext.Meals.First(m => m.MealTypeId == mealId);
                    if (mealToDelete == null) return false;
                    dbContext.Meals.Remove(mealToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        /// <summary>
        /// Return all Meals for a Person.
        /// </summary>
        /// <param name="personId">PersonId</param>
        /// <returns></returns>
        public List<MealDetail> GetMeals(int personId)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var meals = dbContext.Meals.Where(m => m.PersonId == personId)
                                         .Select(m => new MealDetail
                                                          {
                                                              MealId = m.MealId,
                                                              Date = m.Date,
                                                              Type = m.MealType.Description,
                                                              Description = m.Description
                                                          }).ToList();
                    return meals;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }

        /// <summary>
        /// Example of adding an Activity.
        /// </summary>
        /// <param name="activity">New Activity Object</param>
        /// <returns>True if successful</returns>
        public bool InsertActivity(Activity activity)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    dbContext.Activities.Add(new DataAccess.DbFirst.Activity
                                                 {
                                                     PersonId = activity.PersonId,
                                                     Date = _today,
                                                     ActivityTypeId = activity.ActivityTypeId,
                                                     Notes = activity.Notes
                                                 });
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }

        }

        /// <summary>
        /// Example of deleting a Activity.
        /// </summary>
        /// <param name="activityId">ActivityId</param>
        /// <returns>True if successful</returns>
        public bool DeleteActivity(int activityId)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var activityToDelete = dbContext.Activities.First(a => a.ActivityId == activityId);
                    if (activityToDelete == null) return false;
                    dbContext.Activities.Remove(activityToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        /// <summary>
        /// Return all Activities for a Person.
        /// </summary>
        /// <param name="personId">PersonId</param>
        /// <returns>List of Activities</returns>
        public List<ActivityDetail> GetActivities(int personId)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var activities = dbContext.Activities.Where(a => a.PersonId == personId)
                                              .Select(a => new ActivityDetail
                                                               {
                                                                   ActivityId = a.ActivityId,
                                                                   Date = a.Date,
                                                                   Type = a.ActivityType.Description,
                                                                   Notes = a.Notes
                                                               }).ToList();
                    return activities;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }

        /// <summary>
        /// Example of updating existing Hydration count.
        /// Else adding new Hydration if it doesn't exist.
        /// </summary>
        /// <param name="personId">PersonId</param>
        /// <returns>True if successful</returns>
        public bool UpdateOrInsertHydration(int personId)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var existingHydration = dbContext.Hydrations.First(
                        hydration => hydration.PersonId == personId
                                     && hydration.Date == _today);

                    if (existingHydration != null && existingHydration.HydrationId > 0)
                    {
                        existingHydration.Count++;
                        dbContext.SaveChanges();
                        return true;
                    }

                    dbContext.Hydrations.Add(new Hydration
                                                 {
                                                     PersonId = personId,
                                                     Date = _today,
                                                     Count = 1
                                                 });
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        /// <summary>
        /// Return a count of all Meals, Hydrations, and Activities for a Person.
        /// Based on a Database View (virtual table).
        /// </summary>
        /// <param name="personId">PersonId</param>
        /// <returns>Summary for a Person</returns>
        public List<PersonSummaryView> GetPersonSummaryView(int personId)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var personView = (dbContext.PersonSummaryViews
                                               .Where(p => p.PersonId == personId))
                                               .ToList();
                    return personView;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }

        /// <summary>
        /// Return a count of all Meals, Hydrations, and Activities for a Person.
        /// Based on a Stored Procedure.
        /// </summary>
        /// <param name="personId">PersonId</param>
        /// <returns>Summary for a Person</returns>
        public List<GetPersonSummary_Result> GetPersonSummaryStoredProc(int personId)
        {
            try
            {
                using (var dbContext = new HealthTrackerEntities2())
                {
                    var personView = (dbContext.GetPersonSummary(personId)
                                               .Where(p => p.PersonId == personId))
                                               .ToList();
                    return personView;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }

        #endregion
    }

    #region POCO Classes

    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
    }

    public class Meal
    {
        public int PersonId { get; set; }
        public int MealTypeId { get; set; }
        public string Description { get; set; }
    }

    public class MealDetail
    {
        public int MealId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class Activity
    {
        public int PersonId { get; set; }
        public int ActivityTypeId { get; set; }
        public string Notes { get; set; }
    }

    public class ActivityDetail
    {
        public int ActivityId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
    }

    #endregion
}