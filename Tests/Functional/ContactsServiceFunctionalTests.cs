using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class ContactsServiceFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateLoadSearchDelete()
        {
            // Setup
            var CustomersTests = new CustomersServiceFunctionalTests();
            var OrganizationsTest = new OrganizationsServiceFunctionalTests();

            var NewCustomer = CustomersTests.CreateCustomer();
            var NewOrganization = OrganizationsTest.CreateOrganization();

            var RebillyClient = CreateClient();
            var ContactsService = RebillyClient.Contacts();

            // Create
            var NewContact = CreateContact(NewCustomer, NewOrganization);
            Assert.IsNotNull(NewContact.Id);
            Assert.AreEqual(NewCustomer.Id, NewContact.CustomerId);
            Assert.AreEqual(NewOrganization.Name, NewContact.Organization);
            Assert.AreEqual("123 Compton Ln.", NewContact.Address);
            Assert.AreEqual("Unit B", NewContact.Address2);
            Assert.AreEqual("Santa Barbara", NewContact.City);
            Assert.AreEqual("CA", NewContact.Region);
            Assert.AreEqual("US", NewContact.Country);
            Assert.AreEqual("93109", NewContact.PostalCode);
            Assert.AreEqual("Billy", NewContact.FirstName);
            Assert.AreEqual("Smith", NewContact.LastName);

            // Update
            //var UpatedContat = ContactsService.Update(NewContact); // Update not allowed

            // Load
            var LoadedContact = ContactsService.Load(NewContact.Id);
            Assert.IsNotNull(NewContact.Id);
            Assert.AreEqual(NewCustomer.Id, LoadedContact.CustomerId);
            Assert.AreEqual(NewOrganization.Name, LoadedContact.Organization);
            Assert.AreEqual("123 Compton Ln.", LoadedContact.Address);
            Assert.AreEqual("Unit B", LoadedContact.Address2);
            Assert.AreEqual("Santa Barbara", LoadedContact.City);
            Assert.AreEqual("CA", LoadedContact.Region);
            Assert.AreEqual("US", LoadedContact.Country);
            Assert.AreEqual("93109", LoadedContact.PostalCode);
            Assert.AreEqual("Billy", LoadedContact.FirstName);
            Assert.AreEqual("Smith", LoadedContact.LastName);

            // Search
            var SearchFilters = new List<SearchFilter>();
            SearchFilters.Add(new SearchFilter(){ Field = "Id", Values = new List<string>(){ NewContact.Id}});
            var SearchedContacts = ContactsService.Search(new SearchArguments() { Filters = SearchFilters, Limit = 1 });
            Assert.AreEqual(1, SearchedContacts.Count);

            var SearchContact = SearchedContacts[0];

            Assert.IsNotNull(NewContact.Id);
            Assert.AreEqual(NewCustomer.Id, SearchContact.CustomerId);
            Assert.AreEqual(NewOrganization.Name, SearchContact.Organization);
            Assert.AreEqual("123 Compton Ln.", SearchContact.Address);
            Assert.AreEqual("Unit B", SearchContact.Address2);
            Assert.AreEqual("Santa Barbara", SearchContact.City);
            Assert.AreEqual("CA", SearchContact.Region);
            Assert.AreEqual("US", SearchContact.Country);
            Assert.AreEqual("93109", SearchContact.PostalCode);
            Assert.AreEqual("Billy", SearchContact.FirstName);
            Assert.AreEqual("Smith", SearchContact.LastName);

            // Delete
            //ContactsService.Delete(NewContact); // Not allowed

            RebillyClient.Organizations().Delete(NewOrganization);
        }


        public Contact CreateContact(Customer customer, Organization organization)
        {
            var NewContact = new Contact()
            {
                CustomerId = customer.Id,
                Organization = organization.Name,
                Address = "123 Compton Ln.",
                Address2 = "Unit B",
                City = "Santa Barbara",
                Region = "CA",
                Country = "US",
                PostalCode = "93109",
                FirstName = "Billy",
                LastName = "Smith"
            };

            var RebillyClient = CreateClient();
            return RebillyClient.Contacts().Create(NewContact);
        }
    }
}
