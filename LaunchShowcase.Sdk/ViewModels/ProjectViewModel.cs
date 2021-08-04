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

            PopulateImagesCommand = new AsyncRelayCommand(PopulateImages);
            PopulateFeaturesCommand = new AsyncRelayCommand(PopulateFeatures);
            PopulateCollaboratorsCommand = new AsyncRelayCommand(PopulateCollaborators);
        }

        public Task InitAsync()
        {
            IsInitialized = true;
            return PopulateImages();
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

        public Task PopulateCollaborators()
        {
            throw new NotImplementedException();
        }

        public bool HasMinimumInfoForLaunchShowcase()
        {
            return !string.IsNullOrWhiteSpace(AppIcon) &&
                   !string.IsNullOrWhiteSpace(AppName) &&
                   !string.IsNullOrWhiteSpace(Description) &&
                   !string.IsNullOrWhiteSpace(HeroImage);
        }
    }
}
