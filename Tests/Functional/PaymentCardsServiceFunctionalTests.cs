using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class PaymentCardsServiceFunctionalTests : TestBase
    {
        [Test]
        public void TestCreateLoadAuthorizeDeactivate()
        {
            // Create
            var CustomersTests = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTests.CreateCustomer();

            var OrganizationsTests = new OrganizationsServiceFunctionalTests();
            var NewOrganization = OrganizationsTests.CreateOrganization();

            var ContactsTests = new ContactsServiceFunctionalTests();
            var Contact = ContactsTests.CreateContact(NewCustomer, NewOrganization);

            var ExpireYear = DateTime.Now.Year + 1;

            var NewPaymentCard = CreatePaymentCard(NewCustomer, Contact);
            Assert.IsNotNull(NewPaymentCard.Id);
            Assert.AreEqual(NewCustomer.Id, NewPaymentCard.CustomerId);
            Assert.AreEqual(Contact.Id, NewPaymentCard.BillingContactId);
            Assert.AreEqual("1111", NewPaymentCard.Last4);
            Assert.AreEqual("411111", NewPaymentCard.Bin);
            Assert.IsNull(NewPaymentCard.Pan);
            Assert.AreEqual(7, NewPaymentCard.ExpMonth);
            Assert.AreEqual(ExpireYear, NewPaymentCard.ExpYear);

            var PaymentCardsService = CreateClient().PaymentCards();

            
            // Load
            var LoadedNewPaymentCard = PaymentCardsService.Load(NewPaymentCard.Id);
            Assert.IsNotNull(LoadedNewPaymentCard.Id);
            Assert.AreEqual(NewCustomer.Id, LoadedNewPaymentCard.CustomerId);
            Assert.AreEqual(Contact.Id, LoadedNewPaymentCard.BillingContactId);
            Assert.AreEqual("1111", LoadedNewPaymentCard.Last4);
            Assert.AreEqual("411111", LoadedNewPaymentCard.Bin);
            Assert.IsNull(LoadedNewPaymentCard.Pan);
            Assert.AreEqual(7, LoadedNewPaymentCard.ExpMonth);
            Assert.AreEqual(ExpireYear, LoadedNewPaymentCard.ExpYear);


            // Create with specific Id
            var SpecificCardId = Guid.NewGuid().ToString();

            var NewPaymentCard2 = new PaymentCard();
            NewPaymentCard2.Id = SpecificCardId;
            NewPaymentCard2.CustomerId = NewCustomer.Id;
            NewPaymentCard2.BillingContactId = Contact.Id;
            NewPaymentCard2.Pan = "4111111111111111";            
            NewPaymentCard2.Bin = "411111";
            NewPaymentCard2.ExpMonth = 8;
            NewPaymentCard2.ExpYear = ExpireYear;
            NewPaymentCard2.Brand = "visa";
            NewPaymentCard2.Cvv = "123";



            var CreatedPaymentCard2 = PaymentCardsService.Create(NewPaymentCard2);
            Assert.AreEqual(SpecificCardId, CreatedPaymentCard2.Id);
            Assert.AreEqual(NewCustomer.Id, CreatedPaymentCard2.CustomerId);
            Assert.AreEqual(Contact.Id, CreatedPaymentCard2.BillingContactId);
            Assert.AreEqual("1111", CreatedPaymentCard2.Last4);
            Assert.AreEqual("411111", CreatedPaymentCard2.Bin);
            Assert.IsNull(NewPaymentCard.Pan);
            Assert.AreEqual(8, CreatedPaymentCard2.ExpMonth);
            Assert.AreEqual(ExpireYear, CreatedPaymentCard2.ExpYear);
            Assert.AreEqual("inactive", CreatedPaymentCard2.Status);


            // Authorize
            var WebsitesTests = new WebsitesServiceFunctionalTests();
            var NewWebsite = WebsitesTests.CreateWebsite();

            var GatewayAccountsTest = new GatewayAccountsServiceFunctionalTests();
            var NewGatewayAccount = GatewayAccountsTest.CreateGatewayAccount(NewOrganization, NewWebsite, currency: "USD");


            var AuthorizationInfo = new PaymentCardAuthorizationInfo()
            { 
                CardId = CreatedPaymentCard2.Id,
                WebsiteId = NewWebsite.Id,
                Currency = "USD"
            };

            var AuthorizedCard = PaymentCardsService.Authorize(AuthorizationInfo);
            Assert.AreEqual(SpecificCardId, AuthorizedCard.Id);
            Assert.AreEqual(NewCustomer.Id, AuthorizedCard.CustomerId);
            Assert.AreEqual(Contact.Id, AuthorizedCard.BillingContactId);
            Assert.AreEqual("1111", AuthorizedCard.Last4);
            Assert.AreEqual("411111", AuthorizedCard.Bin);
            Assert.IsNull(AuthorizedCard.Pan);
            Assert.AreEqual(8, AuthorizedCard.ExpMonth);
            Assert.AreEqual(ExpireYear, AuthorizedCard.ExpYear);
            //Assert.AreEqual("active", AuthorizedCard.Status);     // QUESTION: this should be active


            var DeactivatedCard = PaymentCardsService.Deactivate(AuthorizedCard.Id);
            Assert.AreEqual(SpecificCardId, DeactivatedCard.Id);
            Assert.AreEqual(NewCustomer.Id, DeactivatedCard.CustomerId);
            Assert.AreEqual(Contact.Id, DeactivatedCard.BillingContactId);
            Assert.AreEqual("1111", DeactivatedCard.Last4);
            Assert.AreEqual("411111", DeactivatedCard.Bin);
            Assert.IsNull(DeactivatedCard.Pan);
            Assert.AreEqual(8, DeactivatedCard.ExpMonth);
            Assert.AreEqual(ExpireYear, DeactivatedCard.ExpYear);
            Assert.AreEqual("deactivated", DeactivatedCard.Status);
        }


        public PaymentCard CreatePaymentCard(Customer customer, Contact contact)
        {
            var ExpireYear = DateTime.Now.Year + 1;

            var NewPaymentCard = new PaymentCard();
            NewPaymentCard.CustomerId = customer.Id;
            NewPaymentCard.BillingContactId = contact.Id;
            NewPaymentCard.Pan = "4111111111111111";            
            NewPaymentCard.Bin = "411111";
            NewPaymentCard.ExpMonth = 7;
            NewPaymentCard.ExpYear = ExpireYear;
            NewPaymentCard.Brand = "visa";
            NewPaymentCard.Cvv = "123";

            var PaymentCardsService = CreateClient().PaymentCards();
            return PaymentCardsService.Create(NewPaymentCard);
        }
    }
}
