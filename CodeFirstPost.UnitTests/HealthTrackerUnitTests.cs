using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HealthTracker.ConsoleApp;

namespace CodeFirstPost.UnitTests
{
    [TestClass]
    public class HealthTrackerUnitTests
    {
        [TestMethod]
        public void FindPersonTest()
        {
            {
                const string personName = "Test Person";
                var results = Examples.FindPerson(personName);
                Assert.AreEqual(0, results);
            }
        }

        [TestMethod]
        public void CreatePersonTest()
        {
            {
                const string personName = "Test Person";
                var results = Examples.CreatePerson(personName);
                Assert.AreEqual(1, results);
            }
        }

        [TestMethod]
        public void CreateMealsTest()
        {
            {
                var results = Examples.CreateMeals(1);
                Assert.AreEqual(2, results);
            }
        }
    }
}
