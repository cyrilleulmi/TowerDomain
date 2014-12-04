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

        public IEnumerable<ITower> Towers
        {
            get { return towerContainers; }
        }

        public void UpgradeRangeFromTower(ITower towerToUpgrade)
        {
            foreach (TowerContainer towerContainer in this.Towers)
            {
                if (towerContainer.Tower == towerToUpgrade || towerContainer == towerToUpgrade)
                {
                    Tower towerWithUpgradedRange = towerContainer.Tower.UpgradeRange();
                    this.SwitchTowerWithOtherTower(towerToUpgrade, towerWithUpgradedRange);
                }
            }
        }

        private int GetIndexOfTower(ITower towerToUpgrade)
        {
            int indexOfItem =
                this.towerContainers.IndexOf(towerContainers.First(container => container == towerToUpgrade || container.Tower.Equals(towerToUpgrade)));
            return indexOfItem;
        }

        public void UpgradePowerFromTower(Tower towerToUpgrade)
        {
        }

        public void CreateNewTower(ITower tower)
        {
            this.towerContainers.Add(new TowerContainer() {Tower = tower});
        }


        public void UpgradeDamageFromTower(ITower towerToUpgrade)
        {
            foreach (TowerContainer towerContainer in this.Towers)
            {
                if (towerContainer.Tower == towerToUpgrade || towerContainer == towerToUpgrade)
                {
                    Tower towerWithUpgradedRange = towerContainer.Tower.UpgradeDamage();
                    SwitchTowerWithOtherTower(towerToUpgrade, towerWithUpgradedRange);
                }
            }
        }

        private void SwitchTowerWithOtherTower(ITower towerToRemove, ITower towerToAdd)
        {
            var indexOfItem = GetIndexOfTower(towerToRemove);
            towerContainers.ElementAt(indexOfItem).Tower = towerToAdd;
        }
    }
}