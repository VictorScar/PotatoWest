using UnityEngine;

namespace PotatoWest._Logic._AI.Components
{
    public class CharacterParameters : MonoBehaviour
    {
        [SerializeField] private float baseSpeed = 2f;
        [SerializeField] private int maxHealth = 100;
        private float _health;

        private CharacterModifiers _modifiers;

        public float MoveSpeed => baseSpeed * _modifiers.GetModifierOrDefault(ModifiersDict.MoveSpeedMod);
        public float MaxHealth => maxHealth * _modifiers.GetModifierOrDefault(ModifiersDict.HealthMod);
        public float Health => _health * _modifiers.GetModifierOrDefault(ModifiersDict.HealthMod);

        public void Init()
        {
            _modifiers = new CharacterModifiers();
            _health = maxHealth;
        }

        public float GetModifierValue(string modID)
        {
            return _modifiers.GetModifierOrDefault(modID);
        }

        public void SetModifierValue(string modID, float value)
        {
            _modifiers.SetModifier(modID, value);
        }
        
        public void ResetModifier(string modID)
        {
            _modifiers.ResetModifier(modID);
        }

        public void DoDamage(float damage)
        {
            _health = Health - damage;

            if (_health < 0)
            {
                _health = 0f;
            }
        }
    }
}