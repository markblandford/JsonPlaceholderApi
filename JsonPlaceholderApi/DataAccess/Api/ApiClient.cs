using System.Text.Json;

namespace JsonPlaceholderApi.DataAccess.Api
{
    public class ApiClient : IApiClient
    {

        private readonly CancellationToken _cancellationToken;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _cancellationToken = default;
            _httpClient = new HttpClient();

            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };
        }

        public async Task<TResult> GetAsync<TResult>(
            string url,
            JsonNamingPolicy? jsonNamingPolicy = null
            )
        {
            var response = await _httpClient.GetAsync(url, _cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                _options.PropertyNamingPolicy = jsonNamingPolicy;

                return await response.Content.ReadFromJsonAsync<TResult>(_options, _cancellationToken);
            }

            throw new IOException($"GET {url} status {response.StatusCode}");

        }
    }
}