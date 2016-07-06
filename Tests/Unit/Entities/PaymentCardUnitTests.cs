using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class PaymentCardUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsInstanceOf<Entity>(PaymentCard);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.Id = "test1";
            Assert.AreEqual("test1", PaymentCard.Id);
        }


        [Test]
        public void TestCustomerIdDefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.CustomerId);
        }


        [Test]
        public void TestCustomerIdIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.CustomerId = "CustomerId1";
            Assert.AreEqual("CustomerId1", PaymentCard.CustomerId);
        }


        [Test]
        public void TestPanDefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.Pan);
        }


        [Test]
        public void TestPanIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.Pan = "Pan1";
            Assert.AreEqual("Pan1", PaymentCard.Pan);
        }


        [Test]
        public void TestExpYearDefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.ExpYear);
        }


        [Test]
        public void TestExpYearIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.ExpYear = "ExpYear12";
            Assert.AreEqual("ExpYear12", PaymentCard.ExpYear);
        }


        [Test]
        public void TestExpMonthDefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.ExpMonth);
        }


        [Test]
        public void TestExpMonthIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.ExpMonth = "ExpMonth123";
            Assert.AreEqual("ExpMonth123", PaymentCard.ExpMonth);
        }


        [Test]
        public void TestCvvDefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.Cvv);
        }


        [Test]
        public void TestCvvIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.Cvv = "123";
            Assert.AreEqual("123", PaymentCard.Cvv);
        }


        [Test]
        public void TestBillingContactIdDefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.BillingContactId);
        }


        [Test]
        public void TestBillingContactIdIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.BillingContactId = "BillingContactId123";
            Assert.AreEqual("BillingContactId123", PaymentCard.BillingContactId);
        }


        [Test]
        public void TestLast4DefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.Last4);
        }


        [Test]
        public void TestLast4IsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.Last4 = "Last4";
            Assert.AreEqual("Last4", PaymentCard.Last4);
        }


        [Test]
        public void TestBrandDefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.Brand);
        }


        [Test]
        public void TestBrandIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.Brand = "Brand";
            Assert.AreEqual("Brand", PaymentCard.Brand);
        }


        [Test]
        public void TestCustomerDefaultIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            Assert.IsNull(PaymentCard.Customer);
        }


        [Test]
        public void TestCustomerIsEqualTo()
        {
            var PaymentCard = new PaymentCard();
            PaymentCard.Customer = "Customer";
            Assert.AreEqual("Customer", PaymentCard.Customer);
        }
    }
}
