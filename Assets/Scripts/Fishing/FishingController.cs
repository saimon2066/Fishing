using Game.Input;
using UnityEngine;

namespace Fishing
{
    public class FishingController : MonoBehaviour
    {
        [SerializeField] private FishingSession.Settings _settings; // for now until there's something like PlayerStats.GetFishingSettings()
        [SerializeField] private FishingUI _fishingUI;
        
        private bool _isFishing { get { return _fishingSession != null; } }
        private FishingSession _fishingSession;
        
        private bool _canInteract;
        
        private void Update()
        {
            if (_canInteract && InputManager.Instance.Inputs.Player.Interact.WasPerformedThisFrame())
            {
                _fishingUI.HideHint();
                StartSession();
            }
            
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
            _fishingUI.UpdateFill(_fishingSession.Fill);
        }

        private void StartSession()
        {
            InputManager.Instance.Inputs.Player.Disable();
            InputManager.Instance.Inputs.Fishing.Enable();
            
            _fishingSession = new FishingSession(_settings);
            
            _fishingUI.ShowMinigame();
            _fishingUI.SetReelSize(_settings.ReelSize);
            _fishingUI.SetFishSize(_settings.FishSize);
            
            _fishingSession.FishingSuccess += () =>
            {
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
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) 
                return;
            
            _canInteract = true;
            _fishingUI.ShowHint();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) 
                return;
            
            _canInteract = false;
            _fishingUI.HideHint();
        }
    }
}