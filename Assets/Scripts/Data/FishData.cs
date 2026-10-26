using System;
using UnityEngine;

namespace Data
{
    public class FishData
    {
        public int FishCount { get; private set; }
        
        public event Action<int> FishCountChanged;

        public void Add(int count)
        {
            FishCount += count;
            FishCountChanged?.Invoke(FishCount);
        }

        public void Remove(int count)
        {
            FishCount -= count;
            FishCount = Mathf.Clamp(FishCount, 0, int.MaxValue);
            FishCountChanged?.Invoke(FishCount);
        }
    }
}