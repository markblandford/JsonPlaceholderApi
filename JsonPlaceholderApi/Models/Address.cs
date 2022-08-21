namespace JsonPlaceholderApi.Models
{
    public class Address
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public Coordinates Coordinates { get; set; }
    }
}