using Game.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInteract : MonoBehaviour
    {
        private IInteractable _current;

        private void OnEnable()
        {
            InputManager.Instance.Inputs.Player.Interact.performed += OnInteractPerformed;
        }

        private void OnDisable()
        {
            InputManager.Instance.Inputs.Player.Interact.performed -= OnInteractPerformed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable))
                return;

            interactable.Focus();
            _current = interactable;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable) || _current == null)
                return;

            interactable.UnFocus();
            _current = null;
        }

        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            _current?.Interact();
        }
    }
}