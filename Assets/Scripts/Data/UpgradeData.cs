using System;
using Game;
using UnityEngine;

namespace Data
{
    public class UpgradeData
    {
        public int XPTarget => Mathf.RoundToInt(GameManager.Instance.GameStats.XPBase * Mathf.Pow(GameManager.Instance.GameStats.XPGrowth, Level));
        public float XPPercentage => (XP - _xpOffset) / XPTarget;
        
        public int XP { get; private set; }
        public int Level { get; private set; }

        public event Action<int> XPChanged;
        public event Action<int> LevelUp;

        private float _xpOffset;

        public void AddXP(int value)
        {
            XP += value;
            
            if (XP >= XPTarget)
            {
                _xpOffset = XP;
                Level++;
                
                LevelUp?.Invoke(Level);
            }
            
            XPChanged?.Invoke(XP);
        }
    }
}