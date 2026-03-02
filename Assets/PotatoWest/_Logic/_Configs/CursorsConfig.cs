using System;
using UnityEngine;

namespace PotatoWest._Logic._Configs
{
    [CreateAssetMenu(menuName = "Configs/Cursors", fileName = "CursorsConfig")]
    public class CursorsConfig : ScriptableObject
    {
        [SerializeField] private CursorData playModeCursor;
        [SerializeField] private CursorData menuModeCursor;

        public CursorData PlayModeCursorData => playModeCursor;
        public CursorData MenuModeCursor => menuModeCursor;
    }

    [Serializable]
    public struct CursorData
    {
        public Sprite CursorIcon;
        public Vector2 Offset;
    }
}
