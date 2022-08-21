using JsonPlaceholderApi.Models;
using JsonPlaceholderApi.Services.UserService;

namespace JsonPlaceHolderApi
{
    public static class GetRoutes
    {

        public static void MapRoutes(
            this IEndpointRouteBuilder app,
            IUserService userService
            )
        {
            app.MapGet("/user", () => GetAllUsers(userService));
            app.MapGet("/user/{id}", (string id) => GetUser(id, userService));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of all users</returns>
        private static async Task<IList<User>> GetAllUsers(IUserService userService)
        {
            return await userService.GetUser();
        }

        /// <summary>
        /// Get a users by ID
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>The user</returns>
        private static async Task<IResult> GetUser(string id, IUserService userService)
        {
            var user = await userService.GetUser(id);

            return user is not null ? Results.Ok(user) : Results.NotFound();
        }
    }
}