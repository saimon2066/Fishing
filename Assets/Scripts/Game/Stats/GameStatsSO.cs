using Fishing;
using UnityEngine;

namespace Game.Stats
{
    [CreateAssetMenu(fileName = "GameStats_", menuName = "Game Stats SO", order = 0)]
    public class GameStatsSO : ScriptableObject
    {
        [Header("Fishing")] 
        public FishingSession.Settings FishingSettings;
        public int FishPerCatchMin;
        public int FishPerCatchMax;
        [Header("Tower")] 
        public float TowerHungerTime;
        public float TowerHungerPerFish;
        [Header("Upgrades")] 
        public int BaseXP;
        [Header("Movement")] 
        public float MovementSpeed = 25f;
        public float MovementMaxSpeed = 7.5f;
    }
}