using System.Collections.Generic;

namespace PotatoWest._Logic._AI.Components
{
    public class CharacterModifiers
    {
        private Dictionary<string, CharacterModifier> _modifiers = new Dictionary<string, CharacterModifier>();
        private float _defaultValue = 1f;

        public CharacterModifiers()
        {
            _modifiers.Add(ModifiersDict.MoveSpeedMod, new CharacterModifier(_defaultValue));
            _modifiers.Add(ModifiersDict.HealthMod, new CharacterModifier(_defaultValue));
        }
        
        public float GetModifierOrDefault(string modID)
        {
            if (TryGetModifier(modID, out var mod))
            {
                return mod.Value;
            }

            return _defaultValue;
        }

        public bool SetModifier(string modID, float value)
        {
            if (TryGetModifier(modID, out var mod))
            {
                mod.Value = value;
                return true;
            }

            return false;
        }

        public bool ResetModifier(string modID)
        {
            if (TryGetModifier(modID, out var mod))
            {
                mod.Reset();
                return true;
            }

            return false;
        }

        private bool TryGetModifier(string modID, out CharacterModifier modifier)
        {
            if (_modifiers.TryGetValue(modID, out var mod))
            {
                modifier = mod;
                return true;
            }

            modifier = null;
            return false;
        }
    }

    public class CharacterModifier
    {
        private float _defaultValue;
        public float Value = 1f;

        public CharacterModifier(float defaultValue)
        {
            _defaultValue = defaultValue;
            Reset();
        }

        public void Reset()
        {
            Value = _defaultValue;
        }
    }
}