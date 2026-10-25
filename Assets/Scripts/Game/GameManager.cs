using Game.Stats;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameStatsSO _gameStatsSO;
        [SerializeField] private GameUI _gameUI;
        public static GameManager Instance { get; private set; }

        public GameStats GameStats { get; private set; }

        public int FishCount { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            GameStats = new(_gameStatsSO);
        }

        public void AddFish(int amount)
        {
            FishCount += amount;
            _gameUI.UpdateFishCount(FishCount);
        }

        public void RemoveFish(int amount)
        {
            FishCount -= amount;
            FishCount = Mathf.Clamp(FishCount, 0, int.MaxValue);
            _gameUI.UpdateFishCount(FishCount);
        }
    }
}