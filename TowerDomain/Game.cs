using System.Collections.Generic;
using System.Linq;

namespace TowerDomain
{
    public class Game
    {
        private List<Tower> towers = new List<Tower>();

        public Game()
        {
            this.towers = new List<Tower>();
        }

        public IEnumerable<Tower> Towers
        {
            get { return towers; }
        }

        public void UpgradeRangeFromTower(Tower towerToUpgrade)
        {
            Dictionary<Tower, Tower> towersToExchange = new Dictionary<Tower, Tower>();

            foreach (var tower in this.Towers)
            {
                if (tower == towerToUpgrade)
                {
                    Tower towerWithUpgradedRange = tower.UpgradeRange();
                    towersToExchange.Add(tower, towerWithUpgradedRange);
                }
            }

            foreach (var towerToExchange in towersToExchange)
            {
                int indexOfItem = this.towers.IndexOf(towerToExchange.Key);

                towers.RemoveAt(indexOfItem);
                towers.Insert(indexOfItem, towerToExchange.Value);
            }
        }

        public void UpgradePowerFromTower(Tower towerToUpgrade)
        {
            foreach (var tower in this.Towers)
            {
                if (tower == towerToUpgrade)
                {
                    Tower towerWithUpgradedRange = tower.UpgradeRange();
                    this.towers.Remove(tower);
                    this.towers.Add(towerWithUpgradedRange);
                }
            }
        }

        public void CreateNewTower(Tower tower)
        {
            this.towers.Add(tower);
        }

        
    }
}