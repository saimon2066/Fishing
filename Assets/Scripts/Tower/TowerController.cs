using Game;
using UnityEngine;

namespace Tower
{
    public class TowerController : MonoBehaviour, IInteractable
    {
        private static float _towerHungerTime => GameManager.Instance.GameStats.TowerHungerTime;
        private static float _towerHungerPerFish => GameManager.Instance.GameStats.TowerHungerPerFish;
        
        [SerializeField] private TowerUI _towerUI;

        private bool _canInteract;
        
        private float _hunger = 1f;

        private void Update()
        {
            _hunger -= Time.deltaTime / _towerHungerTime;
            _hunger = Mathf.Clamp(_hunger, 0f, 1f);
            
            _towerUI.UpdateHungerFill(_hunger);
        }

        public void Interact()
        {
            if (!_canInteract)
                return;
            
            int fishNeeded = Mathf.CeilToInt((1f - _hunger) / _towerHungerPerFish);
            int fish = Mathf.Min(GameManager.Instance.FishCount, fishNeeded);
            
            _hunger += fish * _towerHungerPerFish;
            GameManager.Instance.RemoveFish(fish);
        }

        public void Focus()
        {
            _canInteract = true;
            _towerUI.ShowHint();
        }

        public void UnFocus()
        {
            _canInteract = false;
            _towerUI.HideHint();
        }
    }
}