using PotatoWest._Logic._AI.Components._AIStates;

namespace PotatoWest._Logic._AI.Components
{
    public interface IAIStateController
    {
        void SetNextState();
        void SetState<T>() where T : AiCharacterState;
    }
}
