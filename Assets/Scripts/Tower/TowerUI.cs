using Game;
using UnityEngine;
using UnityEngine.UI;

namespace Tower
{
    public class TowerUI : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private string _hintText;
        [Header("UI References")] 
        [SerializeField] private Image _hungerFill;
        [Header("References")] 
        [SerializeField] private GameUI _gameUI;

        public void ShowHint()
        {
            _gameUI.ShowHint(_hintText);
        }

        public void HideHint()
        {
            _gameUI.HideHint();
        }

        public void UpdateHungerFill(float fill)
        {
            _hungerFill.fillAmount = fill;
        }
    }
}