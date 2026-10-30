using System.Collections.Generic;
using Fishing;
using UnityEngine;

namespace Game.Stats
{
    public class GameStats
    {
        public FishingSession.Settings FishingSettings => new FishingSession.Settings
        {
            ReelSpeed = Mathf.Max(_stats[StatType.ReelSpeed], _gameStatsSO.FishingSettings.ReelSpeed),
            ReelSize = Mathf.Max(_stats[StatType.ReelSize], _gameStatsSO.FishingSettings.ReelSize),
            FishSpeed = Mathf.Max(_stats[StatType.FishSpeed], _gameStatsSO.FishingSettings.FishSpeed),
            FishSize = Mathf.Max(_stats[StatType.FishSize], _gameStatsSO.FishingSettings.FishSize),
            FishCooldownMin = Mathf.Max(_stats[StatType.FishCooldownMin], _gameStatsSO.FishingSettings.FishCooldownMin),
            FishCooldownMax = Mathf.Max(_stats[StatType.FishCooldownMax], _gameStatsSO.FishingSettings.FishCooldownMax),
            FillUpTime = Mathf.Max(_stats[StatType.FillUpTime], _gameStatsSO.FishingSettings.FillUpTime),
            FillDownTime = Mathf.Max(_stats[StatType.FillDownTime], _gameStatsSO.FishingSettings.FillDownTime),
            FillStart = Mathf.Max(_stats[StatType.FillStart], _gameStatsSO.FishingSettings.FillStart)
        };

        public int FishPerCatchMin => Mathf.Max((int)_stats[StatType.FishPerCatchMin], _gameStatsSO.FishPerCatchMin);
        public int FishPerCatchMax => Mathf.Max((int)_stats[StatType.FishPerCatchMax], _gameStatsSO.FishPerCatchMax);

        public float TowerHungerTime => Mathf.Max(_stats[StatType.TowerHungerTime], _gameStatsSO.TowerHungerTime);
        public float TowerHungerPerFish => Mathf.Max(_stats[StatType.TowerHungerPerFish], _gameStatsSO.TowerHungerPerFish);

        public int XPBase => Mathf.Max((int)_stats[StatType.XPBase], _gameStatsSO.XPBase);
        public float XPGrowth => Mathf.Max(_stats[StatType.XPGrowth], _gameStatsSO.XPGrowth);
        public int XPPerFish => Mathf.Max((int)_stats[StatType.XPPerFish], _gameStatsSO.XPPerFish);

        public float MovementSpeed => Mathf.Max(_stats[StatType.MovementSpeed], _gameStatsSO.MovementSpeed);
        public float MovementMaxSpeed => Mathf.Max(_stats[StatType.MovementMaxSpeed], _gameStatsSO.MovementMaxSpeed);
        
        private readonly Dictionary<StatType, float> _stats = new Dictionary<StatType, float>();

        private readonly GameStatsSO _gameStatsSO;

        public GameStats(GameStatsSO gameStatsSO)
        {
            _gameStatsSO = gameStatsSO;
            
            FishingSession.Settings fishing = _gameStatsSO.FishingSettings;
            
            _stats[StatType.ReelSpeed] = fishing.ReelSpeed;
            _stats[StatType.ReelSize] = fishing.ReelSize;
            _stats[StatType.FishSpeed] = fishing.FishSpeed;
            _stats[StatType.FishSize] = fishing.FishSize;
            _stats[StatType.FishCooldownMin] = fishing.FishCooldownMin;
            _stats[StatType.FishCooldownMax] = fishing.FishCooldownMax;
            _stats[StatType.FillUpTime] = fishing.FillUpTime;
            _stats[StatType.FillDownTime] = fishing.FillDownTime;
            _stats[StatType.FillStart] = fishing.FillStart;
            _stats[StatType.FishPerCatchMin] = _gameStatsSO.FishPerCatchMin;
            _stats[StatType.FishPerCatchMax] = _gameStatsSO.FishPerCatchMax;
            _stats[StatType.TowerHungerTime] = _gameStatsSO.TowerHungerTime;
            _stats[StatType.TowerHungerPerFish] = _gameStatsSO.TowerHungerPerFish;
            _stats[StatType.XPBase] = _gameStatsSO.XPBase;
            _stats[StatType.XPGrowth] = _gameStatsSO.XPGrowth;
            _stats[StatType.XPPerFish] = _gameStatsSO.XPPerFish;
            _stats[StatType.MovementSpeed] = _gameStatsSO.MovementSpeed;
            _stats[StatType.MovementMaxSpeed] = _gameStatsSO.MovementMaxSpeed;
        }

        public void AddBonus(StatType stat, float value)
        {
            _stats[stat] += value;
        }
    }
}