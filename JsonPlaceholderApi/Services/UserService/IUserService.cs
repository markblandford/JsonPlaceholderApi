using JsonPlaceholderApi.Models;

namespace JsonPlaceholderApi.Services.UserService
{
    /// <summary> User Service. </summary>
    public interface IUserService
    {
        /// <summary> Get all users. </summary>
        /// <returns> The Users. </returns>
        public Task<IList<User>> GetUser();

        /// <summary> Get the user details. </summary>
        /// <param name="id"> The id of the user. </param>
        /// <returns> The User or null if not found. </returns>
        public Task<User?> GetUser(string id);
    }
}