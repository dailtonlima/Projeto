using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVNT.Models;

namespace TVNT.ViewModels
{
    public class SplashViewModel : INotifyPropertyChanged
    {
        const string apiUrl = @"http://novotempo.com/api/tv/?action=splash&screenSize=normal";

        public SplashViewModel()
        {
            this.Items = new ObservableCollection<ItemSplash>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemSplash> Items { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            if (this.IsDataLoaded == false)
            {
                this.Items.Clear();
                //
                WebClient webClient = new WebClient();
                webClient.Headers["Accept"] = "application/json";
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompleted);
                webClient.DownloadStringAsync(new Uri(apiUrl));
            }
        }


        private void webClient_DownloadCatalogCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.Items.Clear();
                if (e.Result != null)
                {
                    var json = JsonConvert.DeserializeObject<TVNT.Models.Splash>(e.Result);
                    foreach (Image image in json.splashs)
                    {
                        this.Items.Add(new ItemSplash
                        {
                            Portrait = image.portrait,
                            Landscape = image.landscape
                        });
                        Debug.WriteLine(image.portrait);
                    }
                    this.IsDataLoaded = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
