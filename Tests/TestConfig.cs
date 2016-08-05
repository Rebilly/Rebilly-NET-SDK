using System;
using System.IO;

using NUnit.Framework;

namespace Tests
{
    public class TestConfig
    {
        public string ApiKey { get; set; }
        public string ApiUser { get; set; }


        public TestConfig()
        {
            LoadFromEnvironmentOrFile();
        }


        public void LoadFromEnvironmentOrFile()
        {
            string EnvironmentApiKey = Environment.GetEnvironmentVariable("ApiKey");
            string EnvironmentApiUser = Environment.GetEnvironmentVariable("ApiUser");

            if (!string.IsNullOrEmpty(EnvironmentApiKey) && !string.IsNullOrEmpty(EnvironmentApiUser))
            {
                ApiKey = EnvironmentApiKey;
                ApiUser = EnvironmentApiUser;
            }
            else
            {
                string ApiSettingsFile = TestContext.CurrentContext.TestDirectory + Path.DirectorySeparatorChar + "ApiSettings.txt";

                if (File.Exists(ApiSettingsFile))
                {                    
                    using(var FileStream = File.OpenRead(ApiSettingsFile))
                    using (var Stream = new StreamReader(FileStream))
                    {
                        if (!Stream.EndOfStream)
                        {
                            ApiKey = Stream.ReadLine();
                        }

                        if (!Stream.EndOfStream)
                        {
                            ApiUser = Stream.ReadLine();
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(ApiKey))
            {
                throw new Exception("Cannot find ApiKey");
            }

            if (string.IsNullOrEmpty(ApiUser))
            {
                throw new Exception("Cannot find ApiUser");
            }
        }

    }
}
