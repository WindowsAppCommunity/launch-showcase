using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk
{
    public class RestClient
    {
        private readonly HttpClient _client;
        private readonly Uri _baseUri;
        private readonly ISerializer _serializer;

        public RestClient(Uri baseUri, ISerializer serializer)
        {
            _baseUri = baseUri;
            _serializer = serializer;
            _client = new HttpClient();
        }

        public RestClient(Uri baseUri, ISerializer serializer, HttpClientHandler handler)
        {
            _baseUri = baseUri;
            _serializer = serializer;
            _client = new HttpClient(handler);
        }

        public async Task<T> SendAsync<T>(string relativePath, HttpMethod method)
        {
            var reqMsg = new HttpRequestMessage(method, new Uri(_baseUri, relativePath));

            var res = await _client.SendAsync(reqMsg);
            res.EnsureSuccessStatusCode();

            var content = await res.Content.ReadAsStringAsync();

            return _serializer.Deserialize<T>(content);
        }
    }
}
