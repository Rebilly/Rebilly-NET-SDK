using System.Collections.Generic;

namespace Rebilly.Services
{
    public class PropertyBag
    {
        private Dictionary<string, object> _Properties = new Dictionary<string, object>();

        public object this[string key]
        {
            get
            {
                return _Properties[key];
            }
            set
            {
                if (!ContainsKey(key))
                {
                    _Properties.Add(key, value);
                }
                else
                {
                    _Properties[key] = value;
                }
            }
        }


        public bool ContainsKey(string key)
        {
            return _Properties.ContainsKey(key);
        }



        public void CopyPropertiesTo(IPropertyBag targetBag)
        {
            foreach(var pair in _Properties)
            {
                targetBag[pair.Key] = pair.Value;
            }
        }
    }
}
