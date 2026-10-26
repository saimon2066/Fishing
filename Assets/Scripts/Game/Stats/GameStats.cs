using Fishing;

namespace Game.Stats
{
    public class GameStats
    {
        public FishingSession.Settings FishingSettings => _gameStatsSO.FishingSettings;
        public int FishPerCatchMin => _gameStatsSO.FishPerCatchMin;
        public int FishPerCatchMax => _gameStatsSO.FishPerCatchMax;
        public float TowerHungerTime => _gameStatsSO.TowerHungerTime;
        public float TowerHungerPerFish => _gameStatsSO.TowerHungerPerFish;
        public int BaseXP => _gameStatsSO.BaseXP;
        public float MovementSpeed => _gameStatsSO.MovementSpeed;
        public float MovementMaxSpeed => _gameStatsSO.MovementMaxSpeed;
        
        private readonly GameStatsSO _gameStatsSO;

        public GameStats(GameStatsSO gameStatsSO)
        {
            _gameStatsSO = gameStatsSO;
        }
    }
}