namespace JsonPlaceholderApi.DataAccess.Api
{
    using System.Net.Http.Json;
    using System.Text.Json;

    public class ApiClient : IApiClient
    {

        private readonly CancellationToken _cancellationToken;
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _cancellationToken = default;
            _httpClient = new HttpClient();
        }

        public async Task<TResult> GetAsync<TResult>(string url)
        {
            var response = await _httpClient.GetAsync(url, _cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResult>();
            }

            throw new IOException($"GET {url} status {response.StatusCode}");
        }
    }
}