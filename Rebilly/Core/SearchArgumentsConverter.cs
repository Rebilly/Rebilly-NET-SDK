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

            if (searchArguments.Filters != null)
            {
                var Filters = new List<string>();
                foreach (var filter in searchArguments.Filters)
                {
                    if (!string.IsNullOrEmpty(filter.Field) && filter.Values.Count > 0)
                    {
                        string LoweredField = char.ToLower(filter.Field[0]) + filter.Field.Substring(1, filter.Field.Length - 1);
                        string Filter = LoweredField + ":" + string.Join(",", filter.Values);
                        Filters.Add(Filter);
                    }
                }

                if (Filters.Count > 0)
                {
                    ReturnArgs.Add("Filter", string.Join(";", Filters));
                }
            }

            if (searchArguments.Sort.Count > 0)
            {
                ReturnArgs.Add("Sort", string.Join(",", searchArguments.Sort));
            }

            if (searchArguments.Fields.Count > 0)
            {
                ReturnArgs.Add("Fields", string.Join(",", searchArguments.Fields));
            }

            return ReturnArgs;
        }


        public string ToQueryString(SearchArguments searchArguments)
        {
            var Lookup = ToDictionary(searchArguments);

            return string.Join("&", Lookup.Select((keyPair) => { return keyPair.Key.ToLower() + "=" + keyPair.Value; }).ToList());
        }
    }
}
