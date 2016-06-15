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
        public void TestCreateUpdateRetrieveListDelete()
        {
            // Create
            var NewOrganization = CreateOrganizaion();

            // Validate create
            Assert.IsNotNull(NewOrganization.Id);

            // Delete
            DeleteOrganization(NewOrganization);
        }


        [Test]
        public void TestCreateOrganizationFails()
        {
            var TestOrganization = new Organization()
            {
                Name = "TestOrgnazation1-" + Guid.NewGuid().ToString(),
                Address = "Address Line 1",
                Address2 = "Address Line 2",
                City = "Santa Barbara",
                Region = "CA",
                Country = "United States",
                PostalCode = "93101"
            };

            Assert.Catch<UnprocessableEntityException>(() =>
            {
                var RebillyClient = CreateClient();
                RebillyClient.Organizations().Create(TestOrganization);
            });
        }


        public Organization CreateOrganizaion()
        {
            var TestOrganization = new Organization()
            {
                Name = "TestOrgnazation-" + Guid.NewGuid().ToString(),
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
