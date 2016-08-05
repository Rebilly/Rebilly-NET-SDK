using Rebilly;
using Rebilly.Core;
using Rebilly.Middleware;

namespace Tests
{
    public class TestBase
    {
        protected Client CreateClient(bool useRebillySignagure = false)
        {
            var Config = new TestConfig();

            var ReturnClient = new Client(apiKey: Config.ApiKey, baseUrl: Client.SandboxHost);

            if (useRebillySignagure)
            {
                // Remove the ApiKey Middleware
                MiddlewareBase ApiKeyMiddleware = null;

                foreach (var middleware in ReturnClient.Middleware)
                {
                    if(middleware is ApiKeyAuthenticationMiddleware)
                    {
                        ApiKeyMiddleware = middleware;
                    }
                }

                ReturnClient.Middleware.Remove(ApiKeyMiddleware);

                var SignatureMiddleware = new SignatureAuthenticationMiddleware(ReturnClient);
                SignatureMiddleware.ApiKey = Config.ApiKey;
                SignatureMiddleware.ApiUser = Config.ApiUser;


                ReturnClient.Middleware.Add(SignatureMiddleware);
            }


            return ReturnClient;
        }
    }
}
