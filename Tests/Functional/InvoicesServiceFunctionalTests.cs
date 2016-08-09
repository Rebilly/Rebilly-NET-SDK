using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class InvoicesServiceFunctionalTests : TestBase
    {
        [Test]
        public void TestCreateLoad()
        {
            // Create
            var CustomersTests = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTests.CreateCustomer();

            var OrganizationsTests = new OrganizationsServiceFunctionalTests();
            var NewOrganization = OrganizationsTests.CreateOrganization();

            var WebsitesTests = new WebsitesServiceFunctionalTests();
            var NewWebsite = WebsitesTests.CreateWebsite();

            var ContactsTests = new ContactsServiceFunctionalTests();
            var NewContact = ContactsTests.CreateContact(NewCustomer, NewOrganization);


            var NewInvoice = CreateInvoice(NewWebsite, NewCustomer, NewContact);
            Assert.IsNotNull(NewInvoice.Id);
            Assert.AreEqual(NewCustomer.Id, NewInvoice.CustomerId);
            Assert.AreEqual(NewContact.Id, NewInvoice.BillingContactId);
            
            var InvoicesService = CreateClient().Invoices();

            
            // Load
            var LoadedNewInvoice = InvoicesService.Load(NewInvoice.Id);
            Assert.IsNotNull(LoadedNewInvoice.Id);
            Assert.AreEqual(NewCustomer.Id, LoadedNewInvoice.CustomerId);
            Assert.AreEqual(NewContact.Id, LoadedNewInvoice.BillingContactId);
            

            // Create with specific Id
            var SpecificInvoiceId = Guid.NewGuid().ToString();


            var CreatedInvoice2 = CreateInvoice(NewWebsite, NewCustomer, NewContact, SpecificInvoiceId);
            Assert.AreEqual(SpecificInvoiceId, CreatedInvoice2.Id);
            Assert.AreEqual(NewCustomer.Id, CreatedInvoice2.CustomerId);
        }


        public Invoice CreateInvoice(Website website, Customer customer, Contact contact, string id = null)
        {
            var NewInvoice = new Invoice();
            if(id != null)
            {
                NewInvoice.Id = id;
            }

            NewInvoice.WebsiteId = website.Id;
            NewInvoice.CustomerId = customer.Id;
            NewInvoice.BillingContactId = contact.Id;
            NewInvoice.Currency = "aud";

            var InvoicesService = CreateClient().Invoices();
            return InvoicesService.Create(NewInvoice);
        }
    }
}
