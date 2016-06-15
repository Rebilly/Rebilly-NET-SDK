using System;
using System.IO;

using NUnit.Framework;

namespace Tests
{
    public class TestConfig
    {
        public string RebillyApiKey { get; set; }

        public TestConfig()
        {
            LoadApiKeyFromEnvironmentOrApiKeyFile();
        }


        public void LoadApiKeyFromEnvironmentOrApiKeyFile()
        {
            string EnvironmentRebillyApiKey = Environment.GetEnvironmentVariable("RebillyAPIKey");
            if(!string.IsNullOrEmpty(EnvironmentRebillyApiKey))
            {
                RebillyApiKey = EnvironmentRebillyApiKey;
            }
            else
            {
                string ApiKeyFile = TestContext.CurrentContext.TestDirectory + Path.DirectorySeparatorChar + "ApiKey.txt";

                if(File.Exists(ApiKeyFile))
                {
                    RebillyApiKey = File.ReadAllText(ApiKeyFile).Trim();
                }
            }

            if(string.IsNullOrEmpty(RebillyApiKey))
            {
                throw new Exception("Cannot find ApiKey");
            }
        }

    }
}
