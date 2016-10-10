using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class CustomerUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var Customer = new Customer();
            Assert.IsInstanceOf<Entity>(Customer);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var Customer = new Customer();
            Assert.IsNull(Customer.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var Customer = new Customer();
            Customer.Id = "test1";
            Assert.AreEqual("test1", Customer.Id);
        }


        [Test]
        public void TestEmailDefaultIsEqualTo()
        {
            var Customer = new Customer();
            Assert.IsNull(Customer.Email);
        }


        [Test]
        public void TestEmailsEqualTo()
        {
            var Customer = new Customer();
            Customer.Email = "Email1";
            Assert.AreEqual("Email1", Customer.Email);
        }


        [Test]
        public void TestFirstNameDefaultIsEqualTo()
        {
            var Customer = new Customer();
            Assert.IsNull(Customer.FirstName);
        }


        [Test]
        public void TestFirstNamesEqualTo()
        {
            var Customer = new Customer();
            Customer.FirstName = "FirstName1";
            Assert.AreEqual("FirstName1", Customer.FirstName);
        }


        [Test]
        public void TestLastNameDefaultIsEqualTo()
        {
            var Customer = new Customer();
            Assert.IsNull(Customer.LastName);
        }


        [Test]
        public void TestLastNamesEqualTo()
        {
            var Customer = new Customer();
            Customer.LastName = "LastName2";
            Assert.AreEqual("LastName2", Customer.LastName);
        }


        [Test]
        public void TestIpAddressDefaultIsEqualTo()
        {
            var Customer = new Customer();
            Assert.IsNull(Customer.IpAddress);
        }


        [Test]
        public void TestIpAddresssEqualTo()
        {
            var Customer = new Customer();
            Customer.IpAddress = "IpAddress2";
            Assert.AreEqual("IpAddress2", Customer.IpAddress);
        }


        [Test]
        public void TestDefaultPaymentInstrumentDefaultIsEqualTo()
        {
            var Customer = new Customer();
            Assert.IsNull(Customer.DefaultPaymentInstrument);
        }


        [Test]
        public void TestDefaultPaymentInstrumentIsEqualTo()
        {
            var Customer = new Customer();
            var CurrentPaymentInstrument  = new AchPaymentInstrument();

            Customer.DefaultPaymentInstrument = CurrentPaymentInstrument;
            Assert.AreEqual(CurrentPaymentInstrument, Customer.DefaultPaymentInstrument);
        }       
    }
}
