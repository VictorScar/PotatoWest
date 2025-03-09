using System;
using System.Collections;
using PotatoWest._Logic._Interactables;
using PotatoWest._Logic._Player._Components._Inventory;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Logic._Items
{
    public class MainWeaponBase : ItemView
    {
        [SerializeField] private int clipCapacity = 6;
        [SerializeField] private float reloadingDuration = 2f;
        [SerializeField] private float shellDamage = 50f;
        [SerializeField] private float shootCooldown = 0.2f;
        [SerializeField] private Transform muzzle;
      
        private float _lastShootTime;
        private int _currentAmmoCount;
        private bool _isReloading = false;

        public event Action onShoot;
        
        public Transform Muzzle => muzzle;
        public float ShootCooldown => shootCooldown;
        public float ReloadingTime => reloadingDuration;
        
        private void Update()
        {
            if (_lastShootTime > 0)
            {
                _lastShootTime -= Time.deltaTime;
            }
        }

        public void Init()
        {
            _currentAmmoCount = clipCapacity;
            _lastShootTime = 0f;
        }

        public void Shoot(Vector3 scopePosition)
        {
            if (_lastShootTime <= 0)
            {
                if (_currentAmmoCount > 0)
                {
                    onShoot?.Invoke();
                    Debug.Log("Shoot");
                    
                   if(Physics.Raycast(muzzle.position, (scopePosition-muzzle.position).normalized, out var hit, 20f))
                   {
                       if (hit.collider.TryGetComponent<IShootTarget>(out var target))
                       {
                           target.OnHit(this);
                       }
                   }
                    _currentAmmoCount--;
                    _lastShootTime = shootCooldown;
                    return;
                }

                Debug.Log("No ammo!");
                Reload();
            }

        }

        public void Reload()
        {
            if (!_isReloading)
            {
                StartCoroutine(Reloading());
            }
        }

        IEnumerator Reloading()
        {
            Debug.Log("Reloading!");
            _isReloading = true;
            yield return new WaitForSeconds(reloadingDuration);
            _currentAmmoCount = clipCapacity;
            _isReloading = false;
        }
    }
}