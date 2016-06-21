using System;
using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;


namespace Tests.Unit.Core
{
    [TestFixture]
    public class ClientExceptionUnitTests
    {
        [Test]
        public void TestConstruct()
        {
            var Exception = new ClientException();
            Assert.IsNotNull(Exception);
        }

        [Test]
        public void TestConstructWithStatusMessage()
        {
            var Exception = new ClientException();
            Assert.IsNotNull(Exception);
        }
    }
}
