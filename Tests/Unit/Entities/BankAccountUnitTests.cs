using System;
using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class BankAccountUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var BankAccount = new BankAccount();
            Assert.IsInstanceOf<Entity>(BankAccount);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var BankAccount = new BankAccount();
            Assert.IsNull(BankAccount.Id);
        }

        [Test]
        public void TestIdIsEqualTo()
        {
            var BankAccount = new BankAccount();
            BankAccount.Id = "test2";
            Assert.AreEqual("test2", BankAccount.Id);
        }


        [Test]
        public void CustomerIdDefaultIsEqualTo()
        {
            var BankAccount = new BankAccount();
            Assert.IsNull(BankAccount.CustomerId);
        }


        [Test]
        public void TestCustomerIdIsEqualTo()
        {
            var BankAccount = new BankAccount();
            BankAccount.CustomerId = "CustomerId2";
            Assert.AreEqual("CustomerId2", BankAccount.CustomerId);
        }


        [Test]
        public void TestContactIdDefaultIsEqualTo()
        {
            var BankAccount = new BankAccount();
            Assert.IsNull(BankAccount.ContactId);
        }


        [Test]
        public void TestContactIdIsEqualTo()
        {
            var BankAccount = new BankAccount();
            BankAccount.ContactId = "!@3";
            Assert.AreEqual("!@3", BankAccount.ContactId);
        }


        [Test]
        public void TestNameDefaultIsEqualTo()
        {
            var BankAccount = new BankAccount();
            Assert.IsNull(BankAccount.BankName);
        }


        [Test]
        public void TestBankNameIsEqualTo()
        {
            var BankAccount = new BankAccount();
            BankAccount.BankName = "!@Name";
            Assert.AreEqual("!@Name", BankAccount.BankName);
        }


        [Test]
        public void TestAccountTypeDefaultIsEqualTo()
        {
            var BankAccount = new BankAccount();
            Assert.IsNull(BankAccount.AccountType);
        }


        [Test]
        public void TestAccountTypeIsEqualTo()
        {
            var BankAccount = new BankAccount();
            BankAccount.AccountType = "!@AccountType";
            Assert.AreEqual("!@AccountType", BankAccount.AccountType);
        }


        [Test]
        public void TestRoutingNumberDefaultIsEqualTo()
        {
            var BankAccount = new BankAccount();
            Assert.IsNull(BankAccount.RoutingNumber);
        }


        [Test]
        public void TestRoutingNumberIsEqualTo()
        {
            var BankAccount = new BankAccount();
            BankAccount.RoutingNumber = "!@RoutingNumber";
            Assert.AreEqual("!@RoutingNumber", BankAccount.RoutingNumber);
        }


        [Test]
        public void TestAccountNumberDefaultIsEqualTo()
        {
            var BankAccount = new BankAccount();
            Assert.IsNull(BankAccount.AccountNumber);
        }


        [Test]
        public void TestAccountNumberIsEqualTo()
        {
            var BankAccount = new BankAccount();
            BankAccount.AccountNumber = "!@AccountNumber";
            Assert.AreEqual("!@AccountNumber", BankAccount.AccountNumber);
        }


        [Test]
        public void TestStatusDefaultIsEqualTo()
        {
            var BankAccount = new BankAccount();
            Assert.IsNull(BankAccount.Status);
        }


        [Test]
        public void TestStatusIsEqualTo()
        {
            var BankAccount = new BankAccount();
            BankAccount.Status = "active";
            Assert.AreEqual("active", BankAccount.Status);
        }
    }
}
