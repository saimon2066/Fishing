using Game;
using Game.Input;
using UnityEngine;

namespace Fishing
{
    public class FishingController : MonoBehaviour, IInteractable
    {
        private static FishingSession.Settings _settings => GameManager.Instance.GameStats.FishingSettings;
        
        [SerializeField] private FishingUI _fishingUI;

        private bool _canInteract;
        private FishingSession _fishingSession;

        private bool _isFishing => _fishingSession != null;

        private void Update()
        {
            if (!_isFishing)
                return;

            bool isReeling = InputManager.Instance.Inputs.Fishing.Reel.IsPressed();
            _fishingSession.Update(Time.deltaTime, isReeling);

            if (_fishingSession.IsFinished)
            {
                EndSession();
                return;
            }

            _fishingUI.UpdateReelPosition(_fishingSession.ReelPos);
            _fishingUI.UpdateFishPosition(_fishingSession.FishPos);
            _fishingUI.UpdateCatchFill(_fishingSession.Fill);
        }

        public void Interact()
        {
            if (!_canInteract)
                return;

            _fishingUI.HideHint();
            StartSession();
        }

        public void Focus()
        {
            _canInteract = true;
            _fishingUI.ShowHint();
        }

        public void UnFocus()
        {
            _canInteract = false;
            _fishingUI.HideHint();
        }

        private void StartSession()
        {
            InputManager.Instance.Inputs.Player.Disable();
            InputManager.Instance.Inputs.Fishing.Enable();

            _fishingSession = new(_settings);

            _fishingUI.ShowMinigame();
            _fishingUI.SetReelSize(_settings.ReelSize);
            _fishingUI.SetFishSize(_settings.FishSize);

            _fishingSession.FishingSuccess += () =>
            {
                GameManager.Instance.AddFish(1);
                Debug.Log("success");
            };
            _fishingSession.FishingFail += () =>
            {
                Debug.Log("fail");
            };
        }

        private void EndSession()
        {
            InputManager.Instance.Inputs.Player.Enable();
            InputManager.Instance.Inputs.Fishing.Disable();

            _fishingUI.ShowHint();
            _fishingUI.HideMinigame();

            _fishingSession = null;
        }
    }
}