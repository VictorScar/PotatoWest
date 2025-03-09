using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Logic._Player._Components._Inventory
{
    [Serializable]
    public struct ItemInfo
    {
        public Item Item;
        public int ItemCount;
        public bool Invalid => Item == null;
    }
}