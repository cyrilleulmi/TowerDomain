using System.Collections.Generic;
using System.Linq;

namespace TowerDomain
{
    public class Game
    {
        private readonly List<TowerContainer> towerContainers = new List<TowerContainer>();

        public Game()
        {
            this.towerContainers = new List<TowerContainer>();
        }

        public IEnumerable<ITower> TowerContainers
        {
            get { return towerContainers; }
        }

        public void UpgradeRangeFromTower(ITower towerToUpgrade)
        {
            foreach (TowerContainer towerContainer in this.TowerContainers)
            {
                if (towerContainer.Tower == towerToUpgrade)
                {
                    Tower towerWithUpgradedRange = towerContainer.Tower.UpgradeRange();
                    var indexOfItem = GetIndexOfTower(towerToUpgrade);
                    towerContainers.ElementAt(indexOfItem).Tower = towerWithUpgradedRange;
                }
            }
        }

        private int GetIndexOfTower(ITower towerToUpgrade)
        {
            int indexOfItem =
                this.towerContainers.IndexOf(towerContainers.First(container => container.Tower.Equals(towerToUpgrade)));
            return indexOfItem;
        }

        public void UpgradePowerFromTower(Tower towerToUpgrade)
        {
        }

        public void CreateNewTower(Tower tower)
        {
            this.towerContainers.Add(new TowerContainer() {Tower = tower});
        }

        
    }
}