using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OwlCore.Net.HttpClientHandlers;
using OwlCore.Provisos;

namespace LaunchShowcase.Sdk.Services
{
    public class CommunityBackendService
    {
        private static Uri _backendUri = new Uri("https://uwpcommunity-site-backend.herokuapp.com");
        private RestClient _restClient;

        public static CommunityBackendService Instance { get; set; }

        public CommunityBackendService(HttpClient client)
        {
            Instance = this;
            _restClient = new RestClient(_backendUri, NewtonsoftSerializer.Instance, client);
            ProjectsService = new ProjectsService(_restClient);
        }

        public ProjectsService ProjectsService { get; }
    }
}
