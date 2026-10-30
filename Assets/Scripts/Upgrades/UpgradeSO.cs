using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "Upgrade_", menuName = "Upgrade", order = 0)]
    public class UpgradeSO : ScriptableObject
    {
        public string Name;
        public StatUpgrade[] Stats;
    }
}