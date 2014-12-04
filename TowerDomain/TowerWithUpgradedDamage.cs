namespace TowerDomain
{
    public class TowerWithUpgradedDamage : Tower
    {
        public TowerWithUpgradedDamage()
        {
            this.Range = 10;
            this.Damage = 15;
        }

        public override Tower UpgradeRange()
        {
            return new TowerWithUpgradedDamageAndRange();
        }
    }
}
