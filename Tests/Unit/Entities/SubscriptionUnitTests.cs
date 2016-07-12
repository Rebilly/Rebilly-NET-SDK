using System;
using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class SubscriptionUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var Subscription = new Subscription();
            Assert.IsInstanceOf<Entity>(Subscription);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.Id = "test1";
            Assert.AreEqual("test1", Subscription.Id);
        }


        [Test]
        public void TestCustomerIdDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.CustomerId);
        }


        [Test]
        public void TestCustomerIdIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.CustomerId = "123123";
            Assert.AreEqual("123123", Subscription.CustomerId);
        }


        [Test]
        public void TestPlanIdDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.PlanId);
        }


        [Test]
        public void TestPlanIdIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.PlanId = "123123123";
            Assert.AreEqual("123123123", Subscription.PlanId);
        }


        [Test]
        public void TestWebsiteIdDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.WebsiteId);
        }


        [Test]
        public void TestWebsiteIdIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.WebsiteId = "12312312";
            Assert.AreEqual("12312312", Subscription.WebsiteId);
        }


        [Test]
        public void TestInitialInvoiceIdDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.InitialInvoiceId);
        }


        [Test]
        public void TestInitialInvoiceIdIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.InitialInvoiceId = "ABC123";
            Assert.AreEqual("ABC123", Subscription.InitialInvoiceId);
        }


        [Test]
        public void TestDeliveryContactIdDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.DeliveryContactId);
        }


        [Test]
        public void TestDeliveryContactIdIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.DeliveryContactId = "AVSDFSAF";
            Assert.AreEqual("AVSDFSAF", Subscription.DeliveryContactId);
        }


        [Test]
        public void TestQuantitytDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.AreEqual(0,Subscription.Quantity);
        }


        [Test]
        public void TestQuantityIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.Quantity = 123123;
            Assert.AreEqual(123123, Subscription.Quantity);
        }


        [Test]
        public void TestAutopayDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsFalse(Subscription.Autopay);
        }


        [Test]
        public void TestAutopayIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.Autopay = true;
            Assert.IsTrue(Subscription.Autopay);
        }


        [Test]
        public void TestPlanDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.Plan);
        }


        [Test]
        public void TestPlanIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.Plan = "Test Plan";
            Assert.AreEqual("Test Plan", Subscription.Plan);
        }


        [Test]
        public void TestWebsiteDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.Website);
        }


        [Test]
        public void TestWebsiteIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.Website = "Website1";
            Assert.AreEqual("Website1", Subscription.Website);
        }


        [Test]
        public void TestBillingAddressDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.BillingAddress);
        }


        [Test]
        public void TestBillingAddressIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.BillingAddress = "123 Compton Lane";
            Assert.AreEqual("123 Compton Lane", Subscription.BillingAddress);
        }


        [Test]
        public void TestDeliveryAddressDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.DeliveryAddress);
        }


        [Test]
        public void TestDeliveryAddressIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.DeliveryAddress = "1233 Compton Lane";
            Assert.AreEqual("1233 Compton Lane", Subscription.DeliveryAddress);
        }


        [Test]
        public void TestStatusDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.Status);
        }


        [Test]
        public void TestStatusIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.Status = "approved";
            Assert.AreEqual("approved", Subscription.Status);
        }


        [Test]
        public void TestStartTimeDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.StartTime);
        }


        [Test]
        public void TestStartTimeIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.StartTime = DateTime.Parse("2017-02-11 03:01:01");
            Assert.AreEqual("2017-02-11 03:01:01", Subscription.StartTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }


        [Test]
        public void TestEndTimeDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.EndTime);
        }


        [Test]
        public void TestEndTimeIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.EndTime = DateTime.Parse("2017-02-12 03:07:01");
            Assert.AreEqual("2017-02-12 03:07:01", Subscription.EndTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }


        [Test]
        public void TestRenewalTimeDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.RenewalTime);
        }


        [Test]
        public void TestRenewalTimeIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.RenewalTime = DateTime.Parse("2017-02-12 06:07:01");
            Assert.AreEqual("2017-02-12 06:07:01", Subscription.RenewalTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }


        [Test]
        public void TestCancelledTimeDefaultIsEqualTo()
        {
            var Subscription = new Subscription();
            Assert.IsNull(Subscription.CancelledTime);
        }


        [Test]
        public void TestCancelledTimeIsEqualTo()
        {
            var Subscription = new Subscription();
            Subscription.CancelledTime = DateTime.Parse("2017-02-12 06:07:01");
            Assert.AreEqual("2017-02-12 06:07:01", Subscription.CancelledTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}
