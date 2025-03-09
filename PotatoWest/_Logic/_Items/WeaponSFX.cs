using System.Collections;
using System.Collections.Generic;
using PotatoWest._Logic._Items;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponSFX : MonoBehaviour
{
    [SerializeField] private AudioSource source;
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
        if (source != null)
        {
            source.Play();
        }
    }
}
