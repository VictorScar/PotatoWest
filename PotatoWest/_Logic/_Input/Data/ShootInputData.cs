using System;
using UnityEngine;

namespace PotatoWest._Input.Data
{
    [Serializable]
    public struct ShootInputData
    {
        public Vector3 ScopePosition;
        public KeyActionInfo ShootKeyInfo;
    }

    [Serializable]
    public struct KeyActionInfo
    {
        public bool IsPressed;
        public bool HasBeenPressed;
        public bool HasBeenReleased;
    }
}