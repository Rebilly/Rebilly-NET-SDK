using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;


namespace Tests.Functional
{
    [TestFixture]
    public class NotesServiceFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateLoadSearchDelete()
        {
            // Create
            var CustomersTest = new CustomersServiceFunctionalTests();
            var NewCustomer = CustomersTest.CreateCustomer();

            var NewNote = CreateNote(NewCustomer);
            Assert.IsNotNull(NewNote.Id);
            Assert.AreEqual(NewCustomer.Id, NewNote.RelatedId);
            Assert.AreEqual("customer", NewNote.RelatedType);
            Assert.AreEqual("TESTING!!!", NewNote.Content);
            Assert.IsFalse(NewNote.Archived);


            // Update
            NewNote.Content = "TESTING!!!!2";

            var NotesServies = CreateClient().Notes();
            var UpdatedNote = NotesServies.Update(NewNote);

            Assert.IsNotNull(UpdatedNote.Id);
            Assert.AreEqual(UpdatedNote.RelatedId, NewNote.RelatedId);
            Assert.AreEqual("customer", UpdatedNote.RelatedType);
            Assert.AreEqual("TESTING!!!!2", UpdatedNote.Content);

            // Load
            var LoadedNote = NotesServies.Load(UpdatedNote.Id);
            Assert.IsNotNull(LoadedNote.Id);
            Assert.AreEqual(LoadedNote.RelatedId, NewNote.RelatedId);
            Assert.AreEqual("customer", LoadedNote.RelatedType);
            Assert.AreEqual("TESTING!!!!2", LoadedNote.Content);

            // Search
            var IdFilter = new SearchFilter() { Field = "Id", Values = new List<string>() { LoadedNote.Id } };
            var SearchedNotes = NotesServies.Search(new SearchArguments() { Filters = new List<SearchFilter>() { IdFilter } });
            Assert.AreEqual(1, SearchedNotes.Count);

            // Archive
            LoadedNote.Archived = true;

            var ArchivedNote = NotesServies.Update(LoadedNote);
            Assert.IsNotNull(ArchivedNote.Id);
            Assert.AreEqual(ArchivedNote.RelatedId, NewNote.RelatedId);
            Assert.AreEqual("customer", ArchivedNote.RelatedType);
            Assert.AreEqual("TESTING!!!!2", ArchivedNote.Content);
            Assert.IsTrue(ArchivedNote.Archived);


            var SearchedArchivedNotes = NotesServies.Search(new SearchArguments() { Filters = new List<SearchFilter>() { IdFilter } });
            Assert.AreEqual(0, SearchedArchivedNotes.Count);


            //NotesServies.Delete(ArchivedNote); // Delete method not allowed

        }


        public Note CreateNote(Customer customer) 
        {
            var NewNote = new Note();
            NewNote.RelatedId = customer.Id;
            NewNote.RelatedType = "customer";
            NewNote.Content = "TESTING!!!";
            NewNote.Archived = false;

            var NotesServies = CreateClient().Notes();

            return NotesServies.Create(NewNote);
        }
    }
}
