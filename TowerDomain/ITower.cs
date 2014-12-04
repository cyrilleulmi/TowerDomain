using System.Security.Cryptography.X509Certificates;

namespace TowerDomain
{
    public interface ITower
    {
        int Range { get; }

        int Damage { get; }

        string Description { get; }

        Tower UpgradeRange();

        Tower UpgradeDamage();
    }
}