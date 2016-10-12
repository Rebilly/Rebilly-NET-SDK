using NUnit.Framework;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class SubscriptionCancelPolicyUnitTests
    {
        [Test]
        public void TestConstructIsNotNull()
        {
            var CurrentSubscriptionCancelPolicy = new SubscriptionCancelPolicy();
            Assert.IsInstanceOf<GatewayConfig>(CurrentSubscriptionCancelPolicy);
        }


        [Test]
        public void TestPolicyDefaultIsEqualTo()
        {
            var CurrentSubscriptionCancelPolicy = new SubscriptionCancelPolicy();
            Assert.IsEmpty(CurrentSubscriptionCancelPolicy.Policy);
        }


        [Test]
        public void TestPolicySetIsEqualTo()
        {
            var CurrentSubscriptionCancelPolicy = new SubscriptionCancelPolicy();
            CurrentSubscriptionCancelPolicy.Policy = "now-with-prorata-credit";

            Assert.IsEmpty("now-with-prorata-credit",CurrentSubscriptionCancelPolicy.Policy);
        }
    }
}