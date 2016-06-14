using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Rebilly.Services
{
    internal class JsonSerializeCreatePropertiesResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var Properties = base.CreateProperties(type, memberSerialization);
            var FilteredProperties = Properties.Where(p => (p.PropertyName != "Id" && p.PropertyName != "CreatedTime" && p.PropertyName != "UpdatedTime")).ToList();

            FilteredProperties = FilteredProperties.Select(p => { p.PropertyName = char.ToLower(p.PropertyName[0]) +  p.PropertyName.Substring(1, p.PropertyName.Length - 1); return p; }).ToList();

            return FilteredProperties;
        }
    }
}
