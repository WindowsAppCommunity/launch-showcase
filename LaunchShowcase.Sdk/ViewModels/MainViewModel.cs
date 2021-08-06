using LaunchShowcase.Sdk.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using OwlCore.Extensions;
using OwlCore.Provisos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk.ViewModels
{
    /// <summary>
    /// The root view model that holds all data used by the application.
    /// </summary>
    public class MainViewModel : ObservableObject, IAsyncInit
    {
        private const int LAUNCH_YEAR = 2021;

        private readonly CommunityBackendService _backendService = CommunityBackendService.Instance;
        private List<ProjectViewModel> _unsortedLaunchProjects;
        private LaunchScoringCategory _sortingMode;

        public static MainViewModel Instance { get; set; } = new MainViewModel();

        public MainViewModel()
        {
            _unsortedLaunchProjects = new List<ProjectViewModel>();
            LaunchProjects = new ObservableCollection<ProjectViewModel>();

            ToggleProjectsSortingModeCommand = new RelayCommand<LaunchScoringCategory>(ToggleProjectsSortingMode);
        }

        /// <inheritdoc/>
        public Task InitAsync()
        {
            IsInitialized = true;

            return PopulateLaunchProjects();
        }

        /// <inheritdoc/>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// All projects participating in the event this year.
        /// </summary>
        public ObservableCollection<ProjectViewModel> LaunchProjects { get; set; }

        public IRelayCommand<LaunchScoringCategory> ToggleProjectsSortingModeCommand { get; }

        public LaunchScoringCategory SortingMode
        {
            get => _sortingMode;
            set => SetProperty(ref _sortingMode, value);
        }

        public bool HasFlexibilitySortingMode => (SortingMode & LaunchScoringCategory.Flexibility) == LaunchScoringCategory.Flexibility;

        public bool HasEmpathySortingMode => (SortingMode & LaunchScoringCategory.Empathy) == LaunchScoringCategory.Empathy;

        public bool HasBeautySortingMode => (SortingMode & LaunchScoringCategory.Beauty) == LaunchScoringCategory.Beauty;

        public bool HasPotentialSortingMode => (SortingMode & LaunchScoringCategory.Potential) == LaunchScoringCategory.Potential;

        public bool HasOriginalitySortingMode => (SortingMode & LaunchScoringCategory.Originality) == LaunchScoringCategory.Originality;

        public bool HasAccessiblitySortingMode => (SortingMode & LaunchScoringCategory.Accessiblity) == LaunchScoringCategory.Accessiblity;

        public async Task PopulateLaunchProjects()
        {
            var projectsRes = await _backendService.ProjectsService.GetLaunchProjects(LAUNCH_YEAR);

            await projectsRes.Projects.InParallel(async project =>
            {
                var projectVm = new ProjectViewModel(project);
                await projectVm.InitAsync();

                if (projectVm.HasMinimumInfoForLaunchShowcase())
                {
                    _unsortedLaunchProjects.Add(projectVm);
                    LaunchProjects.Add(projectVm);
                }
            });
        }

        private void ToggleProjectsSortingMode(LaunchScoringCategory category)
        {
            SortingMode ^= category;

            LaunchProjects.Clear();

            var sortedProjects = GetProjectsSortedByCategoriesScore(category);

            foreach (var project in sortedProjects)
                LaunchProjects.Add(project);

            UpdateHasSortingModeInpc();
        }

        private List<ProjectViewModel> GetProjectsSortedByCategoriesScore(LaunchScoringCategory category)
        {
            if (category == LaunchScoringCategory.None)
                return _unsortedLaunchProjects.ToList();

            var activeFlags = GetFlags(category).Select(x => (LaunchScoringCategory)x);

            var scoredProjects = new Dictionary<ProjectViewModel, double>();

            // Per project
            foreach (var project in _unsortedLaunchProjects)
            {
                var scores = new List<int>();

                // Get score for each category
                foreach (var flag in activeFlags)
                {
                    if (flag == LaunchScoringCategory.None)
                        continue;

                    var score = _backendService.ProjectsService.GetProjectCategoryScore(project.Id, flag & ~LaunchScoringCategory.None);

                    scores.Add(score);
                }

                // Average the scores across all categories
                var scoreAverage = scores.Average();
                scoredProjects.Add(project, scoreAverage);
            }

            // Order projects by score
            return scoredProjects.OrderBy(x => x.Value).Select(x => x.Key).ToList();
        }

        static IEnumerable<Enum> GetFlags(Enum input)
        {
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
        }

        private void UpdateHasSortingModeInpc()
        {
            OnPropertyChanged(nameof(HasFlexibilitySortingMode));
            OnPropertyChanged(nameof(HasEmpathySortingMode));
            OnPropertyChanged(nameof(HasBeautySortingMode));
            OnPropertyChanged(nameof(HasPotentialSortingMode));
            OnPropertyChanged(nameof(HasOriginalitySortingMode));
            OnPropertyChanged(nameof(HasAccessiblitySortingMode));
        }
    }
}
