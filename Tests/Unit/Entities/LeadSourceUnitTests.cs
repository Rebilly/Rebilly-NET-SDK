using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class LeadSourceUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var LeadSource = new LeadSource();
            Assert.IsInstanceOf<Entity>(LeadSource);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Id = "test1";
            Assert.AreEqual("test1", LeadSource.Id);
        }


        [Test]
        public void TestCustomerIdDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.CustomerId);
        }


        [Test]
        public void TestCustomerIdIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.CustomerId = "Customer1";
            Assert.AreEqual("Customer1", LeadSource.CustomerId);
        }


        [Test]
        public void TestMediumDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.Medium);
        }


        [Test]
        public void TestMediumIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Medium = "Medium1";
            Assert.AreEqual("Medium1", LeadSource.Medium);
        }


        [Test]
        public void TestSourceDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.Source);
        }


        [Test]
        public void TestSourceIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Source = "Source1";
            Assert.AreEqual("Source1", LeadSource.Source);
        }


        [Test]
        public void TestCampaignDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.Campaign);
        }


        [Test]
        public void TestCampaignIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Campaign = "Campaign1";
            Assert.AreEqual("Campaign1", LeadSource.Campaign);
        }


        [Test]
        public void TestTermDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.Term);
        }


        [Test]
        public void TestTermIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Term = "Term1";
            Assert.AreEqual("Term1", LeadSource.Term);
        }


        [Test]
        public void TestContentDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.Content);
        }


        [Test]
        public void TestContentIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Content = "Content1";
            Assert.AreEqual("Content1", LeadSource.Content);
        }


        [Test]
        public void TestAffiliateDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.Affiliate);
        }


        [Test]
        public void TestAffiliateIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Affiliate = "Affiliate1";
            Assert.AreEqual("Affiliate1", LeadSource.Affiliate);
        }


        [Test]
        public void TestSubAffiliateDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.SubAffiliate);
        }


        [Test]
        public void TestSubAffiliateIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.SubAffiliate = "SubAffiliate1";
            Assert.AreEqual("SubAffiliate1", LeadSource.SubAffiliate);
        }


        [Test]
        public void TestSalesAgentDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.SalesAgent);
        }


        [Test]
        public void TestSalesAgentIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.SalesAgent = "SalesAgent1";
            Assert.AreEqual("SalesAgent1", LeadSource.SalesAgent);
        }


        [Test]
        public void TestClickIdDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.ClickId);
        }


        [Test]
        public void TestClickIdIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.ClickId = "ClickId1";
            Assert.AreEqual("ClickId1", LeadSource.ClickId);
        }


        [Test]
        public void TestPathDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.Path);
        }


        [Test]
        public void TestPathIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Path = "Path1";
            Assert.AreEqual("Path1", LeadSource.Path);
        }


        [Test]
        public void TestIpAddressDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.IpAddress);
        }


        [Test]
        public void TestIpAddressIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.IpAddress = "IpAddress1";
            Assert.AreEqual("IpAddress1", LeadSource.IpAddress);
        }


        [Test]
        public void TestCurrencyDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.IsNull(LeadSource.Currency);
        }


        [Test]
        public void TestCurrencyIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Currency = "Currency1";
            Assert.AreEqual("Currency1", LeadSource.Currency);
        }


        [Test]
        public void TestAmountDefaultIsEqualTo()
        {
            var LeadSource = new LeadSource();
            Assert.AreEqual(0,LeadSource.Amount);
        }


        [Test]
        public void TestAmountIsEqualTo()
        {
            var LeadSource = new LeadSource();
            LeadSource.Amount = 123.12;
            Assert.AreEqual(123.12, LeadSource.Amount);
        }
    }
}
