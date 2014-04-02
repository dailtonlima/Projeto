using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace TVNT
{
    public partial class Splash : PhoneApplicationPage
    {
        public static String STREAM_PT = "http://stream.novotempo.com:1935/tv/smil:tvnovotempo.smil/Manifest";
        public static String STREAM_ES = "http://stream.novotempo.com:1935/tv/smil:tvnuevotiempo.smil/Manifest";
        DispatcherTimer timer;
        public int SelectedSplash { get; set; }

        public Splash()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
            this.Loaded += Preferencia_Loaded;
            Splash_Screen();
        }

        void Preferencia_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSplash();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void LoadSplash()
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
           
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (SelectedSplash == App.ViewModel.Items.Count - 1)
                SelectedSplash = 0;
            else
                SelectedSplash++;

            SetSplashSouce(App.ViewModel.Items[SelectedSplash].Portrait);

        }

        private void SetSplashSouce(String path)
        {
            img_splash.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
        }

        async void Splash_Screen()
        {
            await Task.Delay(TimeSpan.FromSeconds(7));  // set your desired delay
            TitlePanel.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void btLang_PT_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            //String url = string.Format("/PlayVideo.xaml?stream={0}", STREAM_PT);
            //NavigationService.Navigate(new Uri(url, UriKind.Relative));
            String url = string.Format("/MainPage.xaml?lang={0}", "pt");
            NavigationService.Navigate(new Uri(url, UriKind.Relative));
        }

        private void btLang_ES_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            //String url = string.Format("/PlayVideo.xaml?stream={0}", STREAM_ES);
            //NavigationService.Navigate(new Uri(url, UriKind.Relative));
            String url = string.Format("/MainPage.xaml?lang={0}", "es");
            NavigationService.Navigate(new Uri(url, UriKind.Relative));
        }
    }
}