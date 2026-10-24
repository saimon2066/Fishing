using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fishing
{
    public class FishingUI : MonoBehaviour
    {
        [Header("Interact Hint")]
        [SerializeField] private string _interactHintText;
        [Header("UI References")]
        [SerializeField] private RectTransform _minigame;
        [SerializeField] private RectTransform _playArea;
        [SerializeField] private RectTransform _reel;
        [SerializeField] private RectTransform _fish;
        [SerializeField] private RectTransform _interactHint;
        [SerializeField] private Image _fill;
        
        public void ShowHint()
        {
            _interactHint.gameObject.SetActive(true);
            TextMeshProUGUI tmp = _interactHint.GetComponentInChildren<TextMeshProUGUI>();
            tmp.text = _interactHintText;
        }

        public void HideHint()
        {
            _interactHint.gameObject.SetActive(false);
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
            _reel.anchoredPosition = new Vector2(0f, pos * _playArea.rect.height);
        }

        public void UpdateFishPosition(float pos)
        {
            _fish.anchoredPosition = new Vector2(0f, pos * _playArea.rect.height);
        }
        
        public void UpdateFill(float fill)
        {
            _fill.fillAmount = fill;
        }
    }
}