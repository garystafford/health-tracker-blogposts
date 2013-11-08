using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HealthTracker.WcfService.UnitTests
{
    [TestClass]
    public class PersonUnitTests
    {
        private readonly HealthTrackerWcfService _wcfService = new HealthTrackerWcfService();

        [TestMethod]
        public void GetPeopleTest()
        {
            Assert.IsNotNull(_wcfService.GetPeople());
        }

        [TestMethod]
        public void GetMealsTest()
        {
            Assert.IsNotNull(_wcfService.GetMeals(1));
        }

        [TestMethod]
        public void UpdatePerson()
        {
            Assert.IsTrue(_wcfService.UpdatePerson(person: new Person
            {
                Name = DateTime.Now.Ticks.ToString(
                CultureInfo.InvariantCulture),
                PersonId = 2
            }));
        }
    }
}
