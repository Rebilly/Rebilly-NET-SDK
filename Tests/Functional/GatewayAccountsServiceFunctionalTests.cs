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
        public void TestCreateUpdateLoadSearchDelete()
        {

            var OrganizationsTests = new OrganizationsServiceFunctionalTests();
            var NewOrganization = OrganizationsTests.CreateOrganizaion();

            var WebsitesTests = new WebsitesServiceFunctionalTests();
            var NewWebsite = WebsitesTests.CreateWebsite();


            // TODO: Create new GatewayAccount
            var NewGatewayAccount = new GatewayAccount()
            {
                GatewayName = "A1Gateway",
                GatewayConfig = new A1GatewayConfig() { MemberId = "123", Password = "123123", AccountId = "12312", AVS = 12, Delay = 1232 },
                Method = "payment_card",
                PaymentCardSchemes = new List<string>() { "Visa", "MasterCard"},
                OrganizationId = NewOrganization.Id,
                ThreeDSecure = false,
                DynamicDescriptor = false,
                MerchantCategoryCode =  5966,
                AcquirerName = "CIM",
                Descriptor = "MyDescriptor",
                City = "MyCity",
                Websites = new List<string>() { NewWebsite.Id},
                AcceptedCurrencies = new List<string>(){"USD"}
            };

            var RebillyClient = CreateClient();
            var GatewayAccounts = RebillyClient.GatewayAccounts();

            var CreatedGatewayAccount = GatewayAccounts.Create(NewGatewayAccount);

            Assert.IsNotEmpty(CreatedGatewayAccount.Id);
            Assert.AreEqual(CreatedGatewayAccount.GatewayName, "A1Gateway");
            Assert.AreEqual(((A1GatewayConfig)CreatedGatewayAccount.GatewayConfig).MemberId, "123");
            Assert.AreEqual(((A1GatewayConfig)CreatedGatewayAccount.GatewayConfig).AccountId, "12312");
            Assert.AreEqual(((A1GatewayConfig)CreatedGatewayAccount.GatewayConfig).Delay, 1232);
            Assert.AreEqual(((A1GatewayConfig)CreatedGatewayAccount.GatewayConfig).AVS, 12);

            Assert.AreEqual(CreatedGatewayAccount.Method, "payment_card");
            Assert.AreEqual(CreatedGatewayAccount.PaymentCardSchemes[0], "Visa");
            Assert.AreEqual(CreatedGatewayAccount.PaymentCardSchemes[1], "MasterCard");
            Assert.AreEqual(CreatedGatewayAccount.OrganizationId, NewOrganization.Id);
            Assert.AreEqual(CreatedGatewayAccount.ThreeDSecure, false);
            Assert.AreEqual(CreatedGatewayAccount.DynamicDescriptor, false);
            Assert.AreEqual(CreatedGatewayAccount.MerchantCategoryCode, 5966);
            Assert.AreEqual(CreatedGatewayAccount.AcquirerName, "CIM");
            Assert.AreEqual(CreatedGatewayAccount.Descriptor, "MyDescriptor");
            Assert.AreEqual(CreatedGatewayAccount.City, "MyCity");
            Assert.AreEqual(CreatedGatewayAccount.Websites[0], NewWebsite.Id);
            Assert.AreEqual(CreatedGatewayAccount.AcceptedCurrencies[0], "USD");


            // Update            
            // We need to pass this in everytime with a valid password in order to update without a data validation error
            CreatedGatewayAccount.GatewayConfig = new A1GatewayConfig() { MemberId = "123", Password = "123123", AccountId = "12312", AVS = 12, Delay = 1232 };
            CreatedGatewayAccount.ThreeDSecure = true;
            CreatedGatewayAccount.DynamicDescriptor = true;
            CreatedGatewayAccount.MerchantCategoryCode = 5966;
            CreatedGatewayAccount.Descriptor = "Descriptor1";
            CreatedGatewayAccount.City = "City2";

            var UpdatedGatewayAccount = GatewayAccounts.Update(CreatedGatewayAccount);
            Assert.AreEqual(UpdatedGatewayAccount.ThreeDSecure, true);
            Assert.AreEqual(UpdatedGatewayAccount.DynamicDescriptor, true);
            Assert.AreEqual(UpdatedGatewayAccount.MerchantCategoryCode, 5966);
            Assert.AreEqual(UpdatedGatewayAccount.Descriptor, "Descriptor1");
            Assert.AreEqual(UpdatedGatewayAccount.City, "City2");
            Assert.AreEqual(UpdatedGatewayAccount.Websites[0], NewWebsite.Id);


            // Load
            var LoadedGateway = GatewayAccounts.Load(UpdatedGatewayAccount.Id);
            Assert.IsNotEmpty(LoadedGateway.Id);
            Assert.AreEqual(LoadedGateway.GatewayName, "A1Gateway");

            // Search
            var SearchGateways = GatewayAccounts.Search();
            Assert.Less(0,SearchGateways.Count);


            // Remove the organization
            OrganizationsTests.DeleteOrganization(NewOrganization);

            WebsitesTests.DeleteWebsite(NewWebsite);

            RebillyClient.GatewayAccounts().Delete(CreatedGatewayAccount);

            // Remove old gateway accounts
            var ItemsToDelete = GatewayAccounts.Search();
            foreach (var item in ItemsToDelete)
            {
                GatewayAccounts.Delete(item.Id);
            }
        }
    }
}
