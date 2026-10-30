using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        public static UpgradeManager Instance { get; private set; }
        
        [SerializeField] private UpgradeSO[] _upgradeSOs;

        public event Action<Upgrade[]> UpgradesCreated;
        public event Action UpgradeApplied;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void OnEnable()
        {
            GameManager.Instance.GameData.UpgradeData.LevelUp += OnLevelUp;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameData.UpgradeData.LevelUp -= OnLevelUp;
        }

        private void OnLevelUp(int level)
        {
            Upgrade[] upgrades = CreateUpgrades();
            UpgradesCreated?.Invoke(upgrades);
        }

        private Upgrade[] CreateUpgrades()
        {
            List<UpgradeSO> upgradeSOs = new List<UpgradeSO>(_upgradeSOs);
            
            int upgradeCount = Mathf.Min(3, _upgradeSOs.Length);
            Upgrade[] upgrades = new Upgrade[upgradeCount];

            for (int i = 0; i < upgradeCount;)
            {
                int randomIndex = Random.Range(0, upgradeSOs.Count);
                upgrades[i] = new Upgrade(upgradeSOs[randomIndex]);
                upgradeSOs.RemoveAt(randomIndex);
                i++;
            }

            return upgrades;
        }

        public void ApplyUpgrade(Upgrade upgrade)
        {
            foreach (StatUpgradeValue value in upgrade.StatUpgradeValues)
            {
                GameManager.Instance.GameStats.AddBonus(value.Stat, value.Value);
            }
            
            UpgradeApplied?.Invoke();
        }
    }
}