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
        public void TestCreateLoadIssueAbandonVoid()
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
            Assert.AreEqual("AUD", NewInvoice.Currency);
            Assert.AreEqual(0, NewInvoice.Amount);
            
            var InvoicesService = CreateClient().Invoices();
            InvoicesService.Middleware.Add(new Rebilly.Middleware.AnalyzerMiddlware(null));

            
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
            Assert.AreEqual("AUD", NewInvoice.Currency);
            Assert.AreEqual(0, NewInvoice.Amount); // TODO: QUESTION for rebily team. Duetime must be set. 

            // Issue
            //NewInvoice.IssuedTime = DateTime.UtcNow;
            //NewInvoice.DueTime = DateTime.UtcNow;
            //var IssuedInvoice = InvoicesService.Issue(NewInvoice); 


            // Abandon
            var AbandonedInvoice = InvoicesService.Abandon(CreatedInvoice2.Id);
            Assert.AreEqual(CreatedInvoice2.Id, AbandonedInvoice.Id);
            Assert.IsNotNull(AbandonedInvoice.AbandonedTime);

            // Void
            var VoidedInvoice = InvoicesService.Void(CreatedInvoice2.Id);
            Assert.AreEqual(CreatedInvoice2.Id, VoidedInvoice.Id);
            Assert.IsNotNull(VoidedInvoice.VoidedTime);               
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
            NewInvoice.Currency = "AUD";

            var InvoicesService = CreateClient().Invoices();
 
            return InvoicesService.Create(NewInvoice);
        }
    }
}
