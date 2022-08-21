using System.Collections.Generic;
using NSubstitute;
using Xunit;
using JsonPlaceholderApi.DataAccess.Api;
using JsonPlaceholderApi.Models;
using JsonPlaceholderApi.Services.UserService;
using JsonPlaceholderApi.DataAccess.Api.NamingPolicies;

namespace JsonPlaceholderApi.Tests.Services
{
    public class UserServiceTest
    {
        private readonly IApiClient apiClient;
        private readonly UserService userService;

        public UserServiceTest()
        {
            apiClient = Substitute.For<IApiClient>();

            userService = new UserService(apiClient);
        }

        [Fact]
        public async void GetUser__NoParameter_ReturnsAllUsers()
        {
            IList<User> expectedResults = new[]
            {
                Substitute.For<User>(),
                Substitute.For<User>(),
                Substitute.For<User>(),
                Substitute.For<User>(),
            };
            apiClient.GetAsync<IList<User>>(
                Arg.Any<string>(),
                Arg.Any<JsonPlaceholderNamingPolicy>()
            ).Returns(expectedResults);

            IList<User> result = await userService.GetUser();

            Assert.Equal(expectedResults, result);
        }
    }
}