using System;
using Data;
using Game.Stats;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        public GameStats GameStats { get; private set; }
        public GameData GameData { get; private set; }
        
        [SerializeField] private GameStatsSO _gameStatsSO;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            GameStats = new GameStats(_gameStatsSO);
            GameData = new GameData();
        }
    }
}