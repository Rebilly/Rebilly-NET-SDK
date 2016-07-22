using Rebilly;

namespace Tests
{
    public class TestBase
    {
        protected Client CreateClient()
        {
            var Config = new TestConfig();
            return new Client(apiKey: Config.RebillyApiKey, baseUrl: Client.SandboxHost);
        }
    }
}
