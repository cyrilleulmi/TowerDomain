namespace TowerDomain
{
    public class TowerContainer : ITower
    {
        public ITower Tower { get; set; }

        public int Damage
        {
            get { return Tower.Damage; }
        }

        public string Description
        {
            get
            {
                return this.Tower != null ? this.Tower.Description : "Tower";
            }
        }

        public int Range
        {
            get { return Tower.Range; }
        }

        
        public Tower UpgradeRange()
        {
            return this.Tower.UpgradeRange();
        }

        public Tower UpgradeDamage()
        {
            return this.Tower.UpgradeDamage();
        }

        public override string ToString()
        {
            return this.Description;
        }
    }
}