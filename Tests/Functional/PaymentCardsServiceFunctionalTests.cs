using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class PaymentCardsServiceFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateLoadDelete()
        {
        }

        public PaymentCard CreatePaymentCard()
        {
            var NewPaymentCard = new PaymentCard();

            var PaymentCardsServies = CreateClient().PaymentCards();
            return PaymentCardsServies.Create(NewPaymentCard);
        }
    }
}
