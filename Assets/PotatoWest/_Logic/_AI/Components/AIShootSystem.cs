using System;
using PotatoWest._Logic._Player._Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Logic._AI
{
    public class AIShootSystem : MonoBehaviour
    {
        [SerializeField] private Transform scope;
        [SerializeField] private Vector3 targetOffset = new Vector3(0, 1, 0);

        private AIShootSystemData _data;
        private float _lastShootTime;
        private Transform _target;

        public Transform Target
        {
            get => _target;
            set => _target = value;
        }

        public bool IsAiming { get; set; }

        public void Init(AIShootSystemData data)
        {
            _data = data;
            _lastShootTime = 0f;
        }

        private void Update()
        {
            if (IsAiming)
            {
                AimToEnemy();
                _lastShootTime += Time.deltaTime;

                if (_lastShootTime >= _data.ShootDelay)
                {
                    Shoot();
                    _lastShootTime = 0f;
                }
            }
        }

        private void Shoot()
        {
            var weapon = _data.EquipManager.EquipedWeapon;

            weapon?.AIShoot();
        }

        public void AimToEnemy()
        {
            if (_target)
            {
                _data.Mover.RotateTo(_target);
                scope.LookAt(_target.position + targetOffset);
            }
        }
    }

    public struct AIShootSystemData
    {
        public float ShootDelay;
        public EquipManager EquipManager;
        public AIMover Mover;
    }
}