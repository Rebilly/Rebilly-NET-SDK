﻿using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class BlacklistsServiceFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateLoadSearchDelete()
        {
            // Setup
            var CustomersTests = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTests.CreateCustomer();

            var BlacklistsService = CreateClient().Blacklists();
 
            // Create
            var NewBlacklist = CreateBlacklist(NewCustomer);
            Assert.IsNotNull(NewBlacklist.Id);
            Assert.AreEqual(NewBlacklist.Type, "customerId");
            Assert.Less(new DateTime(2016, 1, 1).Ticks, NewBlacklist.ExpireTime.Value.Ticks);

            // Load
            var LoadedBlacklist = BlacklistsService.Load(NewBlacklist.Id);
            Assert.IsNotNull(LoadedBlacklist.Id);
            Assert.AreEqual(LoadedBlacklist.Type, "customerId");
            Assert.Less(new DateTime(2016, 1, 1).Ticks, LoadedBlacklist.ExpireTime.Value.Ticks);

            // Search
            var ListedBlacklist = BlacklistsService.Search();
            Assert.Less(0, ListedBlacklist.Count);

            // Delete
            BlacklistsService.Delete(NewBlacklist);
        }


        public Blacklist CreateBlacklist(Customer customer)
        {
            var NewBlacklist = new Blacklist()
            {
                Type = "customerId",
                Value = customer.Id,
                Ttl = 3600
            };


            var RebillyClient = CreateClient();
            return RebillyClient.Blacklists().Create(NewBlacklist);
        }

    }
}
