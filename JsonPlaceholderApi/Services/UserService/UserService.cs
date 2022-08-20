namespace JsonPlaceholderApi.Services.UserService
{
    using JsonPlaceholderApi.DataAccess.Api;
    using JsonPlaceholderApi.Models;

    public class UserService : IUserService {

        private const string _url = "https://jsonplaceholder.typicode.com/users";
        private readonly IApiClient _apiClient;

        public UserService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<IList<User>> GetUser()
        {
            return _apiClient.GetAsync<IList<User>>(_url);
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }

}