using System.Text.Json;

namespace JsonPlaceholderApi.DataAccess.Api
{
    public class ApiClient : IApiClient
    {

        private readonly CancellationToken _cancellationToken;
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _cancellationToken = default;
            _httpClient = new HttpClient();
        }

        public async Task<TResult> GetAsync<TResult>(
            string url,
            JsonSerializerOptions? jsonSerializerOptions = null
            )
        {
            var response = await _httpClient.GetAsync(url, _cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResult>(jsonSerializerOptions, _cancellationToken);
            }

            throw new IOException($"GET {url} status {response.StatusCode}");

        }
    }
}