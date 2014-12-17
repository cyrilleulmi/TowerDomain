
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TowerDomain.Ui.Annotations;

namespace TowerDomain.Ui.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int range;
        private Game game;
        

        public MainViewModel()
        {
            this.game = new Game();
            this.Towers = new ObservableCollection<ITower>();
            AddTower();
        }

        private void AddTower()
        {
            TowerContainer towerContainer = new TowerContainer() {Tower = new Tower()};
            this.game.CreateNewTower(towerContainer);
            this.OnPropertyChanged("Towers");

            RenewTowers();
        }

        private IEnumerable<ITower> towers
        {
            get { return this.game.Towers; }
        }

        public ObservableCollection<ITower> Towers
        {
            get; private set;
        }

        public int DisplayedRange
        {
            get 
            {
                return this.SelectedTower != null ? this.SelectedTower.Range : 1;
            }
        }

        public int DisplayedDamage
        {
            get
            {
                return this.SelectedTower != null ? this.SelectedTower.Damage : 1;
            }
        }

        private ITower selectedTower;

        public ITower SelectedTower
        {
            get { return selectedTower; }
            set
            {
                this.selectedTower = value;
                this.OnPropertyChanged("DisplayedRange");
                this.OnPropertyChanged("DisplayedDamage");
            }
                
        }

        public void ChangeSelectionTo(ITower tower)
        {
            this.SelectedTower = tower;
        }

        public void UpgradeRange()
        {
            if (this.SelectedTower != null)
            {
                this.game.UpgradeRangeFromTower(SelectedTower);
                this.OnPropertyChanged("DisplayedRange");
                this.RenewTowers();
            }
        }

        public void UpgradeDamage()
        {
            if (this.SelectedTower != null)
            {
                this.game.UpgradeDamageFromTower(this.SelectedTower);
                this.OnPropertyChanged("DisplayedDamage");
                this.RenewTowers();
            }
        }

        public void CreateTower()
        {
            this.AddTower();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RenewTowers()
        {
            this.Towers.Clear();

            foreach (var tower in this.towers)
            {
                this.Towers.Add(tower);
            }
        }
    }
}
