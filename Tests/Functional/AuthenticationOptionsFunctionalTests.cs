using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class AuthenticationOptionsServiceFunctionalTests : TestBase
    {
        [Test]
        public void TestReadChange()
        {
            var RebillyClient = CreateClient();
            var AuthenticationOptionsService = RebillyClient.AuthenticationOptions();

            var AuthenticationOption = AuthenticationOptionsService.GetSingle();

            Assert.IsNull(AuthenticationOption.PasswordPattern);
            Assert.AreEqual(0,AuthenticationOption.AuthTokenTtl);
            Assert.AreEqual(0, AuthenticationOption.CredentialTtl);
            Assert.AreEqual(0, AuthenticationOption.ResetTokenTtl);
        }
    }
}
