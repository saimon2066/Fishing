namespace Upgrades
{
    public class Upgrade
    {
        public readonly UpgradeSO UpgradeSO;
        public readonly StatUpgradeValue[] StatUpgradeValues;

        public Upgrade(UpgradeSO upgradeSO)
        {
            UpgradeSO = upgradeSO;
            
            StatUpgradeValues = new StatUpgradeValue[upgradeSO.Stats.Length];
            for (int i = 0; i < UpgradeSO.Stats.Length; i++)
            {
                StatUpgradeValues[i] = new StatUpgradeValue(UpgradeSO.Stats[i]);
            }
        }
    }
}