using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class PlanUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var Plan = new Plan();
            Assert.IsInstanceOf<Entity>(Plan);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var Plan = new Plan();
            Plan.Id = "test1";
            Assert.AreEqual("test1", Plan.Id);
        }


        [Test]
        public void TestContentIsActiveIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsFalse(Plan.IsActive);
        }


        [Test]
        public void TestIsActiveIsIsEqualTo()
        {
            var Plan = new Plan();
            Plan.IsActive = true;
            Assert.IsTrue(Plan.IsActive);
        }


        [Test]
        public void TestNameDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.Name);
        }


        [Test]
        public void TestNameIsEqualTo()
        {
            var Plan = new Plan();
            Plan.Name = "Name1";
            Assert.AreEqual("Name1", Plan.Name);
        }


        [Test]
        public void TestCurrencyDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.Currency);
        }


        [Test]
        public void TestCurrencyIsEqualTo()
        {
            var Plan = new Plan();
            Plan.Currency = "USD";
            Assert.AreEqual("USD", Plan.Currency);
        }


        [Test]
        public void TestDescriptionDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.Description);
        }


        [Test]
        public void TestDescriptionIsEqualTo()
        {
            var Plan = new Plan();
            Plan.Description = "Testing 123";
            Assert.AreEqual("Testing 123", Plan.Description);
        }


        [Test]
        public void TestRecurringAmountDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.RecurringAmount);
        }


        [Test]
        public void TestRecurringAmountIsEqualTo()
        {
            var Plan = new Plan();
            Plan.RecurringAmount = 123.22M;
            Assert.AreEqual(123.22M, Plan.RecurringAmount);
        }


        [Test]
        public void TestRecurringPeriodUnitDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.RecurringPeriodUnit);
        }


        [Test]
        public void TestRecurringPeriodUnitIsEqualTo()
        {
            var Plan = new Plan();
            Plan.RecurringPeriodUnit = "monthly";
            Assert.AreEqual("monthly", Plan.RecurringPeriodUnit);
        }


        [Test]
        public void TestRecurringPeriodLengthDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.RecurringPeriodLength);
        }


        [Test]
        public void TestRecurringPeriodLengthIsEqualTo()
        {
            var Plan = new Plan();
            Plan.RecurringPeriodLength = 12;
            Assert.AreEqual(12, Plan.RecurringPeriodLength);
        }


        [Test]
        public void TestTrialAmountDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.TrialAmount);
        }


        [Test]
        public void TestTrialAmountIsEqualTo()
        {
            var Plan = new Plan();
            Plan.TrialAmount = 232.22M;
            Assert.AreEqual(232.22M, Plan.TrialAmount);
        }


        [Test]
        public void TestTrialPeriodUnitDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.TrialPeriodUnit);
        }


        [Test]
        public void TestTrialPeriodUnitIsEqualTo()
        {
            var Plan = new Plan();
            Plan.TrialPeriodUnit = "monthly";
            Assert.AreEqual("monthly", Plan.TrialPeriodUnit);
        }


        [Test]
        public void TestTrialPeriodLengthDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.TrialPeriodLength);
        }


        [Test]
        public void TestTrialPeriodLengthIsEqualTo()
        {
            var Plan = new Plan();
            Plan.TrialPeriodLength = 234;
            Assert.AreEqual(234, Plan.TrialPeriodLength);
        }


        [Test]
        public void TestSetupAmountDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.SetupAmount);
        }


        [Test]
        public void TestSetupAmountIsEqualTo()
        {
            var Plan = new Plan();
            Plan.SetupAmount = 13.22M;
            Assert.AreEqual(13.22M, Plan.SetupAmount);
        }


        [Test]
        public void TestExpireTimeDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.ExpireTime);
        }


        [Test]
        public void TestExpireTimeIsEqualTo()
        {
            var Plan = new Plan();
            Plan.ExpireTime = "monthly";
            Assert.AreEqual("monthly", Plan.ExpireTime);
        }


        [Test]
        public void TestContractTermUnitDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.ContractTermUnit);
        }


        [Test]
        public void TestContractTermUnitIsEqualTo()
        {
            var Plan = new Plan();
            Plan.ContractTermUnit = "weekly";
            Assert.AreEqual("weekly", Plan.ContractTermUnit);
        }


        [Test]
        public void TestContractTermLengthDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.ContractTermLength);
        }


        [Test]
        public void TestContractTermLengthIsEqualTo()
        {
            var Plan = new Plan();
            Plan.ContractTermLength = 123;
            Assert.AreEqual(123, Plan.ContractTermLength);
        }


        [Test]
        public void TestRecurringPeriodLimitDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.RecurringPeriodLimit);
        }


        [Test]
        public void TestRecurringPeriodLimitIsEqualTo()
        {
            var Plan = new Plan();
            Plan.RecurringPeriodLimit = 444;
            Assert.AreEqual(444, Plan.RecurringPeriodLimit);
        }


        [Test]
        public void TestMinQuantityDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.MinQuantity);
        }


        [Test]
        public void TestMinQuantityIsEqualTo()
        {
            var Plan = new Plan();
            Plan.MinQuantity = 3243;
            Assert.AreEqual(3243, Plan.MinQuantity);
        }


        [Test]
        public void TestMaxQuantityDefaultIsEqualTo()
        {
            var Plan = new Plan();
            Assert.IsNull(Plan.MaxQuantity);
        }


        [Test]
        public void TestMaxQuantityIsEqualTo()
        {
            var Plan = new Plan();
            Plan.MaxQuantity = 3243;
            Assert.AreEqual(3243, Plan.MaxQuantity);
        }
    }
}
