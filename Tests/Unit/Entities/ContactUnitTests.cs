using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class ContactUnitTests
    {
        [Test]                    
        public void TestConstructIsInstanceOfEntity()
        {
            var Contact = new Contact();
            Assert.IsInstanceOf<Entity>(Contact);
        }


        [Test]        
        public void TestIdDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var Contact = new Contact();
            Contact.Id = "test1";
            Assert.AreEqual("test1", Contact.Id);
        }


        [Test]
        public void TestCustomerIdDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.CustomerId);
        }


        [Test]
        public void TestCustomerIdIsEqualTo()
        {
            var Contact = new Contact();
            Contact.CustomerId = "CustomerId1";
            Assert.AreEqual("CustomerId1", Contact.CustomerId);
        }


        [Test]
        public void TestFirstNameDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.FirstName);
        }


        [Test]
        public void TestFirstNameIsEqualTo()
        {
            var Contact = new Contact();
            Contact.FirstName = "FirstName1";
            Assert.AreEqual("FirstName1", Contact.FirstName);
        }


        [Test]
        public void TestLastNameDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.LastName);
        }


        [Test]
        public void TestLastNameIsEqualTo()
        {
            var Contact = new Contact();
            Contact.LastName = "LastName1";
            Assert.AreEqual("LastName1", Contact.LastName);
        }


        [Test]
        public void TestOrganizationDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.Organization);
        }


        [Test]
        public void TestOrganizationIsEqualTo()
        {
            var Contact = new Contact();
            Contact.Organization = "Organization1";
            Assert.AreEqual("Organization1", Contact.Organization);
        }


        [Test]
        public void TestAddressDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.Address);
        }


        [Test]
        public void TestAddressIsEqualTo()
        {
            var Contact = new Contact();
            Contact.Address = "Address1";
            Assert.AreEqual("Address1", Contact.Address);
        }


        [Test]
        public void TestAddress2DefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.Address2);
        }


        [Test]
        public void TestAddress2IsEqualTo()
        {
            var Contact = new Contact();
            Contact.Address2 = "Address21";
            Assert.AreEqual("Address21", Contact.Address2);
        }


        [Test]
        public void TestCityDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.Address2);
        }


        [Test]
        public void TestCityIsEqualTo()
        {
            var Contact = new Contact();
            Contact.City = "City1";
            Assert.AreEqual("City1", Contact.City);
        }


        [Test]
        public void TestRegionDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.Region);
        }


        [Test]
        public void TestRegionIsEqualTo()
        {
            var Contact = new Contact();
            Contact.Region = "Region1";
            Assert.AreEqual("Region1", Contact.Region);
        }


        [Test]
        public void TestCountryDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.Address2);
        }


        [Test]
        public void TestCountryIsEqualTo()
        {
            var Contact = new Contact();
            Contact.Country = "Country1";
            Assert.AreEqual("Country1", Contact.Country);
        }


        [Test]
        public void TestPostalCodeDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.Address2);
        }


        [Test]
        public void TestPostalCodeIsEqualTo()
        {
            var Contact = new Contact();
            Contact.PostalCode = "PostalCode1";
            Assert.AreEqual("PostalCode1", Contact.PostalCode);
        }


        [Test]
        public void TestPhoneNumberDefaultIsEqualTo()
        {
            var Contact = new Contact();
            Assert.IsNull(Contact.PhoneNumber);
        }


        [Test]
        public void TestPhoneNumberIsEqualTo()
        {
            var Contact = new Contact();
            Contact.PhoneNumber = "PhoneNumber1";
            Assert.AreEqual("PhoneNumber1", Contact.PhoneNumber);
        } 
    
    }
}
