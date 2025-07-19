using System;
using UnityEngine;

namespace Game.Character.Stats
{
    [Serializable]
    public class CharacterStat
    {
        public event Action<float> OnStatChange;

        [SerializeField] float _value;
        [SerializeField] float _multiplier;

        public CharacterStat(float value, float multiplier = 1)
        {
            NormalValue = value;
            _multiplier = multiplier;
        }

        public float NormalValue
        {
            get => _value;
            set
            {
                _value = value;
                OnStatChange?.Invoke(_value);
            }
        }


        public virtual float CurrentValue
        {
            get => _value * _multiplier;
            set => NormalValue = value;
        }

        public void ApplyMultiplier(float multiplier = 1) => _multiplier = multiplier;

    }

    [Serializable]
    public class CharacterStatLimited : CharacterStat
    {
        [SerializeField] float _min;
        [SerializeField] float _max;

        public CharacterStatLimited(float value, float min, float max, float multiplier = 1) : base(Mathf.Clamp(value, min, max), multiplier)
        {
            _min = min;
            _max = max;
        }

        public override float CurrentValue { get => base.CurrentValue; set => base.CurrentValue = Mathf.Clamp(value, _min, _max); }
    }
}
