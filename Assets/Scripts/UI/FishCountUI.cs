using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    public class FishCountUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tmp;
        
        private void OnEnable()
        {
            GameManager.Instance.GameData.FishData.FishCountChanged += OnFishCountChanged;
            OnFishCountChanged(GameManager.Instance.GameData.FishData.FishCount);
        }

        private void OnDisable()
        {
            GameManager.Instance.GameData.FishData.FishCountChanged -= OnFishCountChanged;
        }

        private void OnFishCountChanged(int count)
        {
            _tmp.text = $"{count}";
        }
    }
}