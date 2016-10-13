using System;
using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class AuthenticationOptionUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var CurrentAuthenticationOption = new AuthenticationOption();
            Assert.IsInstanceOf<AuthenticationOption>(CurrentAuthenticationOption);
        }


        [Test]
        public void TestPasswordPatternDefault()
        {
            var CurrentAuthenticationOption = new AuthenticationOption();
            Assert.IsNull(CurrentAuthenticationOption.PasswordPattern);
        }


        [Test]
        public void TestPasswordPatternIsEqualTo()
        {
            var CurrentAuthenticationOption = new AuthenticationOption();
            CurrentAuthenticationOption.PasswordPattern = "test";
            Assert.AreEqual("test", CurrentAuthenticationOption.PasswordPattern);
        }


        [Test]
        public void TestCredentialTtlDefault()
        {
            var CurrentAuthenticationOption = new AuthenticationOption();
            Assert.AreEqual(0,CurrentAuthenticationOption.CredentialTtl);
        }


        [Test]
        public void TestCredentialTtlIsEqualTo()
        {
            var CurrentAuthenticationOption = new AuthenticationOption();
            CurrentAuthenticationOption.CredentialTtl = 2300;
            Assert.AreEqual(2300, CurrentAuthenticationOption.CredentialTtl);
        }


        [Test]
        public void TestAuthTokenTtlDefault()
        {
            var CurrentAuthenticationOption = new AuthenticationOption();
            Assert.AreEqual(0, CurrentAuthenticationOption.AuthTokenTtl);
        }


        [Test]
        public void TestAuthTokenTtlIsEqualTo()
        {
            var CurrentAuthenticationOption = new AuthenticationOption();
            CurrentAuthenticationOption.AuthTokenTtl = 123123;
            Assert.AreEqual(123123, CurrentAuthenticationOption.AuthTokenTtl);
        }

        [Test]
        public void TestResetTokenTtlDefault()
        {
            var CurrentAuthenticationOption = new AuthenticationOption();
            Assert.AreEqual(0, CurrentAuthenticationOption.ResetTokenTtl);
        }


        [Test]
        public void TestResetTokenTtlIsEqualTo()
        {
            var CurrentAuthenticationOption = new AuthenticationOption();
            CurrentAuthenticationOption.ResetTokenTtl = 123123;
            Assert.AreEqual(123123, CurrentAuthenticationOption.ResetTokenTtl);
        }
    }
}
