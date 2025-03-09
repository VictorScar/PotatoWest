using PotatoWest._Logic._Items;

namespace PotatoWest._Logic._Interactables
{
    public interface IShootTarget
    {
        void OnHit(MainWeaponBase mainWeapon);
    }
}