using LaunchShowcase.Sdk.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk.Services
{
    public class ProjectsService
    {
        private RestClient _restClient;

        public ProjectsService()
        {
            _restClient = new RestClient("https://uwpcommunity-site-backend.herokuapp.com");
        }

        public async Task<List<Project>> GetProjects()
        {
            var request = new RestRequest("projects", Method.GET);
            var res = await _restClient.ExecuteAsync<List<Project>>(request);

            return res.Data;
        }

        /*        [Get("/projects/launch/{year}")]
                public Task<Project[]> GetLaunchProjects(uint year);

                [Get("/projects/images?projectId={projectId}")]
                public Task<string[]> GetProjectImages(long projectId);

                [Get("/projects/id/{projectId}")]
                public Task<Project> GetProjectById(long projectId);*/
    }
}
