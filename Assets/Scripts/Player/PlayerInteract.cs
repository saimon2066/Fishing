using System;
using Game.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInteract : MonoBehaviour
    {
        public event Action<IInteractable> FocusChanged; 
        
        private IInteractable _current;

        private void OnEnable()
        {
            InputManager.Instance.Inputs.Player.Interact.performed += OnInteractPerformed;
        }

        private void OnDisable()
        {
            InputManager.Instance.Inputs.Player.Interact.performed -= OnInteractPerformed;
        }

        private void SetFocus(IInteractable interactable)
        {
            if (_current == interactable)
                return;
            
            _current?.UnFocus();
            _current = interactable;
            _current?.Focus();
            
            FocusChanged?.Invoke(_current);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable))
                return;

            SetFocus(interactable);
            _current = interactable;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable) || _current == null)
                return;

            SetFocus(null);
            _current = null;
        }

        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            _current?.Interact();
        }
    }
}