using NUnit.Framework;
using Rebilly.Entities;


namespace Tests.Unit.Entities
{
    [TestFixture]
    public class GatewayConfigUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            Assert.IsNotNull(CurrentGatewayConfig);
        }


        [Test]
        public void TestMemberIdDefaultIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            Assert.IsNull(CurrentGatewayConfig.MemberId);
        }


        [Test]
        public void TestMemberIdIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            CurrentGatewayConfig.MemberId = "MemberId1";
            Assert.AreEqual("MemberId1", CurrentGatewayConfig.MemberId);
        }


        [Test]
        public void TestAVSDefaultIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            Assert.AreEqual(0,CurrentGatewayConfig.AVS);
        }


        [Test]
        public void TestAVSIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            CurrentGatewayConfig.AVS = 123;
            Assert.AreEqual(123, CurrentGatewayConfig.AVS);
        }


        [Test]
        public void TestDelayDefaultIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            Assert.AreEqual(0, CurrentGatewayConfig.Delay);
        }


        [Test]
        public void TestDelayIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            CurrentGatewayConfig.Delay = 12;
            Assert.AreEqual(12, CurrentGatewayConfig.Delay);
        }


        [Test]
        public void TestAccountIdDefaultIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            Assert.IsNull(CurrentGatewayConfig.AccountId);
        }


        [Test]
        public void TestAccountIdIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            CurrentGatewayConfig.AccountId = "AccountId1";
            Assert.AreEqual("AccountId1", CurrentGatewayConfig.AccountId);
        }


        [Test]
        public void TestPasswordDefaultIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            Assert.IsNull(CurrentGatewayConfig.Password);
        }


        [Test]
        public void TestPasswordIsEqualTo()
        {
            var CurrentGatewayConfig = new GatewayConfig();
            CurrentGatewayConfig.Password = "Password1";
            Assert.AreEqual("Password1", CurrentGatewayConfig.Password);
        }
    
    }
}
