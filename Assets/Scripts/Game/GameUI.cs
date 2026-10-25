using TMPro;
using UnityEngine;

namespace Game
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private RectTransform _hint;
        [SerializeField] private TextMeshProUGUI _fishCount;

        private TextMeshProUGUI _hintTMP;

        private void Awake()
        {
            _hintTMP = _hint.GetComponentInChildren<TextMeshProUGUI>();
        }

        public void ShowHint(string text)
        {
            _hint.gameObject.SetActive(true);
            _hintTMP.text = text;
        }

        public void HideHint()
        {
            _hint.gameObject.SetActive(false);
        }

        public void UpdateFishCount(int count)
        {
            _fishCount.text = $"{count}";
        }
    }
}