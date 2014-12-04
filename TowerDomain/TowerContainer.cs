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
                return this.Tower.Description;
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
    }
}