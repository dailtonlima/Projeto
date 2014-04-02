using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using TVNT.Resources;

namespace TVNT
{
    public partial class MainPage : PhoneApplicationPage
    {
        private string lang;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.ViewModelProgram;
            loadPrograms();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (this.NavigationContext.QueryString.ContainsKey("lang"))
            {
                lang = this.NavigationContext.QueryString["lang"];
            }
        }

        private void loadPrograms()
        {
            if (!App.ViewModelProgram.IsDataLoaded)
            {
                App.ViewModelProgram.LoadData(lang);
            }
        }
      
    }
}