using UnityEngine;

namespace PotatoWest._Logic._AI.Components._AIStates
{
    public class DefaultAiState : AiCharacterState
    {
        public override void Enter()
        {
            Context.Animator.SetBool("IsDead", false);
            StateController.SetNextState();
        }
        
        
    }
}
