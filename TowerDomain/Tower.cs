namespace TowerDomain
{
    public class Tower : ITower
    {
        public Tower()
        {
            this.Range = 10;
        }

        public Tower UpgradeRange()
        {
            return new TowerWithUpgradedRange();
        }

        public int Range { get; protected set; }
    }
}