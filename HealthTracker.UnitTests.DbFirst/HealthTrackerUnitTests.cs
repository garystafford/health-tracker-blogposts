﻿using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HealthTracker.DataAccess.DbFirst;

namespace HealthTracker.UnitTests
{
    [TestClass]
    public class HealthTrackerUnitTests
    {
        private const string PersonOriginal = "John Doe";
        private const string PersonNew = "New Person";
        private const string PersonNameUpdated = "Updated Name";

        /// <summary>
        /// Create sample data in HealthTracker database
        /// </summary>
        [TestInitialize]
        public void CreateSampleData()
        {
            const string filePath = "HealthTracker_Sample_Data.sql";
            var streamReader = new StreamReader(filePath);
            var sqlScript = streamReader.ReadToEnd();
            streamReader.Close();
            using (var dbContext = new HealthTrackerEntities())
            {
                var parameters = new object[] { };
                dbContext.Database.ExecuteSqlCommand(sqlScript, parameters);
            }
        }

        /// <summary>
        /// Return the count of People in the database, which should be 4.
        /// </summary>
        [TestMethod]
        public void PersonCountTest()
        {
            using (var dbContext = new HealthTrackerEntities())
            {
                var personCount = (dbContext.People.Select(p => p)).Count();
                Assert.IsTrue(personCount > 0);
            }
        }

        /// <summary>
        /// Return the PersonId of 'John Doe', which should be is 1.
        /// </summary>
        [TestMethod]
        public void PersonIdTest()
        {
            using (var dbContext = new HealthTrackerEntities())
            {
                var personId = dbContext.People
                    .Where(person => person.Name == PersonOriginal)
                    .Select(person => person.PersonId)
                    .First();
                Assert.AreEqual(1, personId);
            }
        }
        /// <summary>
        /// Insert a new Person into the database.
        /// </summary>
        [TestMethod]
        public void PersonAddNewTest()
        {
            using (var dbContext = new HealthTrackerEntities())
            {
                // Setup test
                dbContext.People.Add(new Person { Name = PersonNew });
                dbContext.SaveChanges();

                // Test 1
                var personCount = (dbContext.People.Select(p => p)).Count();
                Assert.AreEqual(5, personCount);

                // Test 2
                var newPersonFound = dbContext.People.FirstOrDefault(
                    person => person.Name == PersonNew);
                Assert.IsNotNull(newPersonFound);

                // Tear down test
                var personToDelete = dbContext.People.FirstOrDefault(
                    person => person.Name == PersonNew);

                if (personToDelete != null) personToDelete.Name = PersonOriginal;
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Update a Person's name in the database.
        /// </summary>
        [TestMethod]
        public void PersonUpdateNameTest()
        {
            using (var dbContext = new HealthTrackerEntities())
            {
                // Setup test
                var personToUpdate = dbContext.People.FirstOrDefault(
                    person => person.Name == PersonOriginal);

                if (personToUpdate != null) personToUpdate.Name = PersonNameUpdated;
                dbContext.SaveChanges();

                // Test
                var updatedPerson = dbContext.People.FirstOrDefault(
                    person => person.Name == PersonNameUpdated);
                Assert.IsNotNull(updatedPerson);

                // Tear down test
                var personToRevert = dbContext.People.FirstOrDefault(
                    person => person.Name == PersonNameUpdated);

                if (personToRevert != null) personToRevert.Name = PersonOriginal;
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Return the Meal count from PersonSummaryViews database view, which should be 21.
        /// </summary>
        [TestMethod]
        public void PersonSummaryViewTest()
        {
            using (var dbContext = new HealthTrackerEntities())
            {
                var mealCount = (dbContext.PersonSummaryViews
                    .Where(p => p.PersonId == 1)
                    .Select(p => p.MealsCount))
                    .First();
                Assert.AreEqual(21, mealCount);
            }
        }

        /// <summary>
        /// Call CountActivities scalar-valued function directly from in the database.
        /// </summary>
        [TestMethod]
        public void ActivtyCountFunctionFromDatabaseTest()
        {
            using (var dbContext = new HealthTrackerEntities())
            {
                const string sqlQuery = "SELECT [dbo].[CountActivities] ({0})";
                object[] parameters = { 1 };
                var activityCount = dbContext.Database.SqlQuery<int>(
                    sqlQuery, parameters).FirstOrDefault();
                Assert.AreEqual(expected: 7, actual: activityCount);
            }
        }

        /// <summary>
        /// Call CountActivities scalar-valued function from the Data Entity Model.
        /// </summary>
        [TestMethod]
        [Ignore]
        public void ActivtyCountFunctionFromEntityTest()
        {
            //todo Code not in EDMX. Was causing error?
        }
    }
}