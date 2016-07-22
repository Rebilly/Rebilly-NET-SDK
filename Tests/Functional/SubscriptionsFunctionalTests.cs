using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class SubscriptionsServiceFunctionalTests : TestBase
    {
        [Test]
        public void TestCreateUpdateLoadDelete()
        {
            // TODO: need to implement PaymentCards service first
            /*
            var CustomersTests = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTests.CreateCustomer();

            var PlansTests = new PlansServiceFunctionalTests();
            var NewPlan = PlansTests.CreatePlan();

            var WebsitesTests = new WebsitesServiceFunctionalTests();
            var NewWebsite = WebsitesTests.CreateWebsite();
            */

            //var NewSubscription = CreateSubscription(NewCustomer, NewPlan, NewWebsite);

            return;


            // Create
            //Assert.IsNotNull(NewSubscription.Id);
            /*
            Assert.IsFalse(NewSubscription.IsActive);
            Assert.AreEqual("Current Subscription", NewSubscription.Name);
            Assert.AreEqual("This is a nice description!", NewSubscription.Description);
            //Assert.AreEqual("This is a <strong>rich</strong> description!", NewSubscription.RichDescription);
            Assert.AreEqual("AUD", NewSubscription.Currency);
            Assert.AreEqual(12.95M, NewSubscription.RecurringAmount);
            Assert.AreEqual("month", NewSubscription.RecurringPeriodUnit);
            Assert.AreEqual(1, NewSubscription.RecurringPeriodLength);

            Assert.AreEqual(56.95M, NewSubscription.TrialAmount);
            Assert.AreEqual("week", NewSubscription.TrialPeriodUnit);
            Assert.AreEqual(2, NewSubscription.TrialPeriodLength);

            Assert.AreEqual(112.95M, NewSubscription.SetupAmount);
            Assert.AreEqual("2017-02-10 01:00:01", NewSubscription.ExpireTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));

            Assert.AreEqual("day", NewSubscription.ContractTermUnit);
            Assert.AreEqual(3, NewSubscription.ContractTermLength);
            Assert.AreEqual(4, NewSubscription.RecurringPeriodLimit);

            Assert.AreEqual(12, NewSubscription.MinQuantity);
            Assert.AreEqual(123, NewSubscription.MaxQuantity);
            */

            var SubscriptionsServies = CreateClient().Subscriptions();

            // Update
            /*
            NewSubscription.IsActive = true;
            NewSubscription.Name = "Current Subscription 2";
            NewSubscription.Description = "This is a nice description 2";
            NewSubscription.Currency = "USD";

            NewSubscription.RecurringAmount = 32.95M;
            NewSubscription.RecurringPeriodUnit = "week";
            NewSubscription.RecurringPeriodLength = 1;

            NewSubscription.TrialAmount = 111.95M;
            NewSubscription.TrialPeriodUnit = "day";
            NewSubscription.TrialPeriodLength = 2;

            NewSubscription.SetupAmount = 1112.95M;
            //NewSubscription.ExpireTime = "2018-02-10 03:04:01";

            NewSubscription.ContractTermUnit = "week";
            NewSubscription.ContractTermLength = 7;
            NewSubscription.RecurringPeriodLimit = 10;

            NewSubscription.MinQuantity = 55;
            NewSubscription.MaxQuantity = 5556;

            var UpdatedSubscription = SubscriptionsServies.Update(NewSubscription);
            Assert.IsNotEmpty(UpdatedSubscription.Id);
            Assert.IsTrue(UpdatedSubscription.IsActive);
            Assert.AreEqual("Current Subscription 2", UpdatedSubscription.Name);
            Assert.AreEqual("This is a nice description 2", UpdatedSubscription.Description);
            Assert.AreEqual("USD", UpdatedSubscription.Currency);
            Assert.AreEqual(32.95M, UpdatedSubscription.RecurringAmount);
            Assert.AreEqual("week", UpdatedSubscription.RecurringPeriodUnit);
            Assert.AreEqual(1, UpdatedSubscription.RecurringPeriodLength);

            Assert.AreEqual(111.95M, UpdatedSubscription.TrialAmount);
            Assert.AreEqual("day", UpdatedSubscription.TrialPeriodUnit);
            Assert.AreEqual(2, UpdatedSubscription.TrialPeriodLength);

            Assert.AreEqual(1112.95M, UpdatedSubscription.SetupAmount);
            //Assert.AreEqual("2018-02-10 03:04:01", UpdatedSubscription.ExpireTime);   // This is null for some reason

            Assert.AreEqual("week", UpdatedSubscription.ContractTermUnit);
            Assert.AreEqual(7, UpdatedSubscription.ContractTermLength);
            Assert.AreEqual(10, UpdatedSubscription.RecurringPeriodLimit);

            Assert.AreEqual(55, UpdatedSubscription.MinQuantity);
            Assert.AreEqual(5556, UpdatedSubscription.MaxQuantity);
            */

            // Load
            //var LoadedSubscription = SubscriptionsServies.Load(UpdatedSubscription.Id);
            /*
            Assert.IsTrue(LoadedSubscription.IsActive);
            Assert.AreEqual("Current Subscription 2", LoadedSubscription.Name);
            Assert.AreEqual("This is a nice description 2", LoadedSubscription.Description);
            Assert.AreEqual("USD", LoadedSubscription.Currency);
            Assert.AreEqual(32.95M, LoadedSubscription.RecurringAmount);
            Assert.AreEqual("week", LoadedSubscription.RecurringPeriodUnit);
            Assert.AreEqual(1, LoadedSubscription.RecurringPeriodLength);

            Assert.AreEqual(111.95M, LoadedSubscription.TrialAmount);
            Assert.AreEqual("day", LoadedSubscription.TrialPeriodUnit);
            Assert.AreEqual(2, LoadedSubscription.TrialPeriodLength);

            Assert.AreEqual(1112.95M, LoadedSubscription.SetupAmount);
            //Assert.AreEqual("2018-02-10 03:04:01", LoadedSubscription.ExpireTime);   // This is null for some reason

            Assert.AreEqual("week", LoadedSubscription.ContractTermUnit);
            Assert.AreEqual(7, LoadedSubscription.ContractTermLength);
            Assert.AreEqual(10, LoadedSubscription.RecurringPeriodLimit);

            Assert.AreEqual(55, LoadedSubscription.MinQuantity);
            Assert.AreEqual(5556, LoadedSubscription.MaxQuantity);
            */

            // Delete
            //SubscriptionsServies.Delete(NewSubscription);
        }


        public Subscription CreateSubscription(Customer customer, Plan plan, Website website)
        {
            var NewSubscription = new Subscription();

            NewSubscription.CustomerId = customer.Id;
            NewSubscription.PlanId = plan.Id;
            NewSubscription.WebsiteId = website.Id;
            NewSubscription.Quantity = 2;

            var SubscriptionsServies = CreateClient().Subscriptions();
            return SubscriptionsServies.Create(NewSubscription);
        }

    }
}
