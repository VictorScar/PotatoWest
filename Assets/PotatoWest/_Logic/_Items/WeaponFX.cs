using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace PotatoWest._Logic._Items
{
    public class WeaponFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particles;
        [FormerlySerializedAs("weaponBase")] [SerializeField] private MainWeaponBase mainWeaponBase;

        private void OnEnable()
        {
            mainWeaponBase.onShoot += PlayShootEffect;
        }

        private void OnDisable()
        {
            mainWeaponBase.onShoot -= PlayShootEffect;
        }

        private void PlayShootEffect()
        {
            if (particles != null && particles.Length > 0)
            {
                var particleIndex = Random.Range(0, particles.Length);
                particles[0].Play();
            }
        }
    }
}