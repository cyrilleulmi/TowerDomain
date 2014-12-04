namespace TowerDomain
{
    public class TowerWithUpgradedRange : Tower
    {
        public TowerWithUpgradedRange()
        {
            this.Damage = 10;
            this.Range = 15;
        }

        public override Tower UpgradeDamage()
        {
            return new TowerWithUpgradedDamageAndRange();
        }
    }
}