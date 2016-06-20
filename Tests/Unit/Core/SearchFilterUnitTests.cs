using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;

namespace Tests.Unit.Core
{
    [TestFixture]
    public class SearchFilterUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var Filter = new SearchFilter();
            Assert.IsNotNull(Filter);
        }


        [Test]
        public void TestFieldDefaultIsEqualTo()
        {
            var Filter = new SearchFilter();
            Assert.IsNull(Filter.Field);
        }


        [Test]
        public void TestFieldIsEqualTo()
        {
            var Filter = new SearchFilter();
            Filter.Field = "test1";
            Assert.AreEqual("test1", Filter.Field);
        }


        [Test]
        public void TestValuesDefaultIsEqualTo()
        {
            var Filter = new SearchFilter();
            Assert.AreEqual(0,Filter.Values.Count);
        }


        [Test]
        public void TestValuesIsEqualTo()
        {
            var Filter = new SearchFilter();
            Filter.Values.Add("Test1");
            Assert.AreEqual("Test1", Filter.Values[0]);
        }    
    }
}
