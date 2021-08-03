using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OwlCore.Provisos;

namespace LaunchShowcase.Sdk.Services
{
    public class CommunityBackendService
    {
        public CommunityBackendService()
        {
            var restClient = new RestClient(new Uri("https://uwpcommunity-site-backend.herokuapp.com"), NewtonsoftSerializer.Instance);

            ProjectsService = new ProjectsService(restClient);
        }

        public ProjectsService ProjectsService { get; }
    }
}
