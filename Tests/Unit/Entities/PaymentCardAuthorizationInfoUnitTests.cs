using NUnit.Framework;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class PaymentCardAuthorizationInfoUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var CurrenPaymentCardAuthorizationInfo = new PaymentCardAuthorizationInfo();
            Assert.IsInstanceOf<PaymentCardAuthorizationInfo>(CurrenPaymentCardAuthorizationInfo);
        }


        [Test]
        public void TestCardIdDefaultIsEqualTo()
        {
            var CurrenPaymentCardAuthorizationInfo = new PaymentCardAuthorizationInfo();
            Assert.IsNull(CurrenPaymentCardAuthorizationInfo.CardId);
        }

        [Test]
        public void TestCardIdAreEqualTo()
        {
            var CurrenPaymentCardAuthorizationInfo = new PaymentCardAuthorizationInfo();
            CurrenPaymentCardAuthorizationInfo.CardId = "USD";
            Assert.AreEqual("USD", CurrenPaymentCardAuthorizationInfo.CardId);
        }


        [Test]
        public void TestCurrencyDefaultIsEqualTo()
        {
            var CurrenPaymentCardAuthorizationInfo = new PaymentCardAuthorizationInfo();
            Assert.IsNull(CurrenPaymentCardAuthorizationInfo.Currency);
        }   

        [Test]
        public void TestCurrencyAreEqualTo()
        {
            var CurrenPaymentCardAuthorizationInfo = new PaymentCardAuthorizationInfo();
            CurrenPaymentCardAuthorizationInfo.Currency = "USD";
            Assert.AreEqual("USD", CurrenPaymentCardAuthorizationInfo.Currency);
        }


        [Test]
        public void TestWebsiteIdDefaultIsEqualTo()
        {
            var CurrenPaymentCardAuthorizationInfo = new PaymentCardAuthorizationInfo();
            Assert.IsNull(CurrenPaymentCardAuthorizationInfo.WebsiteId);
        }

        [Test]
        public void TestWebsiteIdAreEqualTo()
        {
            var CurrenPaymentCardAuthorizationInfo = new PaymentCardAuthorizationInfo();
            CurrenPaymentCardAuthorizationInfo.WebsiteId = "USD";
            Assert.AreEqual("USD", CurrenPaymentCardAuthorizationInfo.WebsiteId);
        }

    }
}
