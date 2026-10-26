using Tower;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HungerProgressUI : MonoBehaviour
    {
        [SerializeField] private Image _hungerProgressFill;
        [SerializeField] private TowerController _towerController;

        private void Update()
        {
            _hungerProgressFill.fillAmount = _towerController.Hunger;
        }
    }
}