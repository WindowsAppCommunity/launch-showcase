using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace LaunchShowcase.Themes.ShowcaseTemplates.JitHubControls
{
    public sealed partial class JitHubFlipView : UserControl
    {
        public IList<Uri> Images { get; }
        public int Index = 0;
        public ICommand RightCommand { get; }
        public ICommand LeftCommand { get; }
        public JitHubFlipView(IList<Uri> images)
        {
            this.InitializeComponent();
            Images = images;
            MyImage.Source = Images[Index];
            RightCommand = new RelayCommand(RightClick);
            LeftCommand = new RelayCommand(LeftClick);
            LeftButton.IsEnabled = Index != 0;
            RightButton.IsEnabled = Index < Images.Count;
        }

        private void LeftClick()
        {
            if (Index > 0)
            {
                MyImage.Source = Images[--Index];
                RightButton.IsEnabled = true;
            }
            else
            {
                LeftButton.IsEnabled = false;
            }
        }

        private void RightClick()
        {
            if (Index < Images.Count - 1)
            {
                MyImage.Source = Images[++Index];
                LeftButton.IsEnabled = true;
            }
            else
            {
                RightButton.IsEnabled = false;
            }
        }
    }
}
