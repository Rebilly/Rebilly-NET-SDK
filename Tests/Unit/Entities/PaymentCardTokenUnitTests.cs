using System;
using NUnit.Framework;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class PaymentCardTokenUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsInstanceOf<Entity>(PaymentCardToken);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.Id = "test1";
            Assert.AreEqual("test1", PaymentCardToken.Id);
        }


        [Test]
        public void TestMethodDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.Method);
        }


        [Test]
        public void TestMethodIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.Method = "Method1";
            Assert.AreEqual("Method1", PaymentCardToken.Method);
        }


        [Test]
        public void TestPaymentInstrumentDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.PaymentInstrument);
        }


        [Test]
        public void TestPaymentInstrumentIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();

            var NewPaymentInstrument = new PaymentTokenInstrument();
            PaymentCardToken.PaymentInstrument = NewPaymentInstrument;

            Assert.AreEqual(NewPaymentInstrument, PaymentCardToken.PaymentInstrument);
        }


        [Test]
        public void TestFirstNameDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.FirstName);
        }


        [Test]
        public void TestFirstNameIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.FirstName = "FirstName1";
            Assert.AreEqual("FirstName1", PaymentCardToken.FirstName);
        }


        [Test]
        public void TestLastNameDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.LastName);
        }


        [Test]
        public void TestLastNameIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.LastName = "LastName1";
            Assert.AreEqual("LastName1", PaymentCardToken.LastName);
        }


        [Test]
        public void TestAddressDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.Address);
        }


        [Test]
        public void TestAddressIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.Address = "Address1";
            Assert.AreEqual("Address1", PaymentCardToken.Address);
        }


        [Test]
        public void TestAddress2DefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.Address2);
        }


        [Test]
        public void TestAddress2IsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.Address2 = "Address21";
            Assert.AreEqual("Address21", PaymentCardToken.Address2);
        }


        [Test]
        public void TestCityDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.City);
        }


        [Test]
        public void TestCityIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.City = "City1";
            Assert.AreEqual("City1", PaymentCardToken.City);
        }


        [Test]
        public void TestCountryDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.Country);
        }


        [Test]
        public void TestCountryIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.Country = "Country1";
            Assert.AreEqual("Country1", PaymentCardToken.Country);
        }


        [Test]
        public void TestPhoneNumberDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.PhoneNumber);
        }


        [Test]
        public void TestPhoneNumberIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.PhoneNumber = "PhoneNumber1";
            Assert.AreEqual("PhoneNumber1", PaymentCardToken.PhoneNumber);
        }


        [Test]
        public void TestPostalCodeDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.PostalCode);
        }


        [Test]
        public void TestPostalCodeIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.PostalCode = "PostalCode1";
            Assert.AreEqual("PostalCode1", PaymentCardToken.PostalCode);
        }


        [Test]
        public void TestFingerprintDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.Fingerprint);
        }


        [Test]
        public void TestFingerprintIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.Fingerprint = "Fingerprint1";
            Assert.AreEqual("Fingerprint1", PaymentCardToken.Fingerprint);
        }


        [Test]
        public void TestExpiredTimeDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.ExpiredTime);
        }


        [Test]
        public void TestExpiredTimeIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.ExpiredTime = DateTime.Parse("2017-02-11 03:01:01");
            Assert.AreEqual("2017-02-11 03:01:01", PaymentCardToken.ExpiredTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }


        [Test]
        public void TestUsedTimeDefaultIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            Assert.IsNull(PaymentCardToken.UsedTime);
        }


        [Test]
        public void TestUsedTimeIsEqualTo()
        {
            var PaymentCardToken = new PaymentCardToken();
            PaymentCardToken.UsedTime = DateTime.Parse("2017-02-11 03:01:01");
            Assert.AreEqual("2017-02-11 03:01:01", PaymentCardToken.UsedTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}
