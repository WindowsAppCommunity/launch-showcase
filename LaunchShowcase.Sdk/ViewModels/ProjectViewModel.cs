using LaunchShowcase.Sdk.Models;
using LaunchShowcase.Sdk.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using OwlCore.Provisos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk.ViewModels
{
    public class ProjectViewModel : ObservableObject, IAsyncInit
    {
        private readonly Project _project;
        private readonly CommunityBackendService _backendService = CommunityBackendService.Instance;

        public ProjectViewModel(Project project)
        {
            _project = project;

            Images = new ObservableCollection<string>();
            Features = new ObservableCollection<string>();
            Tags = new ObservableCollection<TagViewModel>(project.Tags.Select(x => new TagViewModel(x)));

            Collaborators = new ObservableCollection<ProjectCollaboratorViewModel>();
            Developers = new ObservableCollection<ProjectCollaboratorViewModel>();
            BetaTesters = new ObservableCollection<ProjectCollaboratorViewModel>();
            Translators = new ObservableCollection<ProjectCollaboratorViewModel>();

            PopulateImagesCommand = new AsyncRelayCommand(PopulateImages);
            PopulateFeaturesCommand = new AsyncRelayCommand(PopulateFeatures);
            PopulateCollaboratorsCommand = new AsyncRelayCommand(PopulateCollaborators);
        }

        public Task InitAsync()
        {
            IsInitialized = true;
            return PopulateFeatures();
        }

        /// <inheritdoc/>
        public bool IsInitialized { get; private set; }

        /// <inheritdoc/>
        public int Id => _project.Id;

        /// <inheritdoc/>
        public string AppName => _project.AppName;

        /// <inheritdoc/>
        public string Description => _project.Description;

        /// <inheritdoc/>
        public bool IsPrivate => _project.IsPrivate;

        /// <inheritdoc/>
        public string DownloadLink => _project.DownloadLink;

        /// <inheritdoc/>
        public string GithubLink => _project.GithubLink;

        /// <inheritdoc/>
        public string ExternalLink => _project.ExternalLink;

        /// <inheritdoc/>
        public string HeroImage => _project.HeroImage;

        /// <inheritdoc/>
        public ObservableCollection<string> Images { get; }

        /// <inheritdoc/>
        public ObservableCollection<string> Features { get; }

        /// <inheritdoc/>
        public string AppIcon => _project.AppIcon;

        /// <inheritdoc/>
        public string AccentColor => _project.AccentColor;

        /// <inheritdoc/>
        public bool? AwaitingLaunchApproval => _project.AwaitingLaunchApproval;

        /// <inheritdoc/>
        public bool NeedsManualReview => _project.NeedsManualReview;

        /// <inheritdoc/>
        public string LookingForRoles => _project.LookingForRoles;

        /// <inheritdoc/>
        public ObservableCollection<ProjectCollaboratorViewModel> Collaborators { get; }

        /// <summary>
        /// The owner of the project.
        /// </summary>
        public ProjectCollaboratorViewModel ProjectOwner => Collaborators.First(x => x.IsOwner);

        /// <summary>
        /// All <see cref="Collaborators"/> who are a <see cref="Role.Developer"/>.
        /// </summary>
        public ObservableCollection<ProjectCollaboratorViewModel> Developers { get; private set; }

        /// <summary>
        /// All <see cref="Collaborators"/> who are a <see cref="Role.BetaTester"/>.
        /// </summary>
        public ObservableCollection<ProjectCollaboratorViewModel> BetaTesters { get; private set; }

        /// <summary>
        /// All <see cref="Collaborators"/> who are a <see cref="Role.Translator"/>.
        /// </summary>
        public ObservableCollection<ProjectCollaboratorViewModel> Translators { get; private set; }

        /// <inheritdoc/>
        public ObservableCollection<TagViewModel> Tags { get; }

        /// <inheritdoc/>
        public string Category => _project.Category;

        public DateTime CreatedAt => _project.CreatedAt;

        public DateTime UpdatedAt => _project.UpdatedAt;

        public IAsyncRelayCommand PopulateImagesCommand { get; }

        public IAsyncRelayCommand PopulateFeaturesCommand { get; }

        public IAsyncRelayCommand PopulateCollaboratorsCommand { get; }

        public async Task PopulateImages()
        {
            var images = await _backendService.ProjectsService.GetProjectImages(Id);

            foreach (var image in images)
                Images.Add(image);
        }

        public async Task PopulateFeatures()
        {
            var features = await _backendService.ProjectsService.GetProjectFeatures(Id);

            foreach (var feature in features)
                Features.Add(feature);
        }

        public async Task PopulateCollaborators()
        {
            var collaborators = await _backendService.ProjectsService.GetProjectCollaborators(Id);

            Collaborators.Clear();
            Developers.Clear();
            BetaTesters.Clear();
            Translators.Clear();

            foreach (var collaborator in collaborators)
            {
                if (!string.IsNullOrWhiteSpace(collaborator.Name))
                    Collaborators.Add(new ProjectCollaboratorViewModel(collaborator));
            }

            foreach (var developer in Collaborators.Where(x => x.Role == Role.Developer))
                Developers.Add(developer);

            foreach (var tester in Collaborators.Where(x => x.Role == Role.BetaTester))
                BetaTesters.Add(tester);

            foreach (var translator in Collaborators.Where(x => x.Role == Role.Translator))
                Translators.Add(translator);
        }

        public bool HasMinimumInfoForLaunchShowcase()
        {
            var hasEnoughFeaturesListed = Features.Count >= 2;

            return hasEnoughFeaturesListed &&
                   !string.IsNullOrWhiteSpace(AppIcon) &&
                   !string.IsNullOrWhiteSpace(AppName) &&
                   !string.IsNullOrWhiteSpace(Description) &&
                   !string.IsNullOrWhiteSpace(HeroImage);
        }
    }
}
