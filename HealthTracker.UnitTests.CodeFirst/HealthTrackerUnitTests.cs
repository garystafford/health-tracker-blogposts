using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HealthTracker.ConsoleApp;
using HealthTracker.DataAccess;

namespace CodeFirstPost.UnitTests
{
    [TestClass]
    public class HealthTrackerUnitTests
    {
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
            using (var dbContext = new HealthTrackerContext())
            {
                var parameters = new object[] { };
                dbContext.Database.ExecuteSqlCommand(sqlScript, parameters);
            }
        }

        [TestMethod]
        public void FindPersonTestReturnsValueof0()
        {
            {
                const string personName = "Test Person 1";
                var results = Examples.FindPerson(personName);
                Assert.AreEqual(0, results);
            }
        }

        [TestMethod]
        public void CreatePersonTestReturnsValueOf1()
        {
            {
                const string personName = "Test Person 2";
                var results = Examples.CreatePerson(personName);
                Assert.AreEqual(1, results);
            }
        }

        [TestMethod]
        public void CreateMealsTestReturnsValueOf2()
        {
            {
                var results = Examples.CreateMeals(1);
                Assert.AreEqual(2, results);
            }
        }
    }
}
