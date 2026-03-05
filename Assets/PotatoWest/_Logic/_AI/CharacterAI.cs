using System;
using Cysharp.Threading.Tasks;
using PotatoWest._Logic._AI.Components;
using PotatoWest._Logic._AI.Components._AIStates;
using PotatoWest._Logic._Interactables;
using PotatoWest._Logic._Items;
using PotatoWest._Logic._Level;
using ScarFramework.Button;
using UnityEngine;

namespace PotatoWest._Logic._AI
{
    public class CharacterAI : MonoBehaviour, IShootTarget
    {
        [SerializeField] protected AIMover _mover;
        [SerializeField] protected Animator _animator;
        [SerializeField] protected float moveSpeed = 0.5f;
        [SerializeField] protected CharacterAIStateController stateController;
        [SerializeField] protected CharacterParameters parameters;

        protected Level _level;
        protected SpawnData spawnData;
       
        public event Action<CharacterAI> onRemove;

        public void Init(Level level, SpawnData spawnData)
        {
            Debug.Log("Init Character");
           _level = level;
            parameters.Init();
            this.spawnData = spawnData;
            _mover.Init(parameters);
            
            OnInit();
            DoAction();
        }

        protected virtual UniTask DoAction()
        {
            stateController.SetNextState();
            return UniTask.CompletedTask;
        }


        public virtual void OnHit(MainWeaponBase mainWeapon)
        {
            Debug.Log("Hit Character!");

            if (parameters.Health > 0)
            {
                parameters.DoDamage(mainWeapon.Damage);

                if (parameters.Health <= 0)
                {
                    Die();
                }
            }
        }

        protected virtual void OnInit()
        {
            stateController.Init(new AIStateContext { Animator = _animator, Mover = _mover, Level = _level, Parameters = parameters, SpawnData = spawnData});
        }

        protected void Say()
        {
        }

        protected void Die()
        {
            stateController.SetState<DeadAIState>();
            //_mover
            DeleteCharacter();
        }

        public async UniTask DeleteCharacter()
        {
            await UniTask.WaitForSeconds(2f);
            onRemove?.Invoke(this);
        }

        [Button("DestroyChar")]
        public void DestroyInternal()
        {
            DeleteCharacter();
        }
    }
}