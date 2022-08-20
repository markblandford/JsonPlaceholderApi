namespace JsonPlaceholderApi.Models
{
    using System.Text.Json.Serialization;

    public class Coordinates
    {
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("lng")]
        public string Longitude { get; set; }
    }
}