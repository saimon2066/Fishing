using Game;
using UnityEngine;
using UnityEngine.UI;

namespace Fishing
{
    public class FishingUI : MonoBehaviour
    {
        [Header("Interact Hint")] 
        [SerializeField] private string _hintText;
        [Header("UI References")]
        [SerializeField] private RectTransform _minigame;
        [SerializeField] private RectTransform _playArea;
        [SerializeField] private RectTransform _reel;
        [SerializeField] private RectTransform _fish;
        [SerializeField] private Image _catchFill;
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

        public void ShowMinigame()
        {
            _minigame.gameObject.SetActive(true);
        }

        public void HideMinigame()
        {
            _minigame.gameObject.SetActive(false);
        }

        public void SetReelSize(float size)
        {
            _reel.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size * _playArea.rect.height);
        }

        public void SetFishSize(float size)
        {
            _fish.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size * _playArea.rect.height);
        }

        public void UpdateReelPosition(float pos)
        {
            _reel.anchoredPosition = new(0f, pos * _playArea.rect.height);
        }

        public void UpdateFishPosition(float pos)
        {
            _fish.anchoredPosition = new(0f, pos * _playArea.rect.height);
        }

        public void UpdateCatchFill(float fill)
        {
            _catchFill.fillAmount = fill;
        }
    }
}