using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class PlansServiceFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateLoadSearchDelete()
        {
            var NewPlan = CreatePlan();

            Assert.IsNotNull(NewPlan.Id);
            Assert.IsFalse(NewPlan.IsActive);
            Assert.AreEqual("Current Plan", NewPlan.Name);
            Assert.AreEqual("This is a nice description!", NewPlan.Description);
            //Assert.AreEqual("This is a <strong>rich</strong> description!", NewPlan.RichDescription);
            Assert.AreEqual("AUD", NewPlan.Currency);
            Assert.AreEqual(12.95M, NewPlan.RecurringAmount);
            Assert.AreEqual("month", NewPlan.RecurringPeriodUnit);
            Assert.AreEqual(1, NewPlan.RecurringPeriodLength);

            var PlansServies = CreateClient().Plans();

            PlansServies.Delete(NewPlan);
        }


        public Plan CreatePlan()
        {
            var NewPlan = new Plan();
            NewPlan.IsActive = false;
            NewPlan.Name = "Current Plan";
            NewPlan.Description = "This is a nice description!";
            //NewPlan.RichDescription = "This is a <strong>rich</strong> description!";
            NewPlan.Currency= "AUD";
            NewPlan.RecurringAmount = 12.95M;
            NewPlan.RecurringPeriodUnit = "month";
            NewPlan.RecurringPeriodLength = 1;

            var PlansServies = CreateClient().Plans();
            return PlansServies.Create(NewPlan);
        }

    }
}
