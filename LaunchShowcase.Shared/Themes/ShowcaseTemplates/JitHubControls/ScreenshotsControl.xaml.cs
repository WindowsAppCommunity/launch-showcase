using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace LaunchShowcase.Themes.ShowcaseTemplates.JitHubControls
{
    public sealed partial class ScreenshotsControl : UserControl
    {
        private List<ImageSource> images = new List<ImageSource>()
        {
            new BitmapImage(new Uri("https://i.ibb.co/q0rzGs0/light-login.png")),
            new BitmapImage(new Uri("https://i.ibb.co/GdG0CxB/light-dashboard.png")),
            new BitmapImage(new Uri("https://i.ibb.co/V29yBWP/light-code.png")),
            new BitmapImage(new Uri("https://i.ibb.co/QD6d32T/light-issue.png")),
            new BitmapImage(new Uri("https://i.ibb.co/MpG0cgR/light-issue-detail.png")),
            new BitmapImage(new Uri("https://i.ibb.co/rddkMTk/light-pr.png")),
            new BitmapImage(new Uri("https://i.ibb.co/f9Z2mBw/light-pr-detail.png")),
            new BitmapImage(new Uri("https://i.ibb.co/rt8WMLg/light-commits.png")),
            new BitmapImage(new Uri("https://i.ibb.co/MRs3JNn/light-commits-detail.png")),
            new BitmapImage(new Uri("https://i.ibb.co/LRDpD9k/dark-login.png")),
            new BitmapImage(new Uri("https://i.ibb.co/r3NjvvJ/dark-dashboard.png")),
            new BitmapImage(new Uri("https://i.ibb.co/4YWmjvL/dark-code.png")),
            new BitmapImage(new Uri("https://i.ibb.co/9NqPrPf/dark-issue.png")),
            new BitmapImage(new Uri("https://i.ibb.co/CtLB3CN/dark-issue-detail.png")),
            new BitmapImage(new Uri("https://i.ibb.co/0ff5TXP/dark-pr.png")),
            new BitmapImage(new Uri("https://i.ibb.co/BTBCcY9/dark-pr-detail.png")),
            new BitmapImage(new Uri("https://i.ibb.co/tHTVXGJ/dark-commits.png")),
            new BitmapImage(new Uri("https://i.ibb.co/Jk9vxLn/dark-commits-detail.png")),
        };
        public ScreenshotsControl()
        {
            
            this.InitializeComponent();
            MyContent.Children.Add(new JitHubFlipView(images));
        }
    }
}
