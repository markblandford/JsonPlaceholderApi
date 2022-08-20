namespace JsonPlaceholderApi.Models
{
    using System.Text.Json.Serialization;

    public class Company
    {
        public string Name { get; set; }

        public string CatchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string Business { get; set; }
    }
}