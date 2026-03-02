namespace PotatoWest._Logic._AI.Components._AIStates
{
    public class DefaultAiState : AiCharacterState
    {
        public override void Enter()
        {
            Context.Animator.SetTrigger("Reset");
        }
        
        
    }
}
