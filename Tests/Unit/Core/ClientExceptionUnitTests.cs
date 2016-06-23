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
        public void TestConstructWithErrorIsEqualTo()
        {
            var CurrentException = new ClientException(new ErrorResponseMessage() { Error = "Error1!!" });
            Assert.AreEqual("Error1!!", CurrentException.Error);
        }


        [Test]
        public void TestConstructStatusIsEqualTo()
        {
            var CurrentException = new ClientException(new ErrorResponseMessage() { Status = 13 });
            Assert.AreEqual(13, CurrentException.Status);
        }


        [Test]
        public void TestConstructFullMessageIsEqualTo()
        {
            var CurrentException = new ClientException(new ErrorResponseMessage() { Error = "An error occurred.", Status = 13 });
            Assert.AreEqual("Client request failed with error status 13.  An error occurred.", CurrentException.FullMessage);
        }
    }
}
