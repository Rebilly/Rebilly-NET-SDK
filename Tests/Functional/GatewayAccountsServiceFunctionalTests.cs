using System.Collections.Generic;

using NUnit.Framework;
using Rebilly;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class GatewayAccountsServiceFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateRetrieveListDelete()
        {
            
            // TODO: Create new GatewayAccount
            var TestGatewayAccount = new GatewayAccount()
            {
                GatewayName = "A1Gateway",
                GatewayConfig = new GatewayConfig() { MemberId = "123", Password = "123123" },
                Method = "payment_card",
                PaymentCardSchemes = new List<string>() { "Visa", "MasterCard"},
                OrganizationId = "TestOrganziation",
                ThreeDSecure = false,
                DynamicDescriptor = false,
                MerchantCategoryCode =  5966,
                AcquirerName =  "Test Acq",
                Descriptor = "MyDescriptor",
                City = "MyCity",
                Websites = new List<string>(){ "WebSite1", "WebSite2"},
                AcceptedCurrencies = new List<string>(){"USD"}
    

            };

            var RebillyClient = CreateClient();
            var NewGatewayAccount = RebillyClient.GatewayAccounts().Create(TestGatewayAccount);

            // List the new accounts
            var Gateways = RebillyClient.GatewayAccounts();
        }
    }
}
