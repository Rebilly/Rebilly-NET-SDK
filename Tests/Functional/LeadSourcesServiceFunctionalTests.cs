using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class LeadSourcesServiceFunctionalTests : TestBase
    {
        [Test]
        public void TestCreateUpdateLoad()
        {
            var CustomersTest = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTest.CreateCustomer();

            // Create
            var NewLeadSource = CreateLeadSource(NewCustomer);
            Assert.IsNotNull(NewLeadSource.Id);
            Assert.AreEqual("yahoo", NewLeadSource.Source);
            Assert.AreEqual("leg warmers", NewLeadSource.Campaign);
            Assert.AreEqual("legs frozen", NewLeadSource.Term);
            Assert.AreEqual("thaw your legs", NewLeadSource.Content);
            Assert.AreEqual("123", NewLeadSource.Affiliate);
            Assert.AreEqual("1234567890123", NewLeadSource.SubAffiliate);
            Assert.AreEqual("James Bond", NewLeadSource.SalesAgent);
            Assert.AreEqual("a13fd3456b324c3324ff", NewLeadSource.ClickId);
            Assert.AreEqual("www.example.com/landing-page/123", NewLeadSource.Path);
            Assert.AreEqual("127.0.0.1", NewLeadSource.IpAddress);
            Assert.AreEqual("USD", NewLeadSource.Currency);
            Assert.AreEqual(27.5, NewLeadSource.Amount);

            // Create with Specific Id
            string SpecificId = Guid.NewGuid().ToString();


            var NewLeadSourceWithId = CreateLeadSource(NewCustomer, SpecificId);
            Assert.AreEqual(SpecificId, NewLeadSourceWithId.Id);
            Assert.AreEqual("yahoo", NewLeadSourceWithId.Source);
            Assert.AreEqual("leg warmers", NewLeadSourceWithId.Campaign);
            Assert.AreEqual("legs frozen", NewLeadSourceWithId.Term);
            Assert.AreEqual("thaw your legs", NewLeadSourceWithId.Content);
            Assert.AreEqual("123", NewLeadSourceWithId.Affiliate);
            Assert.AreEqual("1234567890123", NewLeadSourceWithId.SubAffiliate);
            Assert.AreEqual("James Bond", NewLeadSourceWithId.SalesAgent);
            Assert.AreEqual("a13fd3456b324c3324ff", NewLeadSourceWithId.ClickId);
            Assert.AreEqual("www.example.com/landing-page/123", NewLeadSourceWithId.Path);
            Assert.AreEqual("127.0.0.1", NewLeadSourceWithId.IpAddress);
            Assert.AreEqual("USD", NewLeadSourceWithId.Currency);
            Assert.AreEqual(27.5, NewLeadSourceWithId.Amount);

            // Load
            var LoadedLeadSource = CreateClient().LeadSources().Load(SpecificId);
            Assert.AreEqual(SpecificId, LoadedLeadSource.Id);
            Assert.AreEqual("yahoo", LoadedLeadSource.Source);
            Assert.AreEqual("leg warmers", LoadedLeadSource.Campaign);
            Assert.AreEqual("legs frozen", LoadedLeadSource.Term);
            Assert.AreEqual("thaw your legs", LoadedLeadSource.Content);
            Assert.AreEqual("123", LoadedLeadSource.Affiliate);
            Assert.AreEqual("1234567890123", LoadedLeadSource.SubAffiliate);
            Assert.AreEqual("James Bond", LoadedLeadSource.SalesAgent);
            Assert.AreEqual("a13fd3456b324c3324ff", LoadedLeadSource.ClickId);
            Assert.AreEqual("www.example.com/landing-page/123", LoadedLeadSource.Path);
            Assert.AreEqual("127.0.0.1", LoadedLeadSource.IpAddress);
            Assert.AreEqual("USD", LoadedLeadSource.Currency);
            Assert.AreEqual(27.5, LoadedLeadSource.Amount);
        }

        public LeadSource CreateLeadSource(Customer customer, string specificId = null)
        {
            var NewLeadSource = new LeadSource()
            {
                CustomerId = customer.Id,
                Source = "yahoo",
                Campaign = "leg warmers",
                Term = "legs frozen",
                Content = "thaw your legs",
                Affiliate = "123",
                SubAffiliate = "1234567890123",
                SalesAgent = "James Bond",
                ClickId = "a13fd3456b324c3324ff",
                Path = "www.example.com/landing-page/123",
                IpAddress = "127.0.0.1",
                Currency = "USD",
                Amount = 27.5
            };

            if (specificId != null)
            {
                NewLeadSource.Id = specificId;
            }


            var RebillyClient = CreateClient();
            return RebillyClient.LeadSources().Create(NewLeadSource);
        }
    }
}
