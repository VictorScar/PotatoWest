using PotatoWest._Logic._Items;
using UnityEngine;

namespace PotatoWest._Logic._Player._Components._Inventory
{
    public class WeaponHandler
    {
        private Item _item;
        private MainWeaponBase _mainWeaponBase;
        
        public WeaponHandler(Item item, MainWeaponBase mainWeapon, CharacterInventory inventory)
        {
            _item = item;
            _mainWeaponBase = mainWeapon;
        }
    }
}