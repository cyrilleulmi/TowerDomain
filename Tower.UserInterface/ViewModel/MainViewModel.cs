using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using TowerDomain.UserInterface;

namespace Tower.UserInterface.ViewModel
{
    class MainViewModel : BindableObject, INotifyPropertyChanged
    {
        private int range;

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
                    NotifyPropertyChanged(() => DisplayRange);
                }
            }
        }
        


}
}
