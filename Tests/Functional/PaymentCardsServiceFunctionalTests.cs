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
        public void TestCreateUpdateLoadDelete()
        {
            // Create

            //var NewPaymentCard = CreatePaymentCard();

            //Assert.IsNotNull(NewPaymentCard);
        }

        public PaymentCard CreatePaymentCard()
        {
            var CustomersTests = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTests.CreateCustomer();

            var OrganizationsTests = new OrganizationsServiceFunctionalTests();
            var NewOrganization = OrganizationsTests.CreateOrganization();

            var ContactsTests = new ContactsServiceFunctionalTests();
            var Contact = ContactsTests.CreateContact(NewCustomer, NewOrganization);

            var NewPaymentCard = new PaymentCard();
            NewPaymentCard.CustomerId = NewCustomer.Id;
            NewPaymentCard.BillingContactId = Contact.Id;
            //NewPaymentCard.Pan

            var PaymentCardsServies = CreateClient().PaymentCards();
            return PaymentCardsServies.Create(NewPaymentCard);
        }
    }
}
