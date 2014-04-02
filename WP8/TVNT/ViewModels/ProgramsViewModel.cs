using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVNT.Models;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TVNT.ViewModels
{
    public class ProgramsViewModel : INotifyPropertyChanged
    {
        const string apiUrl = @"http://novotempo.com/api/tv/?action=program";

        public ObservableCollection<Program> programs { get; set; }

        public ProgramsViewModel()
        {
            this.programs = new ObservableCollection<Program>();
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData(string lang)
        {
            if (this.IsDataLoaded == false)
            {
                this.programs.Clear();
                //
                string urlApi = apiUrl+"&lang="+lang;

                WebClient webClient = new WebClient();
                webClient.Headers["Accept"] = "application/json";
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompleted);
                webClient.DownloadStringAsync(new Uri(urlApi));
            }
        }


        private void webClient_DownloadCatalogCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.programs.Clear();
                if (e.Result != null)
                {
                    var json = JsonConvert.DeserializeObject<RootObject>(e.Result);
                    
                    foreach (Program item in json.response)
                    {
                        this.programs.Add(new Program
                        {
                            id = item.id,
                            idGrade = item.idGrade,
                            name = item.name,
                            thumbnail = item.thumbnail,
                            image = item.image
                        });
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
