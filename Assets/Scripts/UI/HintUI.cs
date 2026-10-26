using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HintUI : MonoBehaviour
    {
        [SerializeField] private RectTransform _hint;
        [SerializeField] private TextMeshProUGUI _hintTMP;
        [SerializeField] private PlayerInteract _playerInteract;

        private void OnEnable()
        {
            _playerInteract.FocusChanged += OnFocusChanged;
        }

        private void OnFocusChanged(IInteractable interactable)
        {
            if (interactable != null)
            {
                ShowHint();
                SetHintText(interactable.Text);
            }
            else HideHint();
        }

        private void ShowHint()
        {
            _hint.localScale = Vector3.one;
        }

        private void HideHint()
        {
            _hint.localScale = Vector3.zero;
        }

        private void SetHintText(string text)
        {
            _hintTMP.text = text;
        }
    }
}