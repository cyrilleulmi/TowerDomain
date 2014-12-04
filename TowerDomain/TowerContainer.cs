namespace TowerDomain
{
    public class TowerContainer : ITower
    {
        public ITower Tower { get; set; }

        public int Range
        {
            get { return Tower.Range; }
        }

        public Tower UpgradeRange()
        {
            return this.Tower.UpgradeRange();
        }
    }
}