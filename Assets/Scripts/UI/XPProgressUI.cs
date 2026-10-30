using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class XPProgressUI : MonoBehaviour
    {
        [SerializeField] private Image _xpProgressFill;
        
        private void OnEnable()
        {
            GameManager.Instance.GameData.UpgradeData.XPChanged += OnXPChanged;
            OnXPChanged(0);
        }

        private void OnDisable()
        {
            GameManager.Instance.GameData.UpgradeData.XPChanged -= OnXPChanged;
        }

        private void OnXPChanged(int xp)
        {
            _xpProgressFill.fillAmount = GameManager.Instance.GameData.UpgradeData.XPPercentage;
        }
    }
}