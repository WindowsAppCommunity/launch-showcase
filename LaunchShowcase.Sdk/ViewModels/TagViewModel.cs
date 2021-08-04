using LaunchShowcase.Sdk.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using OwlCore.Provisos;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk.ViewModels
{
    public class TagViewModel : ObservableObject, IAsyncInit
    {
        private readonly Tag _tag;

        public TagViewModel(Tag tag)
        {
            _tag = tag;
            Projects = new ObservableCollection<ProjectViewModel>();
        }

        public Task InitAsync()
        {
            IsInitialized = true;
            return Task.CompletedTask;
        }

        public bool IsInitialized { get; private set; }

        public int Id => _tag.Id;

        public string Name => _tag.Name;

        public string Icon => _tag.Icon;

        // TODO populate projects from GET tags on API.
        public ObservableCollection<ProjectViewModel> Projects { get; set; } 
    }
}
