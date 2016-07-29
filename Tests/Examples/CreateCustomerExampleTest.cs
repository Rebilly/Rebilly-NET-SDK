using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Examples
{
    [TestFixture]
    public class CreateCustomerExampleTest : TestBase
    {
        [Test]
        public void CreateCustomer()
        {
            var Config = new TestConfig();
            var RebillyClient = new Client(apiKey: Config.RebillyApiKey, baseUrl: Client.SandboxHost);
            
            var CreateCustomer = new Customer()
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                FirstName = "Bill",
                LastName = "Smith",
                IpAddress = "123.123.133.133"
            };

            try
            {
                var NewCustomer = RebillyClient.Customers().Create(CreateCustomer);
            }
            catch(RebillyException ex)
            {
                Console.WriteLine("An error has occurred: " + ex.ToString());
                Assert.Fail();
            }
        }
    }
}