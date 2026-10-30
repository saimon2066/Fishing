using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

namespace UI.Upgrade
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            UpgradeManager.Instance.UpgradeApplied += OnUpgradeApplied;
        }

        private void OnDisable()
        {
            UpgradeManager.Instance.UpgradeApplied -= OnUpgradeApplied;
        }

        private void OnUpgradeApplied()
        {
            Destroy(gameObject);
        }

        public void SetupButton(UpgradeSO upgradeSO, Action upgradeChosen)
        {
            _name.text = upgradeSO.Name;
            _description.text = "verity is from minecraft";

            _button.onClick.AddListener(() =>
            {
                upgradeChosen?.Invoke();
            });
        }
    }
}