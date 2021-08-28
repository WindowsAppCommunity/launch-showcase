using LaunchShowcase.Sdk.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace LaunchShowcase.Themes.ShowcaseTemplates
{
    public sealed partial class FluentStoreControl : UserControl
    {
        public FluentStoreControl()
        {
            this.InitializeComponent();
        }

        private async void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectViewModel project = (ProjectViewModel)DataContext;
            var dialog = new ContentDialog()
            {
                Title = new TextBlock()
                {
                    Text = project.AppName,
                    FontSize = 24,
                    FontWeight = FontWeights.Bold
                },
                Content = new ScrollViewer()
                {
                    Content = new TextBlock()
                    {
                        Text = project.Description,
                        TextWrapping = TextWrapping.Wrap
                    }
                },
                PrimaryButtonText = "Close",
                IsSecondaryButtonEnabled = false
            };
            await dialog.ShowAsync();
            return;
        }

        private void HeroImage_SizeChanged(object sender, RoutedEventArgs e)
        {
            UpdateHeroImageSpacer((FrameworkElement)sender);
        }

        private void InfoCard_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateHeroImageSpacer(HeroImage);
        }

        private void UpdateHeroImageSpacer(FrameworkElement imageElem)
        {
            // Height of the card including padding and spacing
            double cardHeight = InfoCard.ActualHeight + InfoCard.Margin.Top + InfoCard.Margin.Bottom
                + ((StackPanel)ContentScroller.Content).Spacing * 2;

            // Required amount of additional spacing to place the card at the bottom of the hero image,
            // or at the bottom of the page (whichever places the card higher up)
            double offset = Math.Min(imageElem.ActualHeight - cardHeight, ActualHeight - cardHeight);
            HeroImageSpacer.Height = Math.Max(offset, 0);
        }
    }
}
