using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using Rebilly.Entities;

namespace Rebilly.Core
{
    public class GatewayAccountJsonCreationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(GatewayAccount));
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var LoadedObject = JObject.Load(reader);

            var Destination = new GatewayAccount();

            if (LoadedObject["gatewayName"].ToString() == "A1Gateway")
            {
                Destination.GatewayConfig = new A1GatewayConfig();
            }

            serializer.Populate(LoadedObject.CreateReader(), Destination);
            return Destination;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
