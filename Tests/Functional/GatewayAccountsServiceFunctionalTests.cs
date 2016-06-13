using NUnit.Framework;
using Rebilly;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class GatewayAccountsServiceFunctionalTests
    {
        [Test]
        public void TestCreateUpdateRetrieveListDelete()
        {
            var Config = new TestConfig();

            // Create new GatewayAccount

            var RebillyClient = new Client(apiKey: Config.RebillyApiKey);



            // List the new accounts
            var GatewayCounts = RebillyClient.GatewayAccounts();
        }
    }
}
