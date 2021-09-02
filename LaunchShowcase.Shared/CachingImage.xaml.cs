using LaunchShowcase.Sdk.Services;
using OwlCore.Extensions;
using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace LaunchShowcase
{
    public sealed partial class CachingImage : UserControl
    {
        private HttpClient _client;
        private StorageFolder _cacheDir;

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(Uri), typeof(CachingImage), new PropertyMetadata(null, (e,d) => _ = e.Cast<CachingImage>().SetSource()));

        public static readonly DependencyProperty LocalSourceProperty =
            DependencyProperty.Register("LocalSource", typeof(Uri), typeof(CachingImage), new PropertyMetadata(null));

        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register("Stretch", typeof(Stretch), typeof(CachingImage), new PropertyMetadata(0));

        public Uri LocalSource
        {
            get { return (Uri)GetValue(LocalSourceProperty); }
            set { SetValue(LocalSourceProperty, value); }
        }

        public Uri Source
        {
            get { return (Uri)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        public CachingImage()
        {
            this.InitializeComponent();

            _client = new HttpClient();

            Loaded += CachingImage_Loaded;
        }

        private async void CachingImage_Loaded(object sender, RoutedEventArgs e)
        {
            await SetSource();
        }

        public async Task SetSource()
        {
            if (Source is null)
                return;

            var filePath = Path.Combine("ms-appx:///", "Assets", "CachedImages", Source.AbsoluteUri.HashMD5Fast() + ".png");

            // Needed for later to cache and optimize launch images.
            /*            var request = await _client.GetAsync(Source);
                        if (!request.IsSuccessStatusCode)
                            return;

                        var bytes = await request.Content.ReadAsByteArrayAsync();

                        try
                        {
                            var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("CachedImages", CreationCollisionOption.OpenIfExists);
                            var file = await folder.CreateFileAsync(Source.AbsoluteUri.HashMD5Fast() + ".png");
                            await FileIO.WriteBytesAsync(file, bytes);

                            LocalSource = new Uri(file.Path);
                        }
                        catch (Exception ex)
                        {

                        }*/

            LocalSource = new Uri(filePath);
        }
    }
}
