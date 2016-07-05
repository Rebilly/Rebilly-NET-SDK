using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class CustomersFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateLoadSearchDelete()
        {
            // Create
            var NewCustomer = CreateCustomer();
            Assert.IsNotEmpty(NewCustomer.Id);
            Assert.AreEqual("Bill", NewCustomer.FirstName);
            Assert.AreEqual("Smith", NewCustomer.LastName);
            Assert.AreEqual("123.123.133.133", NewCustomer.IpAddress);

            var RebillyClient = CreateClient();
            var CustomersService = RebillyClient.Customers();

            // Update
            NewCustomer.FirstName = "William";
            NewCustomer.LastName = "Smith2";
            NewCustomer.IpAddress = "127.0.0.1";
            NewCustomer.Email = "1" + NewCustomer.Email;

            var UpdatedCustomer = CustomersService.Update(NewCustomer);

            Assert.AreEqual(NewCustomer.Email, UpdatedCustomer.Email);
            Assert.AreEqual("William", UpdatedCustomer.FirstName);
            Assert.AreEqual("Smith2", UpdatedCustomer.LastName);
            Assert.AreEqual("127.0.0.1", UpdatedCustomer.IpAddress);

            // Load
            var LoadedCustomer = CustomersService.Load(UpdatedCustomer.Id);
            Assert.AreEqual(NewCustomer.Email, LoadedCustomer.Email); 
            Assert.AreEqual("William", LoadedCustomer.FirstName);
            Assert.AreEqual("Smith2", LoadedCustomer.LastName);
            Assert.AreEqual("127.0.0.1", LoadedCustomer.IpAddress);

            // Search
            var EmailFilter = new SearchFilter() { Field = "Email", Values = new List<string>() { LoadedCustomer.Email } };
            var SearchedCustomers = CustomersService.Search(new SearchArguments() { Filters = new List<SearchFilter>(){ EmailFilter }});
            Assert.AreEqual(1, SearchedCustomers.Count);


            //CustomersService.Delete(NewCustomer); // Delete method not allowed
        }


        public Customer CreateCustomer()
        {
            var NewCustomer = new Customer()
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                FirstName = "Bill",
                LastName = "Smith",
                IpAddress = "123.123.133.133"
            };

            var RebillyClient = CreateClient();
            return RebillyClient.Customers().Create(NewCustomer);
        }
    }
}
