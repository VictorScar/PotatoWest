using System;
using UnityEngine;

namespace PotatoWest._Input.Data
{
    [Serializable]
    public struct InputData
    {
        public float FAxis;
        public float RAxis;
        public Vector2 MoveInput;
        public bool MenuKeyPressed;
        public ShootInputData ShootInputData;
        public KeyActionInfo JumpKeyData;
    }
}
