namespace JsonPlaceholderApi.Models
{
    using System.Text.Json.Serialization;

    public class Address
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        [JsonPropertyName("geo")]
        public Coordinates Coordinates { get; set; }
    }
}