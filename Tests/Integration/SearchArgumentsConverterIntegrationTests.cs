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
        public void TestConverterToDictionaryWithAgumentsOffsetIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments();
            Arguments.Offset = 10;
            Assert.AreEqual("10", Converter.ToDictionary(Arguments)["Offset"]);
        }


        [Test]
        public void TestConverterToDictionaryWithAgumentsOffsetAndLimitIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments() { Limit = 11 };
            Arguments.Offset = 10;
            Assert.AreEqual("11", Converter.ToDictionary(Arguments)["Limit"]);
            Assert.AreEqual("10", Converter.ToDictionary(Arguments)["Offset"]);
        }


        [Test]
        public void TestConverterToDictionaryWithFieldsIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments();

            var Filter = new SearchFilter();
            Filter.Field = "Field1";
            Filter.Values = new List<string>() { "test1", "test2" };
            Arguments.Filters.Add(Filter);

            Assert.AreEqual("field1:test1,test2", Converter.ToDictionary(Arguments)["Filter"]);
        }


        [Test]
        public void TestConverterToQueryStringWithFieldsIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments();

            var Filter = new SearchFilter();
            Filter.Field = "Field1";
            Filter.Values = new List<string>() { "test1", "test2" };
            Arguments.Filters.Add(Filter);


            Assert.AreEqual("filter=field1:test1,test2", Converter.ToQueryString(Arguments));
        }

        [Test]
        public void TestConverterToQueryStringWithTwoFieldsIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments();

            var Filter = new SearchFilter();
            Filter.Field = "Field1";
            Filter.Values = new List<string>() { "test1", "test2" };
            Arguments.Filters.Add(Filter);

            var Filter2 = new SearchFilter();
            Filter2.Field = "Field2";
            Filter2.Values = new List<string>() { "test3", "test4" };
            Arguments.Filters.Add(Filter2);


            Assert.AreEqual("filter=field1:test1,test2;field2:test3,test4", Converter.ToQueryString(Arguments));
        }


        [Test]
        public void TestConverterToQueryStringWithFieldsAndLimitOffsetIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments();
            Arguments.Offset = 0;
            Arguments.Limit = 10;

            var Filter = new SearchFilter();
            Filter.Field = "Field1";
            Filter.Values = new List<string>() { "test1", "test2" };
            Arguments.Filters.Add(Filter);

            Assert.AreEqual("offset=0&limit=10&filter=field1:test1,test2", Converter.ToQueryString(Arguments));
        }


        [Test]
        public void TestConverterToQueryStringWithFieldsAndLimitOffsetSortIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();

            var Arguments = new SearchArguments();
            Arguments.Offset = 2;
            Arguments.Limit = 123;
            Arguments.Sort = new List<string>() { "test1", "-test2" };
            
            var Filter = new SearchFilter();
            Filter.Field = "Field1";
            Filter.Values = new List<string>() { "test1", "test2" };
            Arguments.Filters.Add(Filter);


            Assert.AreEqual("offset=2&limit=123&filter=field1:test1,test2&sort=test1,-test2", Converter.ToQueryString(Arguments));
        }

    }
}
