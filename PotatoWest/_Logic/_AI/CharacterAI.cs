using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using PotatoWest._Logic._AI;
using PotatoWest._Logic._Interactables;
using PotatoWest._Logic._Items;
using PotatoWest._Player;
using ScarFramework.Button;
using UnityEngine;

public class CharacterAI : MonoBehaviour, IShootTarget
{
    [SerializeField] private AIMover _mover;
    [SerializeField] private Animator _animator;
    private Health _health;

    public event Action<CharacterAI> onRemove;

    public void Init()
    {
        _health = new Health(100f);
        OnInit();
        DoAction();
    }

    protected virtual void DoAction()
    {
    }


    public virtual void OnHit(MainWeaponBase mainWeapon)
    {
        Debug.Log("Hit Character!");

        if (_health.Value > 0)
        {
            _health.DoDamage(mainWeapon.Damage);

            if (_health.Value <= 0)
            {
                Die();
            }
        }
    
    }

    protected virtual void OnInit()
    {
        
    }

    protected void Say()
    {
    }

    protected void Die()
    {
        _animator.SetTrigger("Die");
        DestroyCharacter();
    }

    private async UniTask DestroyCharacter()
    {
        await UniTask.WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        onRemove.Invoke(this);
        Destroy(gameObject);
    }

    [Button("DestroyChar")]
    public void DestroyInternal()
    {
        DestroyCharacter();
    }
}