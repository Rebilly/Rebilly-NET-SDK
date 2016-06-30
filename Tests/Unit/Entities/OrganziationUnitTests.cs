using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class OrganizationUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var Organization = new Organization();
            Assert.IsInstanceOf<Entity>(Organization);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var Organization = new Organization();
            Assert.IsNull(Organization.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var Organization = new Organization();
            Organization.Id = "test1";
            Assert.AreEqual("test1", Organization.Id);
        }


        [Test]
        public void TestNameDefaultIsEqualTo()
        {
            var Organization = new Organization();
            Assert.IsNull(Organization.Name);
        }


        [Test]
        public void TestNameIsEqualTo()
        {
            var Organization = new Organization();
            Organization.Name = "test2";
            Assert.AreEqual("test2", Organization.Name);
        }


        [Test]
        public void TestAddressDefaultIsEqualTo()
        {
            var Organization = new Organization();
            Assert.IsNull(Organization.Address);
        }


        [Test]
        public void TestAddressIsEqualTo()
        {
            var Organization = new Organization();
            Organization.Address = "Address2";
            Assert.AreEqual("Address2", Organization.Address);
        }


        [Test]
        public void TestAddress2DefaultIsEqualTo()
        {
            var Organization = new Organization();
            Assert.IsNull(Organization.Address2);
        }


        [Test]
        public void TestAddress2IsEqualTo()
        {
            var Organization = new Organization();
            Organization.Address2 = "Address3";
            Assert.AreEqual("Address3", Organization.Address2);
        }


        [Test]
        public void TestCityDefaultIsEqualTo()
        {
            var Organization = new Organization();
            Assert.IsNull(Organization.City);
        }


        [Test]
        public void TestCityIsEqualTo()
        {
            var Organization = new Organization();
            Organization.City = "Santa Barbara";
            Assert.AreEqual("Santa Barbara", Organization.City);
        }


        [Test]
        public void TestCountryDefaultIsEqualTo()
        {
            var Organization = new Organization();
            Assert.IsNull(Organization.Country);
        }


        [Test]
        public void TestCountryIsEqualTo()
        {
            var Organization = new Organization();
            Organization.Country = "US";
            Assert.AreEqual("US", Organization.Country);
        }


        [Test]
        public void TestPostalCodeDefaultIsEqualTo()
        {
            var Organization = new Organization();
            Assert.IsNull(Organization.PostalCode);
        }


        [Test]
        public void TestPostalCodeIsEqualTo()
        {
            var Organization = new Organization();
            Organization.PostalCode = "2342";
            Assert.AreEqual("2342", Organization.PostalCode);
        }


    }
}
