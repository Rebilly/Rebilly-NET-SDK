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
    }
}
