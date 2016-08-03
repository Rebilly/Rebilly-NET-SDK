using NUnit.Framework;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class PaymentInstrumentUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            Assert.IsInstanceOf<PaymentInstrument>(CurrentPaymentInstrument);
        }


        [Test]
        public void TestPanDefaultIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            Assert.IsNull(CurrentPaymentInstrument.Pan);
        }


        [Test]
        public void TestPanIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            CurrentPaymentInstrument.Pan = "Pan1";
            Assert.AreEqual("Pan1", CurrentPaymentInstrument.Pan);
        }


        [Test]
        public void TestExpMonthDefaultIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            Assert.AreEqual(0,CurrentPaymentInstrument.ExpMonth);
        }


        [Test]
        public void TestExpMonthIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            CurrentPaymentInstrument.ExpMonth = 3;
            Assert.AreEqual(3, CurrentPaymentInstrument.ExpMonth);
        }


        [Test]
        public void TestExpYearDefaultIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            Assert.AreEqual(0, CurrentPaymentInstrument.ExpYear);
        }


        [Test]
        public void TestExpYearIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            CurrentPaymentInstrument.ExpYear = 2018;
            Assert.AreEqual(2018, CurrentPaymentInstrument.ExpYear);
        }


        [Test]
        public void TestCvvDefaultIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            Assert.IsNull(CurrentPaymentInstrument.Cvv);
        }


        [Test]
        public void TestCvvIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            CurrentPaymentInstrument.Cvv = "Cvv1";
            Assert.AreEqual("Cvv1", CurrentPaymentInstrument.Cvv);
        }


        [Test]
        public void TestRoutingNumberDefaultIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            Assert.AreEqual(0, CurrentPaymentInstrument.RoutingNumber);
        }


        [Test]
        public void TestRoutingNumberIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            CurrentPaymentInstrument.RoutingNumber = 2018;
            Assert.AreEqual(2018, CurrentPaymentInstrument.RoutingNumber);
        }


        [Test]
        public void TestAccountNumberDefaultIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            Assert.AreEqual(0, CurrentPaymentInstrument.AccountNumber);
        }


        [Test]
        public void TestAccountNumberIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            CurrentPaymentInstrument.AccountNumber = 2018;
            Assert.AreEqual(2018, CurrentPaymentInstrument.AccountNumber);
        }


        [Test]
        public void TestAccountTypeDefaultIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            Assert.IsNull(CurrentPaymentInstrument.AccountType);
        }


        [Test]
        public void TestAccountTypeIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            CurrentPaymentInstrument.AccountType = "AccountType1";
            Assert.AreEqual("AccountType1", CurrentPaymentInstrument.AccountType);
        }


        [Test]
        public void TestBankNameDefaultIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            Assert.IsNull(CurrentPaymentInstrument.BankName);
        }


        [Test]
        public void TestBankNameIsEqualTo()
        {
            var CurrentPaymentInstrument = new PaymentInstrument();
            CurrentPaymentInstrument.BankName = "BankName1";
            Assert.AreEqual("BankName1", CurrentPaymentInstrument.BankName);
        }
    }
}
