using System.Threading;

namespace TowerDomain
{
    public class TowerWithUpgradedDamageAndRange : Tower
    {
        public TowerWithUpgradedDamageAndRange()
        {
            this.Damage = 15;
            this.Range = 15;
        }
    }
}
