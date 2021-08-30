using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace LaunchShowcase.Themes.ShowcaseTemplates.JitHubControls
{
    public sealed partial class LogosControl : UserControl
    {
        public LogosControl()
        {
            this.InitializeComponent();
            var images = new List<ImageSource>()
            {
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/1.jpg")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/2.jpg")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/3.jpg")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/4.jpg")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/5.jpg")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/6.jpg")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/7.jpg")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/8.jpg")),
                new BitmapImage(new Uri("https://nerocui.files.wordpress.com/2021/08/9.jpg"))
            };
            MyContent.Children.Add(new JitHubFlipView(images));
        }
    }
}
