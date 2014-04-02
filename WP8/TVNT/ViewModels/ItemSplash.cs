using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TVNT.ViewModels
{
    public class ItemSplash
    {
        private string _portrait;
        public string Portrait
        {
            get
            {
                return _portrait;
            }
            set
            {
                if (value != _portrait)
                {
                    _portrait = value;
                    NotifyPropertyChanged("Portrait");
                }
            }
        }

        private string _landscape;
        public string Landscape
        {
            get
            {
                return _landscape;
            }
            set
            {
                if (value != _landscape)
                {
                    _landscape = value;
                    NotifyPropertyChanged("Landscape");
                }
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    NotifyPropertyChanged("Value");
                }
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
