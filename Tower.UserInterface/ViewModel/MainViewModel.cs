using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;

namespace Tower.UserInterface.ViewModel
{
    class MainViewModel :Window, INotifyPropertyChanged
    {
        private int range;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {

        }

        public int DisplayRange
        {
            get 
            {
                return range;
            }
            set
            {
                if (value != range)
                {
                    range = value;
                    NotifyPropertyChanged("DisplayRange");
                }
            }
        }
        

    private void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}
}
