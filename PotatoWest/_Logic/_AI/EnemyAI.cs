using PotatoWest._Logic._Interactables;
using PotatoWest._Logic._Items;
using PotatoWest._Logic._Player._Components;
using PotatoWest._Logic._Player._Components._Inventory;
using UnityEngine;

namespace PotatoWest._Logic._AI
{
    public class EnemyAI : MonoBehaviour, IShootTarget
    {
        // [SerializeField] private PlayerMover mover;
        [SerializeField] private EquipManager equipManager;
        [SerializeField] private CharacterInventory inventory;
        //  [SerializeField] private PlayerShootingController shootingController;
        // [SerializeField] private WeaponBase baseGun;
        // private PlayerPawnConfig _playerConfig;

        public void Init()
        {
            
        }

        public void SetAIState()
        {
            
        }

        public void OnHit(MainWeaponBase mainWeapon)
        {
            Debug.Log("Hit enemy!");
        }
    }
}
