using PotatoWest._Logic._Player._Components._Inventory;
using UnityEngine;

namespace PotatoWest._Logic._Configs
{
    [CreateAssetMenu(menuName = "Configs/PlayerPawnConfig", fileName = "PlayerPawnConfig")]
    public class PlayerPawnConfig : ScriptableObject
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private ItemInfo[] startItems;
        [SerializeField] private int inventorySize;
        public ItemInfo[] StartItems => startItems;
        public float MoveSpeed => moveSpeed;
        public float RotateSpeed => rotateSpeed;
        public int InventorySize => inventorySize;
    }
}