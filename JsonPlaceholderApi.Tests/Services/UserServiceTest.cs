namespace JsonPlaceholderApi.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using NSubstitute;
    using Xunit;
    using JsonPlaceholderApi.DataAccess.Api;
    using JsonPlaceholderApi.Services.UserService;
    using JsonPlaceholderApi.Models;

  public class UserServiceTest : IDisposable
    {
        private bool disposedValue;
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
            IList<IUser> expectedResults = new[]
            {
                Substitute.For<IUser>(),
                Substitute.For<IUser>(),
                Substitute.For<IUser>(),
                Substitute.For<IUser>(),
            };
            apiClient.GetAsync<IList<IUser>>(Arg.Any<string>()).Returns(expectedResults);

            IList<IUser> result = await userService.GetUser();

            Assert.Equal(expectedResults, result);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}