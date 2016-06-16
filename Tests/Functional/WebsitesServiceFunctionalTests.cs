using System;
using System.Collections.Generic;

using NUnit.Framework;

using Rebilly;
using Rebilly.Core;
using Rebilly.Entities;

namespace Tests.Functional
{
    [TestFixture]
    public class WebsitesServiceFunctionalTests : FunctionalTestBase
    {
        [Test]
        public void TestCreateUpdateRetrieveListDelete()
        {
            // Create
            var NewWebsite = GetNewWebsite();
            var CreatedWebsite = CreateWebsite(NewWebsite);
            Assert.AreEqual(NewWebsite.Name, CreatedWebsite.Name);
            Assert.AreEqual(NewWebsite.Url, CreatedWebsite.Url);
            Assert.AreEqual(NewWebsite.ServicePhone, CreatedWebsite.ServicePhone);
            Assert.AreEqual(NewWebsite.ServiceEmail, CreatedWebsite.ServiceEmail);
            Assert.AreEqual(NewWebsite.CheckoutPageUri, CreatedWebsite.CheckoutPageUri);


            // Update

            DeleteWebsite(CreatedWebsite);
        }

        public Website CreateWebsite(Website newWebSite)
        {
            var RebillyClient = CreateClient();
            return RebillyClient.Websites().Create(newWebSite);
        }

        protected Website GetNewWebsite()
        {
            var NewWebsite = new Website()
            {
                Name = "TestWebsites-" + Guid.NewGuid().ToString(),
                Url = "mywebsite.com",
                ServicePhone = "+123456789",
                ServiceEmail = "support@mywebsite.com",
                CheckoutPageUri = "checkout",
                WebHookUrl = "http://www.test.com/rebilly_webhook.php",
                WebHookUsername = "user",
                WebHookPassword = "password",
            };

            return NewWebsite;
        }


        public void DeleteWebsite(Website website)
        {
            var RebillyClient = CreateClient();
            RebillyClient.Websites().Delete(website);
        }
    }
}
