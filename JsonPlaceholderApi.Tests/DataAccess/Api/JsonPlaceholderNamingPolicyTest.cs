using System;
using Xunit;
using JsonPlaceholderApi.DataAccess.Api.NamingPolicies;

namespace JsonPlaceholderApi.Tests.DataAccess.Api.NamingPolicies
{
    public class JsonPlaceholderNamingPolicyTest
    {
        private readonly JsonPlaceholderNamingPolicy _namingPolicy;

        public JsonPlaceholderNamingPolicyTest()
        {
            _namingPolicy = new JsonPlaceholderNamingPolicy();
        }

        [Fact]
        public void ConvertName_Coordinates_To_GeoInLowerCase()
        {
            string actual = _namingPolicy.ConvertName("Coordinates");

            Assert.Equal("geo", actual);
        }

        [Fact]
        public void ConvertName_Business_To_BsInLowerCase()
        {
            string actual = _namingPolicy.ConvertName("Business");

            Assert.Equal("bs", actual);
        }

        [Fact]
        public void ConvertName_Latitude_To_LatInLowerCase()
        {
            string actual = _namingPolicy.ConvertName("Latitude");

            Assert.Equal("lat", actual);
        }

        [Fact]
        public void ConvertName_Longitude_To_LngInLowerCase()
        {
            string actual = _namingPolicy.ConvertName("Longitude");

            Assert.Equal("lng", actual);
        }
    }
}