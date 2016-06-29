using NUnit.Framework;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class A1A1GatewayConfigUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            Assert.IsInstanceOf<GatewayConfig>(CurrentA1GatewayConfig);
        }


        [Test]
        public void TestMemberIdDefaultIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            Assert.IsNull(CurrentA1GatewayConfig.MemberId);
        }


        [Test]
        public void TestMemberIdIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            CurrentA1GatewayConfig.MemberId = "MemberId1";
            Assert.AreEqual("MemberId1", CurrentA1GatewayConfig.MemberId);
        }


        [Test]
        public void TestAVSDefaultIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            Assert.AreEqual(0,CurrentA1GatewayConfig.AVS);
        }


        [Test]
        public void TestAVSIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            CurrentA1GatewayConfig.AVS = 123;
            Assert.AreEqual(123, CurrentA1GatewayConfig.AVS);
        }


        [Test]
        public void TestDelayDefaultIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            Assert.AreEqual(0, CurrentA1GatewayConfig.Delay);
        }


        [Test]
        public void TestDelayIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            CurrentA1GatewayConfig.Delay = 12;
            Assert.AreEqual(12, CurrentA1GatewayConfig.Delay);
        }


        [Test]
        public void TestAccountIdDefaultIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            Assert.IsNull(CurrentA1GatewayConfig.AccountId);
        }


        [Test]
        public void TestAccountIdIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            CurrentA1GatewayConfig.AccountId = "AccountId1";
            Assert.AreEqual("AccountId1", CurrentA1GatewayConfig.AccountId);
        }


        [Test]
        public void TestPasswordDefaultIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            Assert.IsNull(CurrentA1GatewayConfig.Password);
        }


        [Test]
        public void TestPasswordIsEqualTo()
        {
            var CurrentA1GatewayConfig = new A1GatewayConfig();
            CurrentA1GatewayConfig.Password = "Password1";
            Assert.AreEqual("Password1", CurrentA1GatewayConfig.Password);
        }
    
    }
}
