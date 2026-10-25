using Game;
using Game.Input;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private static float _speed => GameManager.Instance.GameStats.MovementSpeed;
        private static float _maxSpeed => GameManager.Instance.GameStats.MovementMaxSpeed;
        
        [SerializeField] private float _brakeDamping = 8f;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void FixedUpdate()
        {
            Vector2 moveInput = InputManager.Instance.Inputs.Player.Move.ReadValue<Vector2>();

            if (moveInput.sqrMagnitude <= 0f)
            {
                _rigidbody.linearDamping = _brakeDamping;
                return;
            }

            _rigidbody.linearDamping = 0f;

            Vector3 targetVector = new Vector3(moveInput.x, 0f, moveInput.y) * _maxSpeed;
            Vector3 horizontalVelocity = new(_rigidbody.linearVelocity.x, 0f, _rigidbody.linearVelocity.z);

            Vector3 accelerationForce =
                Vector3.ClampMagnitude((targetVector - horizontalVelocity) / Time.fixedDeltaTime, _speed);
            _rigidbody.AddForce(accelerationForce, ForceMode.Acceleration);
        }
    }
}