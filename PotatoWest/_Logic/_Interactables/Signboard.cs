using PotatoWest._Logic._Items;
using UnityEngine;

namespace PotatoWest._Logic._Interactables
{
    public class Signboard : MonoBehaviour, IShootTarget
    {
        [SerializeField] private Rigidbody rb;

        public void OnHit(MainWeaponBase mainWeapon)
        {
            rb.isKinematic = false;
        }
    }
}