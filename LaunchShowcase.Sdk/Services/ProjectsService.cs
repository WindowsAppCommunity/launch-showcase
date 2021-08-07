using LaunchShowcase.Sdk.Data;
using LaunchShowcase.Sdk.Data.LaunchScoring;
using LaunchShowcase.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public Task<ProjectCollaborator[]> GetProjectCollaborators(long projectId)
        {
            return _restClient.SendAsync<ProjectCollaborator[]>($"/projects/collaborators?projectId={projectId}", HttpMethod.Get);
        }

        public Task<Project> GetProjectById(long projectId)
        {
            return _restClient.SendAsync<Project>($"/projects/id/{projectId}", HttpMethod.Get);
        }

        /// <summary>
        /// Retreives the judged score for a <paramref name="projectId"/> in a specific <paramref name="category"/>.
        /// </summary>
        /// <returns>An integer between 0-100 indicating the score given to the <paramref name="projectId"/> for the given <paramref name="category"/>.</returns>
        public int GetProjectCategoryScore(long projectId, LaunchScoringCategory category)
        {
            var projectRanking = LaunchData.Scoring[category];

            foreach (var rankedProject in projectRanking)
            {
                if (rankedProject.Key == projectId)
                    return rankedProject.Value;
            }

            Debug.WriteLine($"ERROR: ProjectId {projectId} was not found in scoring data. Returning 0 as a fallback");
            return 0;
        }
    }
}