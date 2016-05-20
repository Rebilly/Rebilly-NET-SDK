
namespace Rebilly.Services
{
    public interface IPropertyBag
    {
        object this[string key] { get; set; }
        bool ContainsKey(string key);
        void CopyPropertiesTo(IPropertyBag targetBag);
    }
}
