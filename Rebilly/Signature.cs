using System;
using System.Text;
using System.Security.Cryptography;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Rebilly.Core;

namespace Rebilly
{
    public class Signature
    {
        public const int NONCE_LENGTH = 30;

        /// <summary>
        /// Generate signature
        /// </summary>
        /// <param name="apiUser"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public string Generate(string apiUser, string apiKey)
        {
            var Nonce = GenerateNonce(NONCE_LENGTH);
            var CurrentTime = DateTime.UtcNow;
            string Data = apiUser + Nonce + CurrentTime;

            var CurrentEncoding = Encoding.UTF8;
            var HMAC = new HMACSHA1(CurrentEncoding.GetBytes(apiKey));
            HMAC.Initialize();

            byte[] Buffer = CurrentEncoding.GetBytes(Data);
            var Signature = BitConverter.ToString(HMAC.ComputeHash(Buffer)).Replace("-", "").ToLower();

            var AuthObject = new JObject();
            AuthObject.Add(new JProperty("REB-APIUSER", apiUser));
            AuthObject.Add(new JProperty("REB-NONCE", Nonce));
            AuthObject.Add(new JProperty("REB-TIMESTAMP", CurrentTime.ToString()));
            AuthObject.Add(new JProperty("REB-SIGNATURE", Signature));

            var AuthText = AuthObject.ToString(Formatting.None);
            return Convert.ToBase64String(CurrentEncoding.GetBytes(AuthText));
        }


        /// <summary>
        /// Generate random string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string GenerateNonce(int length)
        {
            var Random = new RNGCryptoServiceProvider();
            
            var TokenData = new byte[length];
            Random.GetBytes(TokenData);

            return Convert.ToBase64String(TokenData).Substring(0, length);
        }
    }
}