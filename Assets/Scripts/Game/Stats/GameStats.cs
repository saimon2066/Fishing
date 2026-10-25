using Fishing;

namespace Game.Stats
{
    public class GameStats
    {
        public FishingSession.Settings FishingSettings => _gameStatsSO.FishingSettings;
        public int FishPerCatch => _gameStatsSO.FishPerCatch;
        public float TowerHungerTime => _gameStatsSO.TowerHungerTime;
        public float TowerHungerPerFish => _gameStatsSO.TowerHungerPerFish;
        public float MovementSpeed => _gameStatsSO.MovementSpeed;
        public float MovementMaxSpeed => _gameStatsSO.MovementMaxSpeed;
        
        private readonly GameStatsSO _gameStatsSO;

        public GameStats(GameStatsSO gameStatsSO)
        {
            _gameStatsSO = gameStatsSO;
        }
    }
}