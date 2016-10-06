using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class ThreedDSecuresServiceFunctionalTest : TestBase
    {
        [Test]
        public void TestCreate()
        {
            var OrganizationsTests = new OrganizationsServiceFunctionalTests();
            var NewOrganization = OrganizationsTests.CreateOrganization();

            var WebsitesTests = new WebsitesServiceFunctionalTests();
            var NewWebsite = WebsitesTests.CreateWebsite();

            var GatewayAccountsTest = new GatewayAccountsServiceFunctionalTests();
            var GatewayAccount = GatewayAccountsTest.CreateGatewayAccount(NewOrganization, NewWebsite);

            var CustomersTests = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTests.CreateCustomer();

            var ContactsTests = new ContactsServiceFunctionalTests();
            var Contact = ContactsTests.CreateContact(NewCustomer, NewOrganization);

            var PaymentCardsService = new PaymentCardsServiceFunctionalTests();

            var NewPaymentCard = PaymentCardsService.CreatePaymentCard(NewCustomer, Contact);

            // TODO: obtain an example usage
            //var NewThreeDSecure = CreateThreeDSecure(NewCustomer, GatewayAccount, NewPaymentCard, NewWebsite);
            //Assert.IsNotNull(NewThreeDSecure);

        }

        public ThreeDSecure CreateThreeDSecure(Customer customer, GatewayAccount gatewayAccount, PaymentCard paymentCard, Website website)
        {
            var NewThreeDSecure = new ThreeDSecure()
            {
                CustomerId = customer.Id,
                GatewayAccountId = gatewayAccount.Id,
                PaymentCardId = paymentCard.Id,
                WebsiteId = website.Id,
                Enrolled = "Y",
                EnrollmentEci = "ABC",
                Amount = 101.11,
                Currency = "usd"
            };


            var RebillyClient = CreateClient();
            return RebillyClient.ThreeDSecures().Create(NewThreeDSecure);
        }
    }
}