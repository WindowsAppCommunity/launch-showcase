using LaunchShowcase.Sdk.HttpClientHandlers;
using LaunchShowcase.Sdk.ViewModels;
using OwlCore.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public MainPage()
        {
            InitializeComponent();

            DataContext = MainViewModel.Instance;
        }

        public async void LaunchProjectsGrid_ItemClicked(object sender, RoutedEventArgs e)
        {
            var projectId = sender.Cast<FrameworkElement>().Tag;
            var project = ViewModel.LaunchProjects.First(x => (int)projectId == x.Id);

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
