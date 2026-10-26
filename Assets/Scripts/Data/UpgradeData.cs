using System;
using Game;
using UnityEngine;

namespace Data
{
    public class UpgradeData
    {
        public int XPTarget => Mathf.RoundToInt(GameManager.Instance.GameStats.BaseXP * Mathf.Pow(2f, Level));
        public float XPPercentage => (XP - _xpOffset) / XPTarget;
        
        public int XP { get; private set; }
        public int Level { get; private set; }

        public event Action<int> XPChanged;
        public event Action XPTargetReached;

        private float _xpOffset;

        public void AddXP(int value)
        {
            XP += value;
            
            if (XP >= XPTarget)
            {
                _xpOffset = XP;
                Level++;
                XPTargetReached?.Invoke();
            }
            else XPChanged?.Invoke(XP);
        }
    }
}