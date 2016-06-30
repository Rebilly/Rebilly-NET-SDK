using NUnit.Framework;

using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Unit.Entities
{
    [TestFixture]
    public class NoteUnitTests
    {
        [Test]
        public void TestConstructIsInstanceOfEntity()
        {
            var Note = new Note();
            Assert.IsInstanceOf<Entity>(Note);
        }


        [Test]
        public void TestIdDefaultIsEqualTo()
        {
            var Note = new Note();
            Assert.IsNull(Note.Id);
        }


        [Test]
        public void TestIdIsEqualTo()
        {
            var Note = new Note();
            Note.Id = "test1";
            Assert.AreEqual("test1", Note.Id);
        }


        [Test]
        public void TestContentDefaultIsEqualTo()
        {
            var Note = new Note();
            Assert.IsNull(Note.Content);
        }


        [Test]
        public void TestContentIsEqualTo()
        {
            var Note = new Note();
            Note.Content = "Content1";
            Assert.AreEqual("Content1", Note.Content);
        }


        [Test]
        public void TestRelatedTypeDefaultIsEqualTo()
        {
            var Note = new Note();
            Assert.IsNull(Note.RelatedType);
        }


        [Test]
        public void TestRelatedTypeIsEqualTo()
        {
            var Note = new Note();
            Note.RelatedType = "RelatedType1";
            Assert.AreEqual("RelatedType1", Note.RelatedType);
        }


        [Test]
        public void TestRelatedIdDefaultIsEqualTo()
        {
            var Note = new Note();
            Assert.IsNull(Note.RelatedId);
        }


        [Test]
        public void TestRelatedIdIsEqualTo()
        {
            var Note = new Note();
            Note.RelatedId = "RelatedId1";
            Assert.AreEqual("RelatedId1", Note.RelatedId);
        }


        [Test]
        public void TestArchivedDefaultIsEqualTo()
        {
            var Note = new Note();
            Assert.IsFalse(Note.Archived);
        }


        [Test]
        public void TestArchivedIsEqualTo()
        {
            var Note = new Note();
            Note.Archived = true;
            Assert.IsTrue(Note.Archived);
        }
    }
}
