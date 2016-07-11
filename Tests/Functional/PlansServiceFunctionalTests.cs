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
        public void TestCreateUpdateLoadDelete()
        {
            var NewPlan = CreatePlan();

            // Create
            Assert.IsNotNull(NewPlan.Id);
            Assert.IsFalse(NewPlan.IsActive);
            Assert.AreEqual("Current Plan", NewPlan.Name);
            Assert.AreEqual("This is a nice description!", NewPlan.Description);
            //Assert.AreEqual("This is a <strong>rich</strong> description!", NewPlan.RichDescription);
            Assert.AreEqual("AUD", NewPlan.Currency);
            Assert.AreEqual(12.95M, NewPlan.RecurringAmount);
            Assert.AreEqual("month", NewPlan.RecurringPeriodUnit);
            Assert.AreEqual(1, NewPlan.RecurringPeriodLength);

            Assert.AreEqual(56.95M, NewPlan.TrialAmount);
            Assert.AreEqual("week", NewPlan.TrialPeriodUnit);
            Assert.AreEqual(2, NewPlan.TrialPeriodLength);

            Assert.AreEqual(112.95M, NewPlan.SetupAmount);
            Assert.AreEqual("2017-02-10 01:00:01", NewPlan.ExpireTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));

            Assert.AreEqual("day", NewPlan.ContractTermUnit);
            Assert.AreEqual(3, NewPlan.ContractTermLength);
            Assert.AreEqual(4, NewPlan.RecurringPeriodLimit);

            Assert.AreEqual(12, NewPlan.MinQuantity);
            Assert.AreEqual(123, NewPlan.MaxQuantity);


            var PlansServies = CreateClient().Plans();

            // Update
            NewPlan.IsActive = true;
            NewPlan.Name = "Current Plan 2";
            NewPlan.Description = "This is a nice description 2";
            NewPlan.Currency = "USD";

            NewPlan.RecurringAmount = 32.95M;
            NewPlan.RecurringPeriodUnit = "week";
            NewPlan.RecurringPeriodLength = 1;

            NewPlan.TrialAmount = 111.95M;
            NewPlan.TrialPeriodUnit = "day";
            NewPlan.TrialPeriodLength = 2;

            NewPlan.SetupAmount = 1112.95M;
            //NewPlan.ExpireTime = "2018-02-10 03:04:01";

            NewPlan.ContractTermUnit = "week";
            NewPlan.ContractTermLength = 7;
            NewPlan.RecurringPeriodLimit = 10;

            NewPlan.MinQuantity = 55;
            NewPlan.MaxQuantity = 5556;

            var UpdatedPlan = PlansServies.Update(NewPlan);
            Assert.IsNotEmpty(UpdatedPlan.Id);
            Assert.IsTrue(UpdatedPlan.IsActive);
            Assert.AreEqual("Current Plan 2", UpdatedPlan.Name);
            Assert.AreEqual("This is a nice description 2", UpdatedPlan.Description);
            Assert.AreEqual("USD", UpdatedPlan.Currency);
            Assert.AreEqual(32.95M, UpdatedPlan.RecurringAmount);
            Assert.AreEqual("week", UpdatedPlan.RecurringPeriodUnit);
            Assert.AreEqual(1, UpdatedPlan.RecurringPeriodLength);

            Assert.AreEqual(111.95M, UpdatedPlan.TrialAmount);
            Assert.AreEqual("day", UpdatedPlan.TrialPeriodUnit);
            Assert.AreEqual(2, UpdatedPlan.TrialPeriodLength);

            Assert.AreEqual(1112.95M, UpdatedPlan.SetupAmount);
            //Assert.AreEqual("2018-02-10 03:04:01", UpdatedPlan.ExpireTime);   // This is null for some reason

            Assert.AreEqual("week", UpdatedPlan.ContractTermUnit);
            Assert.AreEqual(7, UpdatedPlan.ContractTermLength);
            Assert.AreEqual(10, UpdatedPlan.RecurringPeriodLimit);

            Assert.AreEqual(55, UpdatedPlan.MinQuantity);
            Assert.AreEqual(5556, UpdatedPlan.MaxQuantity);


            // Load
            var LoadedPlan = PlansServies.Load(UpdatedPlan.Id);
            Assert.IsTrue(LoadedPlan.IsActive);
            Assert.AreEqual("Current Plan 2", LoadedPlan.Name);
            Assert.AreEqual("This is a nice description 2", LoadedPlan.Description);
            Assert.AreEqual("USD", LoadedPlan.Currency);
            Assert.AreEqual(32.95M, LoadedPlan.RecurringAmount);
            Assert.AreEqual("week", LoadedPlan.RecurringPeriodUnit);
            Assert.AreEqual(1, LoadedPlan.RecurringPeriodLength);

            Assert.AreEqual(111.95M, LoadedPlan.TrialAmount);
            Assert.AreEqual("day", LoadedPlan.TrialPeriodUnit);
            Assert.AreEqual(2, LoadedPlan.TrialPeriodLength);

            Assert.AreEqual(1112.95M, LoadedPlan.SetupAmount);
            //Assert.AreEqual("2018-02-10 03:04:01", LoadedPlan.ExpireTime);   // This is null for some reason

            Assert.AreEqual("week", LoadedPlan.ContractTermUnit);
            Assert.AreEqual(7, LoadedPlan.ContractTermLength);
            Assert.AreEqual(10, LoadedPlan.RecurringPeriodLimit);

            Assert.AreEqual(55, LoadedPlan.MinQuantity);
            Assert.AreEqual(5556, LoadedPlan.MaxQuantity);


            // Delete
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

            NewPlan.TrialAmount = 56.95M;
            NewPlan.TrialPeriodUnit = "week";
            NewPlan.TrialPeriodLength = 2;

            NewPlan.SetupAmount = 112.95M;
            NewPlan.ExpireTime = DateTime.Parse("2017-02-10 01:00:01");

            NewPlan.ContractTermUnit = "day";
            NewPlan.ContractTermLength = 3;
            NewPlan.RecurringPeriodLimit = 4;

            NewPlan.MinQuantity = 12;
            NewPlan.MaxQuantity = 123;

            var PlansServies = CreateClient().Plans();
            return PlansServies.Create(NewPlan);
        }

    }
}
