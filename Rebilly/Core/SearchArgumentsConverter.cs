using System;
using System.Linq;
using System.Collections.Generic;

namespace Rebilly.Core
{
    public class SearchArgumentsConverter
    {
        public Dictionary<string, string> ToDictionary(SearchArguments searchArguments)
        {
            if(searchArguments == null)
            {
                throw new ArgumentNullException("searchArguments");
            }

            var ReturnArgs = new Dictionary<string, string>();

            if(searchArguments.Offset != Int32.MinValue)
            {
                ReturnArgs.Add("Offset", searchArguments.Offset.ToString());
            }

            if (searchArguments.Limit != Int32.MinValue)
            {
                ReturnArgs.Add("Limit", searchArguments.Limit.ToString());
            }

            if (!string.IsNullOrEmpty(searchArguments.Filter.Field) && searchArguments.Filter.Values.Count > 0)
            {
                string Filter = searchArguments.Filter.Field + ":" + string.Join(",",searchArguments.Filter.Values);
                ReturnArgs.Add("Filter", Filter);
            }

            return ReturnArgs;
        }


        public string ToQueryString(SearchArguments searchArguments)
        {
            var Lookup = ToDictionary(searchArguments);

            return string.Join(",", Lookup.Select((keyPair) => { return keyPair.Key + "=" + keyPair.Value; }).ToList());
        }
    }
}
