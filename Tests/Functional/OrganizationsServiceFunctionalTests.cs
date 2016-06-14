using System.Collections.Generic;

using NUnit.Framework;
using Rebilly;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class OrganizationsServiceFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateRetrieveListDelete()
        {

        }

        public Organization CreateOrganizaion()
        {
            var TestOrganization = new Organization()
            {
                Name = "TestOrgnazation1",
                Address = "Address Line 1",
                Address2 = "Address Line 2",
                City = "Santa Barbara",
                Region = "CA",
                Country = "United States",
                PostalCode = 93101
            };

            var RebillyClient = CreateClient();
            return RebillyClient.Organizations().Create(TestOrganization);
        }
    }
}
