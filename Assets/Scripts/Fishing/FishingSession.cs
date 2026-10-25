using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fishing
{
    public class FishingSession
    {
        private readonly Settings _settings;
        private float _fishTargetPos;
        private float _fishTimer;

        private float _reelVelocity;

        public FishingSession(Settings settings)
        {
            _settings = settings;

            Fill = _settings.FillStart;
        }

        public float ReelPos { get; private set; }
        public float FishPos { get; private set; }
        public float Fill { get; private set; }
        public bool IsFinished { get; private set; }

        public event Action FishingSuccess;
        public event Action FishingFail;

        public void Update(float deltaTime, bool isReeling)
        {
            if (IsFinished)
                return;

            switch (Fill)
            {
                case >= 1f:
                    IsFinished = true;
                    FishingSuccess?.Invoke();
                    return;
                case <= 0f:
                    IsFinished = true;
                    FishingFail?.Invoke();
                    return;
            }

            MoveReel(deltaTime, isReeling);
            MoveFish(deltaTime);

            if (IsReelInsideFish())
                Fill += deltaTime / _settings.FillUpTime;
            else
                Fill -= deltaTime / _settings.FillDownTime;

            Fill = Mathf.Clamp(Fill, 0f, 1f);
        }

        private void MoveReel(float deltaTime, bool isReeling)
        {
            float reelAxis = isReeling ? 1f : -1f;

            _reelVelocity += reelAxis * _settings.ReelSpeed * deltaTime;
            ReelPos += _reelVelocity * deltaTime;

            float maxPosition = 1f - _settings.ReelSize;
            if (ReelPos <= 0f || ReelPos >= maxPosition)
                _reelVelocity *= -0.35f;
            ReelPos = Mathf.Clamp(ReelPos, 0f, maxPosition);
        }

        private void MoveFish(float deltaTime)
        {
            float maxPosition = 1f - _settings.FishSize;

            if (Mathf.Abs(_fishTargetPos - FishPos) < 0.01f)
            {
                _fishTimer -= deltaTime;
                if (_fishTimer <= 0f)
                {
                    _fishTimer = Random.Range(_settings.FishCooldownMin, _settings.FishCooldownMax);
                    _fishTargetPos = Random.Range(0f, maxPosition);
                }
            }

            FishPos = Mathf.Lerp(FishPos, _fishTargetPos, deltaTime * _settings.FishSpeed);
        }

        private bool IsReelInsideFish()
        {
            return ReelPos >= FishPos && ReelPos + _settings.ReelSize <= FishPos + _settings.FishSize;
        }

        [Serializable]
        public struct Settings
        {
            public float ReelSpeed;
            public float ReelSize;

            public float FishSpeed;
            public float FishSize;
            public float FishCooldownMin, FishCooldownMax;

            public float FillUpTime, FillDownTime;
            public float FillStart;

            public Settings(float reelSpeed, float reelSize, float fishSpeed, float fishSize, float fishCooldownMin,
                float fishCooldownMax, float fillUpTime, float fillDownTime, float fillStart)
            {
                ReelSpeed = reelSpeed;
                ReelSize = reelSize;
                FishSpeed = fishSpeed;
                FishSize = fishSize;
                FishCooldownMin = fishCooldownMin;
                FishCooldownMax = fishCooldownMax;
                FillUpTime = fillUpTime;
                FillDownTime = fillDownTime;
                FillStart = fillStart;
            }
        }
    }
}