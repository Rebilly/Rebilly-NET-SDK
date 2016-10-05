using NUnit.Framework;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class ThreeDSecureUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsInstanceOf<ThreeDSecure>(CurrentThreeDSecure);
        }


        [Test]
        public void TestCustomerIdDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.CustomerId);
        }


        [Test]
        public void TestCustomerIdIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.CustomerId = "CustomerId3";
            Assert.AreEqual("CustomerId3", CurrentThreeDSecure.CustomerId);
        }


        [Test]
        public void TestGatewayAccountIdDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.GatewayAccountId);
        }


        [Test]
        public void TestGatewayAccountIdIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.GatewayAccountId = "GatewayAccountId3";
            Assert.AreEqual("GatewayAccountId3", CurrentThreeDSecure.GatewayAccountId);
        }


        [Test]
        public void TestPaymentCardIdDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.PaymentCardId);
        }


        [Test]
        public void TestPaymentCardIdIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.PaymentCardId = "PaymentCardId3";
            Assert.AreEqual("PaymentCardId3", CurrentThreeDSecure.PaymentCardId);
        }


        [Test]
        public void TestWebsiteIdDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.WebsiteId);
        }


        [Test]
        public void TestWebsiteIdIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.WebsiteId = "WebsiteId3";
            Assert.AreEqual("WebsiteId3", CurrentThreeDSecure.WebsiteId);
        }


        [Test]
        public void TestEnrolledDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.Enrolled);
        }


        [Test]
        public void TestEnrolledIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.Enrolled = "Y";
            Assert.AreEqual("Y", CurrentThreeDSecure.Enrolled);
        }


        [Test]
        public void TestEnrollmentEciDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.EnrollmentEci);
        }


        [Test]
        public void TestEnrollmentEciIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.EnrollmentEci = "123Y";
            Assert.AreEqual("123Y", CurrentThreeDSecure.EnrollmentEci);
        }


        [Test]
        public void TestEciDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.AreEqual(0, CurrentThreeDSecure.Eci);
        }


        [Test]
        public void TestEciIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.Eci = 123;
            Assert.AreEqual(123, CurrentThreeDSecure.Eci);
        }


        [Test]
        public void TestCavvDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.Cavv);
        }


        [Test]
        public void TestCavvIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.Cavv = "asdf123";
            Assert.AreEqual("asdf123", CurrentThreeDSecure.Cavv);
        }


        [Test]
        public void TestXidDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.Xid);
        }


        [Test]
        public void TestXidIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.Xid = "asdf123";
            Assert.AreEqual("asdf123", CurrentThreeDSecure.Xid);
        }


        [Test]
        public void TestPayerAuthResponseStatusDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.PayerAuthResponseStatus);
        }


        [Test]
        public void TestPayerAuthResponseStatusIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.PayerAuthResponseStatus = "asda";
            Assert.AreEqual("asda", CurrentThreeDSecure.PayerAuthResponseStatus);
        }


        [Test]
        public void TestSignatureVerificationDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.SignatureVerification);
        }


        [Test]
        public void TestSignatureVerificationIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.SignatureVerification = "asda";
            Assert.AreEqual("asda", CurrentThreeDSecure.SignatureVerification);
        }


        [Test]
        public void TestAmountDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.AreEqual(0.0, CurrentThreeDSecure.Amount);
        }


        [Test]
        public void TestAmountIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.Amount = 123.1;
            Assert.AreEqual(123.1, CurrentThreeDSecure.Amount);
        }


        [Test]
        public void TestCurrencyDefaultIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            Assert.IsNull(CurrentThreeDSecure.Currency);
        }


        [Test]
        public void TestCurrencyIsEqualTo()
        {
            var CurrentThreeDSecure = new ThreeDSecure();
            CurrentThreeDSecure.Currency = "asda";
            Assert.AreEqual("asda", CurrentThreeDSecure.Currency);
        }
    }
}
