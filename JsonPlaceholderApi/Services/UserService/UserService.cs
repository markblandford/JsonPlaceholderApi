using JsonPlaceholderApi.DataAccess.Api;
using JsonPlaceholderApi.DataAccess.Api.NamingPolicies;
using JsonPlaceholderApi.Models;

namespace JsonPlaceholderApi.Services.UserService
{
    public class UserService : IUserService {

        private const string _url = "https://jsonplaceholder.typicode.com/users";
        private readonly IApiClient _apiClient;
        private readonly JsonPlaceholderNamingPolicy _jsonNamingPolicy;

        public UserService(IApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonNamingPolicy = new JsonPlaceholderNamingPolicy();
        }

        public async Task<IList<User>> GetUser()
        {
            IList<User> results = await _apiClient.GetAsync<IList<User>>(_url, _jsonNamingPolicy);
            return results;
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }

}