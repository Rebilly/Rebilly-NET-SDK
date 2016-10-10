using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;
using Rebilly.Middleware;

namespace Tests.Functional
{
    [TestFixture]
    public class PaymentCardTokensServiceFunctionalTests : TestBase
    {
        [Test]
        public void TestCreateLoadListExpireTokens()
        {
            // Create
            var CustomersTests = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTests.CreateCustomer();

            var OrganizationsTests = new OrganizationsServiceFunctionalTests();
            var NewOrganization = OrganizationsTests.CreateOrganization();

            var ContactsTests = new ContactsServiceFunctionalTests();
            var Contact = ContactsTests.CreateContact(NewCustomer, NewOrganization);


            var PaymentCardsTests = new PaymentCardsServiceFunctionalTests();
            var NewPaymentCard = PaymentCardsTests.CreatePaymentCard(NewCustomer, Contact);

            var NewPaymentCardToken = CreateCreditCardPaymentCardToken(NewCustomer, Contact, NewPaymentCard);
            Assert.IsNotNull(NewPaymentCardToken.Id);

            // Load
            var PaymentCardTokensService = CreateClient().PaymentCardTokens();
            var LoadedPaymentCardToken = PaymentCardTokensService.Load(NewPaymentCardToken.Id);
            Assert.AreEqual(NewPaymentCardToken.Id, LoadedPaymentCardToken.Id);


            // Expire
            var ExpiredResponse = PaymentCardTokensService.Expire(NewPaymentCardToken.Id);
            Assert.IsNotNull(ExpiredResponse.Id);
                
        }


        [Test]
        public void TestCreateLoadListExpireTokensWithRebillySignature()
        {
            // Create
            var CustomersTests = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTests.CreateCustomer();

            var OrganizationsTests = new OrganizationsServiceFunctionalTests();
            var NewOrganization = OrganizationsTests.CreateOrganization();

            var ContactsTests = new ContactsServiceFunctionalTests();
            var Contact = ContactsTests.CreateContact(NewCustomer, NewOrganization);


            var PaymentCardsTests = new PaymentCardsServiceFunctionalTests();
            var NewPaymentCard = PaymentCardsTests.CreatePaymentCard(NewCustomer, Contact);

            var NewPaymentCardToken = CreateCreditCardPaymentCardToken(NewCustomer, Contact, NewPaymentCard, useRebillySignagure: true);
            Assert.IsNotNull(NewPaymentCardToken.Id);

            // Load
            var PaymentCardTokensService = CreateClient().PaymentCardTokens();
            var LoadedPaymentCardToken = PaymentCardTokensService.Load(NewPaymentCardToken.Id);
            Assert.AreEqual(NewPaymentCardToken.Id, LoadedPaymentCardToken.Id);


            // Expire
            var ExpiredResponse = PaymentCardTokensService.Expire(NewPaymentCardToken.Id);
            Assert.IsNotNull(ExpiredResponse.Id);

        }


        public PaymentCardToken CreateCreditCardPaymentCardToken(Customer customer, Contact contact, PaymentCard paymentCard, bool useRebillySignagure = false)
        {
            var NewPaymentCardToken = new PaymentCardToken();
            NewPaymentCardToken.Method = "payment-card";

            var NewPaymentInstrument = new PaymentTokenInstrument()
            {
                Pan = "4111111111111111",   // PaymentCardsServiceFunctionalTests.CreatePaymentCard always create a card with a Pan of 4111111111111111
                ExpMonth = paymentCard.ExpMonth,
                ExpYear = paymentCard.ExpYear,
                Cvv = paymentCard.Cvv
            };

            NewPaymentCardToken.PaymentInstrument = NewPaymentInstrument;
            NewPaymentCardToken.FirstName = contact.FirstName;
            NewPaymentCardToken.LastName = contact.LastName;
         

            var PaymentCardTokensService = CreateClient().PaymentCardTokens();

            return PaymentCardTokensService.Create(NewPaymentCardToken);
        }
    }
}
