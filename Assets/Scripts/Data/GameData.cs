using System;

namespace Data
{
    public class GameData
    {
        public FishData FishData { get; } = new FishData();
        public UpgradeData UpgradeData { get; } = new UpgradeData();
        public int Score { get; private set; }

        public event Action<int> ScoreChanged;

        public void AddScore(int value)
        {
            Score += value;
            ScoreChanged?.Invoke(Score);
        }
    }
}