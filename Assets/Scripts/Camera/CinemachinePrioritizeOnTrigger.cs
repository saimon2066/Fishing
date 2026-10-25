using Unity.Cinemachine;
using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(Collider))]
    public class CinemachinePrioritizeOnTrigger : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _camera;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                _camera.Priority = 9999;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                _camera.Priority = 0;
        }
    }
}