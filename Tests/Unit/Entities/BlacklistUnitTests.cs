using System;
using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class BlacklistUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var Blacklist = new Blacklist();
            Assert.IsInstanceOf<Entity>(Blacklist);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var Blacklist = new Blacklist();
            Assert.IsNull(Blacklist.Id);
        }

        [Test]
        public void TestIdIsEqualTo()
        {
            var Blacklist = new Blacklist();
            Blacklist.Id = "test2";
            Assert.AreEqual("test2", Blacklist.Id);
        }


        [Test]
        public void TestTypeDefaultIsEqualTo()
        {
            var Blacklist = new Blacklist();
            Assert.IsNull(Blacklist.Type);
        }


        [Test]
        public void TestTypeIsEqualTo()
        {
            var Blacklist = new Blacklist();
            Blacklist.Type = "customerId";
            Assert.AreEqual("customerId", Blacklist.Type);
        }


        [Test]
        public void TestTtlDefaultIsEqualTo()
        {
            var Blacklist = new Blacklist();
            Assert.AreEqual(0,Blacklist.Ttl);
        }


        [Test]
        public void TestTtlIsEqualTo()
        {
            var Blacklist = new Blacklist();
            Blacklist.Ttl = 123;
            Assert.AreEqual(123, Blacklist.Ttl);
        }


        [Test]
        public void TestExpireTimeDefaultIsEqualTo()
        {
            var Blacklist = new Blacklist();
            Assert.IsNull(Blacklist.ExpireTime);
        }


        [Test]
        public void TestExpireTimeIsEqualTo()
        {
            var Blacklist = new Blacklist();
            Blacklist.ExpireTime = DateTime.Parse("2017-02-11 03:01:01");
            Assert.AreEqual("2017-02-11 03:01:01", Blacklist.ExpireTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}
