using PotatoWest._Input.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Logic._Player._Components
{
    public class PlayerShootingController : MonoBehaviour
    {
        [SerializeField] private Transform scope;

        private Camera _playerCamera;
        private EquipManager _equipManager;
        public Transform Scope => scope;

        public void Init(Camera playerCamera, EquipManager equipManager)
        {
            _playerCamera = playerCamera;
            _equipManager = equipManager;
        }

        public void SetInputs(ShootInputData inputData)
        {
            if (_playerCamera != null)
            {
                var shootRay = _playerCamera.ScreenPointToRay(inputData.ScopePosition);

                if (Physics.Raycast(shootRay, out var hit, 30f))
                {
                    scope.position = hit.point;
                }
                else
                {
                    scope.position = shootRay.origin + shootRay.direction * 100f;
                }
                
                _equipManager?.WeaponSocket.LookAt(scope);

                if (inputData.ShootKeyInfo.IsPressed && inputData.ShootKeyInfo.HasBeenReleased)
                {
                    Shoot();
                }
            }
        }

        public void Shoot()
        {
            if (_equipManager.EquipedWeapon != null)
            {
                _equipManager.EquipedWeapon.Shoot(scope.position);
            }
        }
    }
}