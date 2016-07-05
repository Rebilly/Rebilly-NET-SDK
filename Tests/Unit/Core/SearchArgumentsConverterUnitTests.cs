using System;

using System.Collections.Generic;

using NUnit.Framework;
using Rebilly.Core;

namespace Tests.Unit.Core
{
    [TestFixture]
    public class SearchArgumentsConverterUnitTests
    {
        [Test]
        public void TestConstruct()
        {
            var Converter = new SearchArgumentsConverter();
            Assert.IsNotNull(Converter);
        }


        [Test]
        public void TestConverterWithNullArgumentThrowException()
        {
            var Converter = new SearchArgumentsConverter();
            Assert.Throws<ArgumentNullException>(() => { Converter.ToDictionary(null); });
        }


        [Test]
        public void TestConverterWithAgumentsIsEqualTo()
        {
            var Converter = new SearchArgumentsConverter();
            var Args = Converter.ToDictionary(new SearchArguments());
            Assert.AreEqual(0, Args.Count);        
        }
    }
}
