using System;
using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;

namespace Tests.Unit.Core
{
    [TestFixture]
    public class RateLimitStatusUnitTest
    {
        [Test]
        public void TestConstruct()
        {
            var LimitStatus = new RateLimitStatus();
            Assert.IsNotNull(LimitStatus);
        }


        [Test]
        public void TestLimitDefaultIsEqualTo()
        {
            var LimitStatus = new RateLimitStatus();
            Assert.AreEqual(int.MinValue, LimitStatus.Limit);
        }


        [Test]
        public void TestLimitSetIsEqualTo()
        {
            var LimitStatus = new RateLimitStatus();
            LimitStatus.Limit = 123123;
            Assert.AreEqual(123123, LimitStatus.Limit);
        }


        [Test]
        public void TestRemainingDefaultIsEqualTo()
        {
            var LimitStatus = new RateLimitStatus();
            Assert.AreEqual(int.MinValue, LimitStatus.Remaining);
        }


        [Test]
        public void TestRemainingSetIsEqualTo()
        {
            var LimitStatus = new RateLimitStatus();
            LimitStatus.Remaining = 1231238;
            Assert.AreEqual(1231238, LimitStatus.Remaining);
        }


        [Test]
        public void TestResetTimeDefaultIsEqualTo()
        {
            var LimitStatus = new RateLimitStatus();
            Assert.AreEqual(DateTime.MinValue, LimitStatus.ResetTime);
        }


        [Test]
        public void TestResetTimeSetIsEqualTo()
        {
            var LimitStatus = new RateLimitStatus();
            LimitStatus.ResetTime = DateTime.MaxValue;
            Assert.AreEqual(DateTime.MaxValue, LimitStatus.ResetTime);
        }
    }
}
