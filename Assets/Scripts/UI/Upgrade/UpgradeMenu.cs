using System;
using System.Collections.Generic;
using UnityEngine;
using Upgrades;

namespace UI.Upgrade
{
    public class UpgradeMenu : MonoBehaviour
    {
        [SerializeField] private RectTransform _menuRect;
        [SerializeField] private GameObject _upgradeButtonPrefab;
        
        private void OnEnable()
        {
            UpgradeManager.Instance.UpgradesCreated += OnUpgradesCreated;
            UpgradeManager.Instance.UpgradeApplied += OnUpgradeApplied;
        }

        private void OnDisable()
        {
            UpgradeManager.Instance.UpgradesCreated -= OnUpgradesCreated;
            UpgradeManager.Instance.UpgradeApplied -= OnUpgradeApplied;
        }

        private void OnUpgradesCreated(Upgrades.Upgrade[] upgrades)
        {
            ShowMenu();
            
            foreach (Upgrades.Upgrade upgrade in upgrades)
            {
                UpgradeButton upgradeButton = Instantiate(_upgradeButtonPrefab, transform).GetComponent<UpgradeButton>();
                upgradeButton.SetupButton(upgrade.UpgradeSO, () =>
                {
                    UpgradeManager.Instance.ApplyUpgrade(upgrade);
                });
            }
        }
        
        private void OnUpgradeApplied()
        {
            HideMenu();
        }

        private void ShowMenu()
        {
            _menuRect.localScale = Vector3.one;
        }

        private void HideMenu()
        {
            _menuRect.localScale = Vector3.zero;
        }
    }
}