using System;
using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class InvoiceUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var Invoice = new Invoice();
            Assert.IsInstanceOf<Entity>(Invoice);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.Id);
        }


        [Test]
        public void TestCustomerIdDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.CustomerId);
        }


        [Test]
        public void TestCustomerIdIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.CustomerId = "CustomerId1";
            Assert.AreEqual("CustomerId1", Invoice.CustomerId);
        }


        [Test]
        public void TestWebsiteIdDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.WebsiteId);
        }


        [Test]
        public void TestWebsiteIdIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.WebsiteId = "WebsiteId1";
            Assert.AreEqual("WebsiteId1", Invoice.WebsiteId);
        }


        [Test]
        public void TestCurrencyDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.Currency);
        }


        [Test]
        public void TestCurrencyIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.Currency = "Currency1";
            Assert.AreEqual("Currency1", Invoice.Currency);
        }


        [Test]
        public void TestAmountDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.AreEqual(0,Invoice.Amount);
        }


        [Test]
        public void TestAmountIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.Amount = 123;
            Assert.AreEqual(123, Invoice.Amount);
        }


        [Test]
        public void TestBillingContactIdDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.BillingContactId);
        }


        [Test]
        public void TestBillingContactIdIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.BillingContactId = "BillingContactId1";
            Assert.AreEqual("BillingContactId1", Invoice.BillingContactId);
        }


        [Test]
        public void TestDeliveryContactIdDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.DeliveryContactId);
        }


        [Test]
        public void TestDeliveryContactIdIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.DeliveryContactId = "DeliveryContactId1";
            Assert.AreEqual("DeliveryContactId1", Invoice.DeliveryContactId);
        }

        [Test]
        public void TestItemsDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.Items);
        }


        [Test]
        public void TestItemsIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.Items = new string[] {"item"};
            Assert.AreEqual("item", Invoice.Items[0]);
        }

        [Test]
        public void TestAbandonedTimeDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.AbandonedTime);
        }


        [Test]
        public void TestAbandonedTimeIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.AbandonedTime = DateTime.Parse("2017-02-11 03:01:01");
            Assert.AreEqual("2017-02-11 03:01:01", Invoice.AbandonedTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }


        [Test]
        public void TestVoidedTimeDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.VoidedTime);
        }


        [Test]
        public void TestVoidedTimeIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.VoidedTime = DateTime.Parse("2017-02-11 03:01:01");
            Assert.AreEqual("2017-02-11 03:01:01", Invoice.VoidedTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }


        [Test]
        public void TestClosedTimeDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.ClosedTime);
        }


        [Test]
        public void TestClosedTimeIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.ClosedTime = DateTime.Parse("2017-02-11 03:01:01");
            Assert.AreEqual("2017-02-11 03:01:01", Invoice.ClosedTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }


        [Test]
        public void TestDueTimeDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.DueTime);
        }


        [Test]
        public void TestDueTimeIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.DueTime = DateTime.Parse("2017-02-11 03:01:01");
            Assert.AreEqual("2017-02-11 03:01:01", Invoice.DueTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }


        [Test]
        public void TestIssuedTimeDefaultIsEqualTo()
        {
            var Invoice = new Invoice();
            Assert.IsNull(Invoice.IssuedTime);
        }


        [Test]
        public void TestIssuedTimeIsEqualTo()
        {
            var Invoice = new Invoice();
            Invoice.IssuedTime = DateTime.Parse("2017-02-11 03:01:01");
            Assert.AreEqual("2017-02-11 03:01:01", Invoice.IssuedTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}
