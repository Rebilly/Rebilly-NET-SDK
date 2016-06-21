﻿using System;
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
        public void TestCreateUpdateLoadListDelete()
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
            CreatedWebsite.Name = "TestWebsites-" + Guid.NewGuid().ToString();
            CreatedWebsite.Url = "mywebsite.com";
            CreatedWebsite.ServicePhone = "+12345678910";
            CreatedWebsite.ServiceEmail = "support2@gmail.com";
            CreatedWebsite.CheckoutPageUri = "checkout2";

            var RebillyClient = CreateClient();
            var UpdatedWebsite = RebillyClient.Websites().Update(CreatedWebsite);
            Assert.AreEqual(UpdatedWebsite.Name, CreatedWebsite.Name);
            Assert.AreEqual(UpdatedWebsite.Url, CreatedWebsite.Url);
            Assert.AreEqual(UpdatedWebsite.ServicePhone, CreatedWebsite.ServicePhone);
            Assert.AreEqual(UpdatedWebsite.ServiceEmail, CreatedWebsite.ServiceEmail);
            Assert.AreEqual(UpdatedWebsite.CheckoutPageUri, CreatedWebsite.CheckoutPageUri);

            // Load
            var LoadWebsite = RebillyClient.Websites().Load(UpdatedWebsite.Id);
            Assert.AreEqual(LoadWebsite.Name, UpdatedWebsite.Name);
            Assert.AreEqual(LoadWebsite.Url, UpdatedWebsite.Url);
            Assert.AreEqual(LoadWebsite.ServicePhone, UpdatedWebsite.ServicePhone);
            Assert.AreEqual(LoadWebsite.ServiceEmail, UpdatedWebsite.ServiceEmail);
            Assert.AreEqual(LoadWebsite.CheckoutPageUri, UpdatedWebsite.CheckoutPageUri);

            // Add two new sites
            var NewSite1 = CreateWebsite(GetNewWebsite());
            var NewSite2 = CreateWebsite(GetNewWebsite());

            // Search
            var Items = RebillyClient.Websites().Search();
            Assert.GreaterOrEqual(Items.Count, 3);


            // Delete
            DeleteWebsite(CreatedWebsite);
            DeleteWebsite(NewSite1);
            DeleteWebsite(NewSite2);

            var ItemsToDelete = RebillyClient.Websites().Search();
            foreach(var item in ItemsToDelete )
            {
                RebillyClient.Websites().Delete(item.Id);
            }

            // Test Not found exception
            try
            {
                RebillyClient.Websites().Delete(UpdatedWebsite.Id);
                Assert.True(false);
            }
            catch(NotFoundException ex)
            {
                Assert.IsInstanceOf<NotFoundException>(ex);
            }
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
                ServiceEmail = "support@gmail.com",
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