using Game.Input;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Vector2 moveInput = InputManager.Instance.Inputs.Player.Move.ReadValue<Vector2>();
            Vector3 moveVector = new Vector3(moveInput.x, 0f, moveInput.y) * (Time.deltaTime * _speed);
            
            _characterController.Move(moveVector);
        }
    }
}
