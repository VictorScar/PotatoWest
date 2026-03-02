using System;
using System.Collections.Generic;
using PotatoWest._Logic._Items;
using PotatoWest._Logic._Player._Components._Inventory;
using Unity.Collections;
using UnityEngine;

namespace PotatoWest._Logic._Player._Components
{
    public class EquipManager : MonoBehaviour
    {
        [SerializeField] private Transform weaponSocket;
        [SerializeField] private MainWeaponBase _equipedWeapon;

        private List<MainWeaponBase> _weapons = new List<MainWeaponBase>();
        private CharacterInventory _inventory;

        public MainWeaponBase EquipedWeapon => _equipedWeapon;
        public Transform WeaponSocket => weaponSocket;

        public void Init(CharacterInventory inventory)
        {
            _weapons.Clear();
            _inventory = inventory;

            if (_equipedWeapon != null)
            {
                _equipedWeapon.Init();
            }
            else
            {
                var availableItems = _inventory.GetAllItems();

                if (availableItems != null)
                {
                    foreach (var item in availableItems)
                    {
                        if (item.ViewPrefab != null && item.ViewPrefab is MainWeaponBase weapon)
                        {
                            _weapons.Add(weapon);
                        }
                    }
                }

                if (_weapons.Count > 0)
                {
                    Equip(_weapons[0]);
                }
            }
        }

        public void Equip(MainWeaponBase weapon)
        {
            if (_equipedWeapon != null)
            {
                UnEquip();
            }

            _equipedWeapon = Instantiate(weapon, weaponSocket);
            _equipedWeapon.Init();
        }

        public void UnEquip()
        {
            if (_equipedWeapon != null)
            {
                Destroy(_equipedWeapon);
                _equipedWeapon = null;
            }
        }
    }
}