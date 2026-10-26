using Fishing;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FishingMinigameUI : MonoBehaviour
    {
        private static FishingSession.Settings _settings => GameManager.Instance.GameStats.FishingSettings;
        
        private bool _isFishing => _fishingSession != null;
        
        [Header("References")]
        [SerializeField] private RectTransform _fishingMinigame;
        [SerializeField] private RectTransform _playArea;
        [SerializeField] private RectTransform _reel;
        [SerializeField] private RectTransform _fish;
        [SerializeField] private Image _catchProgressFill;
        
        private FishingSession _fishingSession;

        private void OnEnable()
        {
            FishingController.SessionStarted += OnSessionStarted;
            FishingController.SessionEnded += OnSessionEnded;
        }

        private void OnDisable()
        {
            FishingController.SessionStarted -= OnSessionStarted;
            FishingController.SessionEnded -= OnSessionEnded; 
        }

        private void OnSessionStarted(FishingSession session)
        {
            _fishingSession = session;
            
            ShowMinigame();
            SetReelSize(_settings.ReelSize);
            SetFishSize(_settings.FishSize); 
        }

        private void OnSessionEnded()
        {
            HideMinigame();
            
            _fishingSession = null;
        }

        private void LateUpdate()
        {
            if (!_isFishing)
                return;
            
            UpdateReelPosition(_fishingSession.ReelPos);
            UpdateFishPosition(_fishingSession.FishPos);
            UpdateCatchFill(_fishingSession.Fill);
        }

        private void ShowMinigame()
        {
            _fishingMinigame.localScale = Vector3.one;
        }

        private void HideMinigame()
        {
            _fishingMinigame.localScale = Vector3.zero;
        }

        private void SetReelSize(float size)
        {
            _reel.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size * _playArea.rect.height);
        }

        private void SetFishSize(float size)
        {
            _fish.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size * _playArea.rect.height);
        }

        private void UpdateReelPosition(float pos)
        {
            _reel.anchoredPosition = new Vector2(0f, pos * _playArea.rect.height);
        }

        private void UpdateFishPosition(float pos)
        {
            _fish.anchoredPosition = new Vector2(0f, pos * _playArea.rect.height);
        }

        private void UpdateCatchFill(float fill)
        {
            _catchProgressFill.fillAmount = fill;
        }
    }
}