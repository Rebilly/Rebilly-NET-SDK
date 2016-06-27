using NUnit.Framework;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class WebsiteUnitTests
    {
        [Test]                    
        public void TestConstructIsInstanceOfEntity()
        {
            var Website = new Website();
            Assert.IsInstanceOf<Entity>(Website);
        }


        [Test]        
        public void TestIdDefaultIsEqualTo()
        {
            var Website = new Website();
            Assert.IsNull(Website.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var Website = new Website();
            Website.Id = "test1";
            Assert.AreEqual("test1", Website.Id);
        }


        [Test]
        public void TestNameDefaultIsEqualTo()
        {
            var Website = new Website();
            Assert.IsNull(Website.Name);
        }


        [Test]
        public void TestNameIsEqualTo()
        {
            var Website = new Website();
            Website.Name = "test2";
            Assert.AreEqual("test2", Website.Name);
        }


        [Test]
        public void TestUrlDefaultIsEqualTo()
        {
            var Website = new Website();
            Assert.IsNull(Website.Url);
        }


        [Test]
        public void TestUrlIsEqualTo()
        {
            var Website = new Website();
            Website.Url = "testing.com";
            Assert.AreEqual("testing.com", Website.Url);
        }


        [Test]
        public void TestServicePhoneDefaultIsEqualTo()
        {
            var Website = new Website();
            Assert.IsNull(Website.ServicePhone);
        }


        [Test]
        public void TestServicePhoneIsEqualTo()
        {
            var Website = new Website();
            Website.ServicePhone = "802-234-2344";
            Assert.AreEqual("802-234-2344", Website.ServicePhone);
        }
    }
}
