using LaunchShowcase.Sdk.Services;
using OwlCore.Extensions;
using OwlCore.Provisos;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk.ViewModels
{
    /// <summary>
    /// The root view model that holds all data used by the application.
    /// </summary>
    public class MainViewModel : IAsyncInit
    {
        private readonly CommunityBackendService _backendService = CommunityBackendService.Instance;

        /// <summary>
        /// The year to use when retrieving launch projects.
        /// </summary>
        public const int LaunchYear = 2021;

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static MainViewModel Instance { get; set; } = new MainViewModel();

        public MainViewModel()
        {
            LaunchProjects = new ObservableCollection<ProjectViewModel>();
        }

        /// <inheritdoc/>
        public bool IsInitialized { get; private set; }

        /// <inheritdoc/>
        public Task InitAsync()
        {
            IsInitialized = true;

            return PopulateLaunchProjects();
        }

        /// <summary>
        /// All projects participating in the event this year.
        /// </summary>
        public ObservableCollection<ProjectViewModel> LaunchProjects { get; set; }

        public async Task PopulateLaunchProjects()
        {
            var projectsRes = await _backendService.ProjectsService.GetLaunchProjects(LaunchYear);

            await projectsRes.Projects.InParallel(async project =>
            {
                var projectVm = new ProjectViewModel(project);
                await projectVm.InitAsync();

                if (projectVm.HasMinimumInfoForLaunchShowcase())
                {
                    LaunchProjects.Add(projectVm);
                }
            });
        }
    }
}
