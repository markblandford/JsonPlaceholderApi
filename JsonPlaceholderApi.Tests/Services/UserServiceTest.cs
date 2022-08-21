using System.Collections.Generic;
using System.Text.Json;
using NSubstitute;
using Xunit;
using FluentAssertions;
using JsonPlaceholderApi.DataAccess.Api;
using JsonPlaceholderApi.Models;
using JsonPlaceholderApi.Services.UserService;

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
                Arg.Any<JsonSerializerOptions>()
            ).Returns(expectedResults);

            IList<User> result = await userService.GetUser();

            result.Should().BeSameAs(expectedResults);
        }

        [Fact]
        public async void GetUser_HasIdParameter_ReturnsSingleUserWithTheGivenId()
        {
            string id = "1";

            User expected = Substitute.For<User>();
            expected.Id = int.Parse(id);

            IList<User> allUsers = new[]
            {
                Substitute.For<User>(),
                Substitute.For<User>(),
                expected,
                Substitute.For<User>(),
            };

            userService.GetUser().Returns(allUsers);

            User result = await userService.GetUser(id);

            result.Should().BeSameAs(expected);
        }
    }
}