using System;
using System.Collections.Generic;
using UnityEngine;

namespace PotatoWest._Logic._Player._Components._Inventory
{
    public class CharacterInventory : MonoBehaviour
    {
        [SerializeField] private List<InventoryCell> cells = new List<InventoryCell>();
        [SerializeField] private int maxCellsCount = 20;

        public event Action<Item> onItemAdded;
        public event Action<Item> onItemRemoved;

        public List<InventoryCell> Cells => cells;
        public int InventorySize => maxCellsCount;

        public void Init(ItemInfo[] startItems, int inventorySize)
        {
            maxCellsCount = inventorySize;
            cells.Clear();

            if (startItems != null)
            {
                foreach (var info in startItems)
                {
                    AddItem(info);
                }
            }
        }

        public bool AddItem(ItemInfo itemInfo)
        {
            if (ExistItem(itemInfo.Item, out var cell))
            {
                var newItemCount = cell.ItemCount + itemInfo.ItemCount;

                if (newItemCount <= itemInfo.Item.MaxStackSize)
                {
                    cell.ItemCount = newItemCount;
                    return true;
                }
            }

            return AddNewItemStack(itemInfo);
        }

        public bool RemoveItem(ItemInfo itemInfo)
        {
            if (ExistItem(itemInfo.Item, out var cell))
            {
                var newItemCount = cell.ItemCount - itemInfo.ItemCount;

                if (newItemCount > 0)
                {
                    cell.ItemCount = newItemCount;
                }
                else
                {
                    cells.Remove(cell);
                    onItemRemoved?.Invoke(itemInfo.Item);
                }

                return true;
            }

            return false;
        }

        public Item[] GetAllItems()
        {
            if (cells != null)
            {
                var items = new List<Item>();
                foreach (var cell in cells)
                {
                    if (!cell.IsEmpty)
                    {
                        items.Add(cell.Item);
                    }
                }

                if (items.Count > 0)
                {
                    return items.ToArray();
                }
            }

            return null;
        }

        private bool ExistItem(Item item, out InventoryCell containItemCell)
        {
            foreach (var cell in cells)
            {
                if (cell.Item == item)
                {
                    containItemCell = cell;
                    return true;
                }
            }

            containItemCell = null;
            return false;
        }

        private bool AddNewItemStack(ItemInfo itemInfo)
        {
            if (cells.Count <= maxCellsCount)
            {
                var newCell = new InventoryCell(itemInfo);
                cells.Add(newCell);
                onItemAdded?.Invoke(itemInfo.Item);
                return true;
            }

            return false;
        }
    }
}