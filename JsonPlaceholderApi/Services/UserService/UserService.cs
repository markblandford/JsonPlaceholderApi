using System.Text.Json;
using JsonPlaceholderApi.DataAccess.Api;
using JsonPlaceholderApi.DataAccess.Api.NamingPolicies;
using JsonPlaceholderApi.Models;

namespace JsonPlaceholderApi.Services.UserService
{
    /// <inheritdoc/>
    public class UserService : IUserService {

        private const string _url = "https://jsonplaceholder.typicode.com/users";
        private readonly IApiClient _apiClient;
        private readonly JsonSerializerOptions _jsonSerializer;

        public UserService(IApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonSerializer = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = new JsonPlaceholderNamingPolicy()
            };
        }

        /// <inheritdoc/>
        public async Task<IList<User>> GetUser()
        {
            IList<User> results = await _apiClient.GetAsync<IList<User>>(_url, _jsonSerializer);
            return results;
        }

        /// <inheritdoc/>
        public async Task<User?> GetUser(string id)
        {
            return (await GetUser()).FirstOrDefault<User>(u => u.Id.ToString() == id);
        }
    }

}