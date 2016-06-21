using System;
using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;

namespace Tests.Unit.Core
{
    [TestFixture]
    public class SearchArgumentsUnitTests
    {
        [Test]
        public void TestConstruct()
        {
            var Arguments = new SearchArguments();
            Assert.IsNotNull(Arguments);
        }


        [Test]
        public void TestLimitDefault()
        {
            var Arguments = new SearchArguments();
            Assert.AreEqual(Int32.MinValue, Arguments.Limit);
        }


        [Test]
        public void TestLimitIsEqualTo()
        {
            var Arguments = new SearchArguments();
            Arguments.Limit = 11;
            Assert.AreEqual(11, Arguments.Limit);
        }


        [Test]
        public void TestOffsetDefault()
        {
            var Arguments = new SearchArguments();
            Assert.AreEqual(Int32.MinValue, Arguments.Offset);
        }


        [Test]
        public void TestOffsetIsEqualTo()
        {
            var Arguments = new SearchArguments();
            Arguments.Offset = 23;
            Assert.AreEqual(23, Arguments.Offset);
        }


        [Test]
        public void TestSortIsEqualTo()
        {
            var Arguments = new SearchArguments();
            Arguments.Sort.Add("CreateTime");
            Assert.AreEqual("CreateTime", Arguments.Sort[0]);
        }

        [Test]
        public void TestSortSetIsEqualTo()
        {
            var Arguments = new SearchArguments();
            Arguments.Sort = new List<string>() { "CreateTime", "UpdatedTime" };
            Assert.AreEqual("UpdatedTime", Arguments.Sort[1]);
        }


        [Test]
        public void TestSortDefault()
        {
            var Arguments = new SearchArguments();
            Assert.AreEqual(0, Arguments.Sort.Count);
        }


        [Test]
        public void TestFilterDefault()
        {
            var Arguments = new SearchArguments();
            Assert.IsNotNull(Arguments.Filter);
        }


        [Test]
        public void TestFilterIsEqualTo()
        {
            var Arguments = new SearchArguments();
            Arguments.Filter = new SearchFilter() { Field = "test" };
            Assert.AreEqual("test", Arguments.Filter.Field);
        }


        [Test]
        public void TestFieldsDefault()
        {
            var Arguments = new SearchArguments();
            Assert.AreEqual(0, Arguments.Fields.Count);
        }


        [Test]
        public void TestFieldsIsEqualTo()
        {
            var Arguments = new SearchArguments();
            Arguments.Fields.Add("Field");
            Assert.AreEqual("Field", Arguments.Fields[0]);
        }

        [Test]
        public void TestFieldsSetIsEqualTo()
        {
            var Arguments = new SearchArguments();
            Arguments.Fields = new List<string>() { "CreateTime", "UpdatedTime" };
            Assert.AreEqual("UpdatedTime", Arguments.Fields[1]);
        }
    }
}
