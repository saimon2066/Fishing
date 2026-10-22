using Game.Input;
using UnityEngine;
using UnityEngine.UI;

public class FishingManager : MonoBehaviour
{
    [SerializeField] private float _reelAccel;
    [SerializeField] private float _fishSpeed;
    [SerializeField] private RectTransform _playAreaRect;
    [SerializeField] private RectTransform _reelRect;
    [SerializeField] private RectTransform _fishRect;
    [SerializeField] private Image _fillArea;
    
    private float _reelVelocity;
    private float _reelPosition;

    private float _fishPosition;
    private float _fishTargetPosition;

    private float _fishTimer;

    private void Update()
    {
        MoveReel();
        MoveFish();
    }

    private void MoveReel()
    {
        float reelInput = InputManager.Instance.Inputs.Player.Reel.IsPressed() ? 1f : -1f;
        
        _reelVelocity += reelInput * _reelAccel * Time.deltaTime;
        _reelPosition += _reelVelocity * Time.deltaTime;
        
        float maxPosition = _playAreaRect.rect.height - _reelRect.rect.height;
        if (_reelPosition <= 0f || _reelPosition >= maxPosition)
            _reelVelocity *= -0.35f;
        _reelPosition = Mathf.Clamp(_reelPosition, 0f, maxPosition);

        Vector3 pos = _reelRect.anchoredPosition;
        pos.y = _reelPosition;
        _reelRect.anchoredPosition = pos;
    }

    private void MoveFish()
    {
        float maxPosition = _playAreaRect.rect.height - _fishRect.rect.height;

        if (Mathf.Abs(_fishTargetPosition - _fishPosition) < 1f)
        {
            _fishTimer -= Time.deltaTime;
            if (_fishTimer <= 0f)
            {
                _fishTimer = Random.Range(0.5f, 2.5f);
                _fishTargetPosition = Random.Range(0f, maxPosition);
            }
        }

        _fishPosition = Mathf.Lerp(_fishPosition, _fishTargetPosition, Time.deltaTime * _fishSpeed);

        Vector3 pos = _fishRect.anchoredPosition;
        pos.y = _fishPosition;
        _fishRect.anchoredPosition = pos;
    }
}


