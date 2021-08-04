using LaunchShowcase.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk.Services
{
    /// <summary>
    /// Provides access to projects and project information.
    /// </summary>
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

        public Task<string[]> GetProjectFeatures(long projectId)
        {
            return _restClient.SendAsync<string[]>($"/projects/features?projectId={projectId}", HttpMethod.Get);
        }

        public Task<Project> GetProjectById(long projectId)
        {
            return _restClient.SendAsync<Project>($"/projects/id/{projectId}", HttpMethod.Get);
        }

        /// <summary>
        /// Retreives the judged score for a <paramref name="project"/> in a specific <paramref name="category"/>.
        /// </summary>
        /// <returns>An integer between 0-100 indicating</returns>
        public int GetProjectCategoryScore(Project project, LaunchScoringCategory category)
        {
            // TODO - pull from JSON, to be filled out after judging is complete.
            return project.Id;
        }
    }
}