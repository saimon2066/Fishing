using System;
using Game.Stats;

namespace Upgrades
{
    [Serializable]
    public struct StatUpgrade
    {
        public StatType Stat;
        public float MinValue, MaxValue;
    }
}