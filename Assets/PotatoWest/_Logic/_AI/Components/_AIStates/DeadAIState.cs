namespace PotatoWest._Logic._AI.Components._AIStates
{
    public class DeadAIState : AiCharacterState
    {
        public override void Enter()
        {
            //Context.Animator.SetTrigger("Die");
            Context.Animator.SetBool("IsDead", true);
            Context.Mover.Stop();
        }
    }
}