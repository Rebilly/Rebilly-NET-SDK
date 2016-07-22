using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class BankAccountsServiceFunctionalTests : TestBase
    {
        [Test]
        public void TestCreateUpdateLoadSearchDelete()
        {
            // Setup
            var OrganizationsTests = new OrganizationsServiceFunctionalTests();
            var NewOrganization = OrganizationsTests.CreateOrganization();
            
            var CustomersTests = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTests.CreateCustomer();

            var ContactsTests = new ContactsServiceFunctionalTests();
            var NewContact = ContactsTests.CreateContact(NewCustomer, NewOrganization);


            var BankAccountsService = CreateClient().BankAccounts();
 
            // I'm getting a 500 error here!
            /*
            // Create
            var NewBankAccount = CreateBankAccount(NewOrganization, NewCustomer, NewContact);
            Assert.IsNotNull(NewBankAccount.Id);
            Assert.AreEqual(NewCustomer.Id, NewBankAccount.CustomerId);


            // Load
            var LoadedBankAccount = BankAccountsService.Load(NewBankAccount.Id);
            Assert.IsNotNull(LoadedBankAccount.Id);
            Assert.AreEqual(NewCustomer.Id, LoadedBankAccount.CustomerId);

            // Search
            var ListedBankAccount = BankAccountsService.Search();
            Assert.Less(0, ListedBankAccount.Count);

            // Delete
            BankAccountsService.Delete(NewBankAccount);
             */
        }


        public BankAccount CreateBankAccount(Organization organization, Customer customer, Contact contact)
        {
            var NewBankAccount = new BankAccount()
            {
                CustomerId = customer.Id,
                ContactId = contact.Id,
                Name = "My bank",
                AccountType = "checking",
                RoutingNumber = "1234",
                AccountNumber = "1235"
                //CustomFields = new Dictionary<string, string>() {  "Test", "Test2"}
            };


            var RebillyClient = CreateClient();
            return RebillyClient.BankAccounts().Create(NewBankAccount);
        }

    }
}
