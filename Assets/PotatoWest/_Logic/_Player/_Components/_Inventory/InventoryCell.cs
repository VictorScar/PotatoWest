using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Logic._Player._Components._Inventory
{
    [Serializable]
    public class InventoryCell
    {
        [SerializeField] private ItemInfo _data;

        public Item Item => _data.Item;

        public bool IsEmpty => Item == null && ItemCount < 1;

        public int ItemCount
        {
            get => _data.ItemCount;
            set
            {
                if (!_data.Invalid)
                {
                    var newData = new ItemInfo();
                    newData.Item = _data.Item;
                    newData.ItemCount = value;
                    _data = newData;
                }
            }
        }

        public InventoryCell()
        {
        }

        public InventoryCell(ItemInfo info)
        {
            _data = info;
        }
    }
}