using PotatoWest._Logic._Items;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Logic._Player._Components._Inventory
{
    [CreateAssetMenu(menuName = "Configs/Items", fileName = "Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private int itemID;
        [SerializeField] private string itemName;
        [SerializeField] private int maxStackSize;
        [SerializeField] private Sprite icon;
        [SerializeField] private ItemView viewPrefab;

        public int MaxStackSize => maxStackSize;
        public string ItemName => itemName;
        public int ItemID => itemID;
        public bool IsEquitable => viewPrefab != null;
        public Sprite Icon => icon;
        public ItemView ViewPrefab => viewPrefab;
    }
}