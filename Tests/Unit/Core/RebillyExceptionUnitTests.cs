using System;
using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;


namespace Tests.Unit.Core
{
    [TestFixture]
    public class RebillyExceptionUnitTests
    {
        [Test]
        public void TestConstruct()
        {
            var CurrentException = new RebillyException();
            Assert.IsNotNull(CurrentException);
        }


        [Test]
        public void TestConstructDefaultsMessage()
        {
            var CurrentException = new RebillyException();
            Assert.IsNotEmpty(CurrentException.Message);
        }


        [Test]
        public void TestConstructMessageIsEqualTo()
        {
            var CurrentException = new RebillyException("testing");
            Assert.AreEqual("testing", CurrentException.Message);
        }
    }
}
