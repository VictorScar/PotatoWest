using PotatoWest._Logic._Level;
using UnityEngine;

namespace PotatoWest._Logic._AI.Components._AIStates
{
    public abstract class AiCharacterState : MonoBehaviour
    {
        protected AIStateContext Context;
        public IAIStateController StateController { get; set; }

        public void Init(AIStateContext context)
        {
            Context = context;
            OnInit(context);
        }

        protected virtual void OnInit(AIStateContext context)
        {
        }

        public abstract void Enter();

        public virtual void UpdateState(float deltaTime)
        {
        }

        public virtual void Exit()
        {
        }
    }

    public struct AIStateContext
    {
        public Animator Animator;
        public AIShootSystem ShootController;
        public AIMover Mover;
        public Level Level;
        public AICharacterParameters Parameters;
        public SpawnData SpawnData;
    }
}