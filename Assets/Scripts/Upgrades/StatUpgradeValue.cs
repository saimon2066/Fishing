using Game.Stats;
using UnityEngine;

namespace Upgrades
{
    public struct StatUpgradeValue
    {
        public readonly StatType Stat;
        public readonly float Value;

        public StatUpgradeValue(StatUpgrade statUpgrade)
        {
            Stat = statUpgrade.Stat;
            Value = Random.Range(statUpgrade.MinValue, statUpgrade.MaxValue);
        }
    }
}