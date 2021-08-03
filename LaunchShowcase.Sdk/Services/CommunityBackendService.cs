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

        }

        public ProjectsService ProjectsService { get; set; } = new ProjectsService();
    }
}
