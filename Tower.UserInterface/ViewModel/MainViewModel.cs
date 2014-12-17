using System.Collections.ObjectModel;
using System.ComponentModel;
using Tower.UserInterface.Annotations;
using TowerDomain;
using TowerDomain.UserInterface;

namespace Tower.UserInterface.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int range;
        private Game game;
        private ObservableCollection<TowerContainer> towers ;

        public MainViewModel()
        {  
            this.game = new Game();
        }
        


        public int DisplayedRange
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
                    this.OnPropertyChanged("DisplayedRange");
                }
            }
        }

        private TowerContainer selectedTower;

        public TowerContainer SelectedTower
        {
            get { return selectedTower; }
            set
            {
                this.selectedTower = value;
                this.OnPropertyChanged("SelectedTower");
            }
                
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
