using System;
using Game;
using Game.Input;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fishing
{
    public class FishingController : MonoBehaviour, IInteractable
    {
        public static event Action<FishingSession> SessionStarted;
        public static event Action SessionEnded;
        
        private static FishingSession.Settings _settings => GameManager.Instance.GameStats.FishingSettings;
        private static int _fishPerCatchMin => GameManager.Instance.GameStats.FishPerCatchMin;
        private static int _fishPerCatchMax => GameManager.Instance.GameStats.FishPerCatchMax;

        public string Text => "Press E to start fishing!";
        
        private bool _isFishing => _fishingSession != null;
        
        private FishingSession _fishingSession;

        private void Update()
        {
            if (!_isFishing)
                return;

            bool isReeling = InputManager.Instance.Inputs.Fishing.Reel.IsPressed();
            _fishingSession.Update(Time.deltaTime, isReeling);

            if (!_fishingSession.IsFinished) 
                return;
            
            EndSession();
        }
        
        public void Interact()
        {
            StartSession();
        }
        
        private void StartSession()
        {
            InputManager.Instance.Inputs.Player.Disable();
            InputManager.Instance.Inputs.Fishing.Enable();

            _fishingSession = new FishingSession(_settings);

            _fishingSession.FishingSuccess += () =>
            {
                int fish = Random.Range(_fishPerCatchMin, _fishPerCatchMax + 1);
                GameManager.Instance.GameData.FishData.Add(fish);
            };
            _fishingSession.FishingFail += () =>
            {
            };
            
            SessionStarted?.Invoke(_fishingSession);
        }

        private void EndSession()
        {
            InputManager.Instance.Inputs.Player.Enable();
            InputManager.Instance.Inputs.Fishing.Disable();

            _fishingSession = null;
            
            SessionEnded?.Invoke();
        }
    }
}