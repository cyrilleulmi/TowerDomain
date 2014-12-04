using System.Security.Cryptography.X509Certificates;

namespace TowerDomain
{
    public interface ITower
    {
        int Range { get; }

        Tower UpgradeRange();
    }
}