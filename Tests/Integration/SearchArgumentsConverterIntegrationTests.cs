using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;

namespace Tests.Integration
{
    [TestFixture]
    public class SearchArgumentsConverterIntegrationTests
    {
        [Test]
        public void TestConverterWithAgumentsLimitIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments();
            Arguments.Limit = 23;
            Assert.AreEqual("23", Converter.ToDictionary(Arguments)["Limit"]);
        }


        [Test]
        public void TestConverterWithAgumentsOffsetIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments();
            Arguments.Offset = 10;
            Assert.AreEqual("10", Converter.ToDictionary(Arguments)["Offset"]);
        }


        [Test]
        public void TestConverterWithAgumentsOffsetAndLimitIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments() { Limit = 11 };
            Arguments.Offset = 10;
            Assert.AreEqual("11", Converter.ToDictionary(Arguments)["Limit"]);
            Assert.AreEqual("10", Converter.ToDictionary(Arguments)["Offset"]);
        }


        [Test]
        public void TestConverterWithFieldsIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments();
            Arguments.Filter.Field = "Field1";
            Arguments.Filter.Values = new List<string>() { "test1", "test2" };


            Assert.AreEqual("Field1:test1,test2", Converter.ToDictionary(Arguments)["Filter"]);
        }
    }
}
