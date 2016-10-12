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
        public void TestCreateLoadCancel()
        {
            var CustomersTests = new CustomersServiceFunctionalTests();

            var CashInstrument = new CashPaymentInstrument();
            CashInstrument.ReceivedBy = "testin123";

            var NewCustomer = CustomersTests.CreateCustomer(CashInstrument);

            var PlansTests = new PlansServiceFunctionalTests();
            var NewPlan = PlansTests.CreatePlan();

            var WebsitesTests = new WebsitesServiceFunctionalTests();
            var NewWebsite = WebsitesTests.CreateWebsite();

            var PaymentCard = new PaymentCardsServiceFunctionalTests();

            
            var OrganizationsServiceFunctional = new OrganizationsServiceFunctionalTests();
            var NewOrganization = OrganizationsServiceFunctional.CreateOrganization();

            var ContactsServiceTest = new ContactsServiceFunctionalTests();
            var NewContact = ContactsServiceTest.CreateContact(NewCustomer, NewOrganization);

            var NewPaymentCard = PaymentCard.CreatePaymentCard(NewCustomer, NewContact);

            var NewSubscription = CreateSubscription(NewCustomer, NewPlan, NewWebsite);



            // Create
            Assert.IsNotNull(NewSubscription.Id);
            Assert.AreEqual("Active", NewSubscription.Status);
            Assert.AreEqual(NewCustomer.Id, NewSubscription.CustomerId);
            Assert.AreEqual(NewPlan.Id, NewSubscription.PlanId);
            Assert.AreEqual(NewWebsite.Id, NewSubscription.WebsiteId);
            Assert.AreEqual(2, NewSubscription.Quantity);
            Assert.AreEqual(DateTime.UtcNow.Date, NewSubscription.StartTime.Value.Date);
            Assert.IsNull(NewSubscription.EndTime);
            Assert.IsNull(NewSubscription.CancelledTime);
            Assert.IsNotNull(NewSubscription.RenewalTime);
            Assert.IsNotNull(NewSubscription.CreatedTime);

            var SubscriptionsService = CreateClient().Subscriptions();

            // Load 
            var LoadedSubscription = SubscriptionsService.Load(NewSubscription.Id);
            Assert.IsNotNull(LoadedSubscription.Id);
            Assert.AreEqual("Active", LoadedSubscription.Status);
            Assert.AreEqual(NewCustomer.Id, LoadedSubscription.CustomerId);
            Assert.AreEqual(NewPlan.Id, LoadedSubscription.PlanId);
            Assert.AreEqual(NewWebsite.Id, LoadedSubscription.WebsiteId);
            Assert.AreEqual(2, LoadedSubscription.Quantity);
            Assert.AreEqual(DateTime.UtcNow.Date, LoadedSubscription.StartTime.Value.Date);
            Assert.IsNull(LoadedSubscription.EndTime);
            Assert.IsNull(LoadedSubscription.CancelledTime);
            Assert.IsNotNull(LoadedSubscription.RenewalTime);
            Assert.IsNotNull(LoadedSubscription.CreatedTime);

            // Cancel
            var CanceledSubscription = SubscriptionsService.Cancel(NewSubscription.Id);
            Assert.IsNotNull(CanceledSubscription.Id);
            Assert.AreEqual("Active but set to cancel at next rebill date", CanceledSubscription.Status);
            Assert.AreEqual(NewCustomer.Id, CanceledSubscription.CustomerId);
            Assert.AreEqual(NewPlan.Id, CanceledSubscription.PlanId);
            Assert.AreEqual(NewWebsite.Id, CanceledSubscription.WebsiteId);
            Assert.AreEqual(2, CanceledSubscription.Quantity);
            Assert.AreEqual(DateTime.UtcNow.Date, CanceledSubscription.StartTime.Value.Date);
            Assert.IsNotNull(CanceledSubscription.EndTime);
            Assert.AreEqual(DateTime.UtcNow.Date, CanceledSubscription.CancelledTime.Value.Date);
            Assert.IsNull(CanceledSubscription.RenewalTime);
            Assert.IsNotNull(CanceledSubscription.CreatedTime);
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
