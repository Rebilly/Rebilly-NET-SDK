using System;

using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;

namespace Tests.Unit.Core
{
    [TestFixture]
    public class TooManyRequestsExceptionUnitTests
    {
        [Test]
        public void TestConstruct()
        {
            var CurrentException = new TooManyRequestsException(new ErrorResponseMessage());
            Assert.IsInstanceOf< ClientException>(CurrentException);
        }


        [Test]
        public void TestConstructWithErrorIsEqualTo()
        {
            var CurrentException = new TooManyRequestsException(new ErrorResponseMessage() { Error = "Error1!!" });
            Assert.AreEqual("Error1!!",CurrentException.Error);
        }


        [Test]
        public void TestConstructStatusIsEqualTo()
        {
            var CurrentException = new TooManyRequestsException(new ErrorResponseMessage() { Status = 13});
            Assert.AreEqual(13, CurrentException.Status);
        }
    }
}
