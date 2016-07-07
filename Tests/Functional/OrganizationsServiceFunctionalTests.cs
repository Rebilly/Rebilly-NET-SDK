using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class OrganizationsServiceFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateLoadSearchDelete()
        {
            // Create
            var NewOrganization = CreateOrganization();

            // Validate create
            Assert.IsNotNull(NewOrganization.Id);
            Assert.IsNotNull(NewOrganization.Name);
            Assert.AreEqual(NewOrganization.Address, "Address Line 1");
            Assert.AreEqual(NewOrganization.Address2, "Address Line 2");
            Assert.AreEqual(NewOrganization.City, "Santa Barbara");
            Assert.AreEqual(NewOrganization.Region, "CA");
            Assert.AreEqual(NewOrganization.Country, "US");
            Assert.AreEqual(NewOrganization.PostalCode, "93101");


            // Update
            var NewName = "TestOrganization1-" + Guid.NewGuid().ToString();
            NewOrganization.Name = NewName;
            NewOrganization.Address = "Address Line 1 A";
            NewOrganization.Address2 = "Address Line 2 B";
            NewOrganization.City = "Bondi Beach";
            NewOrganization.Region = "NSW";
            NewOrganization.Country = "AU";
            NewOrganization.PostalCode ="2022";

            var RebillyClient = CreateClient();

            var UpdatedOrganization = RebillyClient.Organizations().Update(NewOrganization);
            Assert.IsNotNull(UpdatedOrganization.Id);
            Assert.AreEqual(NewName, UpdatedOrganization.Name);
            Assert.AreEqual(UpdatedOrganization.Address, "Address Line 1 A");
            Assert.AreEqual(UpdatedOrganization.Address2, "Address Line 2 B");
            Assert.AreEqual(UpdatedOrganization.City, "Bondi Beach");
            Assert.AreEqual(UpdatedOrganization.Region, "NSW");
            Assert.AreEqual(UpdatedOrganization.Country, "AU");
            Assert.AreEqual(UpdatedOrganization.PostalCode, "2022");

            // Load
            var LoadedOrganization = RebillyClient.Organizations().Load(UpdatedOrganization.Id);
            Assert.IsNotNull(LoadedOrganization.Id);
            Assert.AreEqual(NewName, LoadedOrganization.Name);
            Assert.AreEqual(UpdatedOrganization.Address, "Address Line 1 A");
            Assert.AreEqual(UpdatedOrganization.Address2, "Address Line 2 B");
            Assert.AreEqual(UpdatedOrganization.City, "Bondi Beach");
            Assert.AreEqual(UpdatedOrganization.Region, "NSW");
            Assert.AreEqual(UpdatedOrganization.Country, "AU");
            Assert.AreEqual(UpdatedOrganization.PostalCode, "2022");

            // Search
            var SearchedOrganizations = RebillyClient.Organizations().Search();
            Assert.Less(0, SearchedOrganizations.Count);

            // Delete
            DeleteOrganization(UpdatedOrganization);

            var ItemsToDelete = RebillyClient.Organizations().Search();
            foreach (var item in ItemsToDelete)
            {
                RebillyClient.Organizations().Delete(item.Id);
            }

            // Test Not found exception
            try
            {
                RebillyClient.Organizations().Delete(UpdatedOrganization.Id);
                Assert.True(false);
            }
            catch (NotFoundException ex)
            {
                Assert.IsInstanceOf<NotFoundException>(ex);
            }
        }


        [Test]
        public void TestCreateOrganizationFails()
        {
            var TestOrganization = new Organization()
            {
                Name = "TestOrganization1-" + Guid.NewGuid().ToString(),
                Address = "Address Line 1",
                Address2 = "Address Line 2",
                City = "Santa Barbara",
                Region = "CA",
                Country = "United States",
                PostalCode = "93101"
            };

            // This should fail because the required country field is missing here
            Assert.Catch<UnprocessableEntityException>(() =>
            {
                var RebillyClient = CreateClient();
                RebillyClient.Organizations().Create(TestOrganization);
            });
        }


        public Organization CreateOrganization()
        {
            var TestOrganization = new Organization()
            {
                Name = "TestOrganization-" + Guid.NewGuid().ToString(),
                Address = "Address Line 1",
                Address2 = "Address Line 2",
                City = "Santa Barbara",
                Region = "CA",
                Country = "US",
                PostalCode = "93101"
            };

            var RebillyClient = CreateClient();
            return RebillyClient.Organizations().Create(TestOrganization);
        }


        public void DeleteOrganization(Organization organization)
        {
            var RebillyClient = CreateClient();
            RebillyClient.Organizations().Delete(organization);
        }
    }
}
