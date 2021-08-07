using LaunchShowcase.Sdk.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using OwlCore.Provisos;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk.ViewModels
{
    public class ProjectCollaboratorViewModel : ObservableObject, IAsyncInit
    {
        private readonly ProjectCollaborator _projectCollaborator;

        public ProjectCollaboratorViewModel(ProjectCollaborator projectCollaborator)
        {
            _projectCollaborator = projectCollaborator;
        }

        /// <inheritdoc/>
        public Task InitAsync()
        {
            IsInitialized = true;
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public bool IsInitialized { get; private set; }

        /// <inheritdoc/>
        public int Id => _projectCollaborator.Id;

        /// <inheritdoc/>
        public string Name => _projectCollaborator.Name;

        /// <inheritdoc/>
        public string DiscordId => _projectCollaborator.DiscordId;

        /// <inheritdoc/>
        public string Email => _projectCollaborator.Email;

        /// <inheritdoc/>
        public bool IsOwner => _projectCollaborator.IsOwner;

        /// <inheritdoc/>
        public Role Role => _projectCollaborator.Role;
    }
}
