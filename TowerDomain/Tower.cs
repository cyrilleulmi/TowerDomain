using System;

namespace TowerDomain
{
    public class Tower : ITower
    {
        public Tower()
        {
            this.Range = 10;
            this.Damage = 10;
        }

        public int Damage { get; protected set; }

        public int Range { get; protected set; }

        public string Description
        {
            get
            {
                return String.Format(@"Tower which deals {0} damage and has a range of {1}", Damage, Range);
            }
        }

        public virtual Tower UpgradeRange()
        {
            return new TowerWithUpgradedRange();
        }

        public virtual Tower UpgradeDamage()
        {
            return new TowerWithUpgradedDamage();
        }

        public override string ToString()
        {
            return this.Description;
        }
    }
}