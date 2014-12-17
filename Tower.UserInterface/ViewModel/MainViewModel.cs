using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using TowerDomain.UserInterface;
using TowerDomain;
using System.Collections.ObjectModel;

namespace TowerDomain.UserInterface.ViewModel
{
    class MainViewModel : BindableObject, INotifyPropertyChanged
    {
        private int range;
        public DelegateCommand UpdateRange {get;private set;}
        public DelegateCommand AddTower {get;private set;}
        new Game game = new Game();
        private ObservableCollection<TowerContainer> _towers ;
        public MainViewModel()
        {  
            
            TowerWithUpgradeDamage _selectedTower
            UpdateRange = new DelegateCommand(executeRangeUpdate, canExecuteRangeUpdate);
            AddTower = new DelegateCommand(executeAddTower, canExecuteAddTower);
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
        private void executeRangeUpdate()  {
            

        
        }
        private void executeAddTower() {
           Tower tower = new Tower();
           game.CreateNewTower(tower);
        }
        private bool canExecuteAddTower() {
           
            if (!)

        }
        private TowerContainer _selectedTower;
        public TowerContainer SelectedTower
        {
            get { return _selectedTower; }
            set {
                _selectedTower = value;
                OnSelectedTowerChanged(value);
                NotifyPropertyChanged(() => SelectedItem);
            }
                
        }

    }
        


}
}
