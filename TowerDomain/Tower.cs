namespace TowerDomain
{
    public class Tower
    {
        public Tower()
        {
            this.Range = 10;
        }

        internal Tower UpgradeRange()
        {
            return new TowerWithUpgradedRange();
        }

        public int Range { get; protected set; }
    }
}