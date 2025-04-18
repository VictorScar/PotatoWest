using PotatoWest._Logic._Interactables;
using PotatoWest._Logic._Items;
using PotatoWest._Logic._Player._Components;
using PotatoWest._Logic._Player._Components._Inventory;
using UnityEngine;

namespace PotatoWest._Logic._AI
{
    public class EnemyAI : CharacterAI
    {
        [SerializeField] private EquipManager equipManager;
        [SerializeField] private CharacterInventory inventory;
        [SerializeField] private AIShootSystem shootingController;
        // [SerializeField] private WeaponBase baseGun;
        // private PlayerPawnConfig _playerConfig;

        protected override void OnInit()
        {
           // shootingController.Init();
        }

        protected override void DoAction()
        {
            Debug.Log("Attack");
        }

        public override void OnHit(MainWeaponBase mainWeapon)
        {
            base.OnHit(mainWeapon);
            Debug.Log("Hit enemy!");
        }
    }
}
