using System.Reflection.Metadata;
using System.Text.Json;

namespace JsonPlaceholderApi.DataAccess.Api.NamingPolicies
{
  public class JsonPlaceholderNamingPolicy : JsonNamingPolicy
  {
    private readonly Dictionary<string, string> _propertyNameMap = new Dictionary<string, string>
    {
        // class property / json value
        { "Business", "bs" },
        { "Coordinates", "geo" },
        { "Latitude", "lat" },
        { "Longitude", "lng" },
    };

    public override string ConvertName(string name) =>
        _propertyNameMap.GetValueOrDefault(name, name);
  }
}