using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace LaunchShowcase.Themes.ShowcaseTemplates.JitHubControls
{
    public sealed partial class DesignControl : UserControl
    {
        public DesignControl()
        {
            this.InitializeComponent();
            var images = new List<ImageSource>()
            {
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/repo-1.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/commits.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/commits-1.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/home.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/home-1.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/issues.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/issues-1.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/issues-2.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/new_issue.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/no_issues_found.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/repo.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/repo-1.png")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/commits.png")),
            };
            MyContent.Children.Add(new JitHubFlipView(images));
        }
    }
}
