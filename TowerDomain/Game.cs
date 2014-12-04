using System.Collections.Generic;

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