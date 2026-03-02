using UnityEngine;

namespace PotatoWest._Logic._AI.Components._AIStates
{
    public class DefaultAiState : AiCharacterState
    {
        public override void Enter()
        {
            Debug.Log("DEFAULT STATE");
            //Context.Animator.SetTrigger("Reset");
            Context.Animator.SetBool("IsDead", false);
        }
        
        
    }
}
