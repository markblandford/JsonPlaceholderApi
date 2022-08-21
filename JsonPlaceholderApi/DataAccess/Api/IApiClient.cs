using System.Text.Json;

namespace JsonPlaceholderApi.DataAccess.Api
{
    public interface IApiClient
    {
        Task<TResult> GetAsync<TResult>(string url, JsonNamingPolicy? jsonNamingPolicy = null);
    }
}