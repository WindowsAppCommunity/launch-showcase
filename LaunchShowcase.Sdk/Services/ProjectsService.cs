using LaunchShowcase.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LaunchShowcase.Sdk.Services
{
    public class ProjectsService
    {
        private RestClient _restClient;

        public ProjectsService()
        {
            _restClient = new RestClient(new Uri("https://uwpcommunity-site-backend.herokuapp.com"), NewtonsoftSerializer.Instance);
        }

        public Task<List<Project>> GetProjects()
        {
            return _restClient.SendAsync<List<Project>>("projects", HttpMethod.Get);
        }

        /*        [Get("/projects/launch/{year}")]
                public Task<Project[]> GetLaunchProjects(uint year);

                [Get("/projects/images?projectId={projectId}")]
                public Task<string[]> GetProjectImages(long projectId);

                [Get("/projects/id/{projectId}")]
                public Task<Project> GetProjectById(long projectId);*/
    }

    public class NewtonsoftSerializer : ISerializer
    {
        public static NewtonsoftSerializer Instance { get; } = new NewtonsoftSerializer();

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }

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
