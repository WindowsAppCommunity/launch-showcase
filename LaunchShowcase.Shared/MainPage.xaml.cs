using LaunchShowcase.Sdk.ViewModels;
using OwlCore.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace LaunchShowcase
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel => (MainViewModel)DataContext;
        private string _param;

        public MainPage()
        {
            InitializeComponent();

            DataContext = MainViewModel.Instance;

            ViewModel.LaunchProjectsLoaded += ViewModel_Initialized;
        }

        private void ViewModel_Initialized(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_param))
            {
                if (_param.Contains("project="))
                {
                    var idStr = _param.Replace("project=", "");

                    if (!string.IsNullOrWhiteSpace(idStr) && int.TryParse(idStr, out var projectId))
                    {
                        _ = NavigateToProject(projectId);
                    }
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _param = e.Parameter.ToString();
        }

        public async void LaunchProjectsGrid_ItemClicked(object sender, RoutedEventArgs e)
        {
            var projectId = sender.Cast<FrameworkElement>().Tag;
            await NavigateToProject((int)projectId);
        }

        private async Task NavigateToProject(int projectId)
        {
            var project = ViewModel.LaunchProjects.FirstOrDefault(x => projectId == x.Id);
            if (project is null)
                return;

            await project.PopulateCollaborators();

            PART_Overlay.Visibility = Visibility.Visible;
            PART_ShowcasePresenter.Content = project;
        }

        public void LaunchProjectGrid_PointerOver(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, e.Pointer.PointerId);
        }

        public void LaunchProjectGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, e.Pointer.PointerId);
        }

        public void OverlayClose_Clicked(object sender, RoutedEventArgs e)
        {
            PART_Overlay.Visibility = Visibility.Collapsed;
            PART_ShowcasePresenter.Content = null;
        }
    }
}
