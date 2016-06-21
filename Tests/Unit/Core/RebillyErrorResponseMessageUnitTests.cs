using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;

namespace Tests.Unit.Services
{
    [TestFixture]
    public class RebillyErrorResponseMessageUnitTests
    {
        [Test]
        public void TestConstructIsNotNull()
        {
            var Message = new ErrorResponseMessage();
            Assert.IsNotNull(Message);
        }


        [Test]
        public void TestStatusDefaultIsEqualTo()
        {
            var Message = new ErrorResponseMessage();
            Assert.AreEqual(0,Message.Status);
        }


        [Test]
        public void TestStatusIsEqualTo()
        {
            var Message = new ErrorResponseMessage();
            Message.Status = 124;
            Assert.AreEqual(124, Message.Status);
        }


        [Test]
        public void TestErrorDefaultIsEqualTo()
        {
            var Message = new ErrorResponseMessage();
            Assert.IsNull(Message.Error);
        }


        [Test]
        public void TestErrorIsEqualTo()
        {
            var Message = new ErrorResponseMessage();
            Message.Error = "error";
            Assert.AreEqual("error", Message.Error);
        }


        [Test]
        public void TestDetailsDefaultIsEqualTo()
        {
            var Message = new ErrorResponseMessage();
            Assert.IsEmpty(Message.Details);        
        }


        [Test]
        public void TestDetailsIsEqualTo()
        {
            var Message = new ErrorResponseMessage();
            Assert.AreEqual(0,Message.Details.Count);
        }


        [Test]
        public void TestFullMessageDefaultIsEqualTo()
        {
            var Message = new ErrorResponseMessage();

            Assert.AreEqual("Client request failed with error status 0.", Message.FullMessage);
        }

        [Test]
        public void TestFullMessageIsEqualTo()
        {
            var Message = new ErrorResponseMessage();
            Message.Status = 411;
            Message.Error = "All Systems down.";
            Message.Details = new List<string>() { "Down 1.", "Down 2." };

            Assert.AreEqual("Client request failed with error status 411.  All Systems down.  Down 1.  Down 2.", Message.FullMessage);
        }
    }
}
