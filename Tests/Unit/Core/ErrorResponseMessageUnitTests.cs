using System;
using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;


namespace Tests.Unit.Core
{
    [TestFixture]
    public class ErrorResponseMessageUnitTests
    {
        [Test]
        public void TestConstruct()
        {
            var ResponseMessage = new ErrorResponseMessage();
            Assert.IsNotNull(ResponseMessage);
        }


        [Test]
        public void TestStatusDefault()
        {
            var ResponseMessage = new ErrorResponseMessage();
            Assert.AreEqual(0,ResponseMessage.Status);
        }


        [Test]
        public void TestStatusSetIsEqualTo()
        {
            var ResponseMessage = new ErrorResponseMessage();
            ResponseMessage.Status = 13;
            Assert.AreEqual(13, ResponseMessage.Status);
        }


        [Test]
        public void TestErrorDefaultIsEqualTo()
        {
            var ResponseMessage = new ErrorResponseMessage();
            Assert.IsNull(ResponseMessage.Error);
        }


        [Test]
        public void TestErrorSetIsEqualTo()
        {
            var ResponseMessage = new ErrorResponseMessage();
            ResponseMessage.Error = "error!!";
            Assert.AreEqual("error!!", ResponseMessage.Error);
        }


        [Test]
        public void TestDetailsDefaultIsEqualTo()
        {
            var ResponseMessage = new ErrorResponseMessage();
            Assert.AreEqual(0,ResponseMessage.Details.Count);
        }


        [Test]
        public void TestDetailsSetIsEqualTo()
        {
            var ResponseMessage = new ErrorResponseMessage();
            ResponseMessage.Details = new List<string> { "Test" };
            Assert.AreEqual("Test", ResponseMessage.Details[0]);
        } 
    }
}
