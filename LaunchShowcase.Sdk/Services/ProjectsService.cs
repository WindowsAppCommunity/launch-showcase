using LaunchShowcase.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk.Services
{
    public class ProjectsService
    {
        private RestClient _restClient;

        public ProjectsService(RestClient client)
        {
            _restClient = client;
        }

        public Task<Project[]> GetProjects()
        {
            return _restClient.SendAsync<Project[]>("projects", HttpMethod.Get);
        }

        public Task<LaunchProjectsResponse> GetLaunchProjects(uint year)
        {
            return _restClient.SendAsync<LaunchProjectsResponse>($"/projects/launch/{year}", HttpMethod.Get);
        }

        public Task<string[]> GetProjectImages(long projectId)
        {
            return _restClient.SendAsync<string[]>($"/projects/images?projectId={projectId}", HttpMethod.Get);
        }

        public Task<Project> GetProjectById(long projectId)
        {
            return _restClient.SendAsync<Project>($"/projects/id/{projectId}", HttpMethod.Get);
        }
    }
}
