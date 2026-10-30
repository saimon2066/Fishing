using System;
using Game;
using Game.Stats;
using UnityEngine;

namespace Tower
{
    public class TowerController : MonoBehaviour, IInteractable
    {
        private static float _towerHungerTime => GameManager.Instance.GameStats.TowerHungerTime;
        private static float _towerHungerPerFish => GameManager.Instance.GameStats.TowerHungerPerFish;

        public string Text => "Press E to feed the tower!";
        public float Hunger { get; private set; } = 1f;

        private void Update()
        {
            Hunger -= Time.deltaTime / _towerHungerTime;
            Hunger = Mathf.Clamp(Hunger, 0f, 1f);
        }

        public void Interact()
        {
            int fishNeeded = Mathf.CeilToInt((1f - Hunger) / _towerHungerPerFish);
            int fish = Mathf.Min(GameManager.Instance.GameData.FishData.FishCount, fishNeeded);
            
            Hunger += fish * _towerHungerPerFish;
            GameManager.Instance.GameData.FishData.Remove(fish);
            GameManager.Instance.GameData.UpgradeData.AddXP(fish * GameManager.Instance.GameStats.XPPerFish);
        }
    }
}