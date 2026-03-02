using PotatoWest._Logic._AI.Components._AIStates;
using UnityEngine;

namespace PotatoWest._Logic._AI.Components
{
    public class CharacterAIStateController : MonoBehaviour
    {
        [SerializeField] private AiCharacterState[] states;
        private AiCharacterState _currentState;

        public AiCharacterState CurrentState => _currentState;

        void Update()
        {
            if (_currentState)
            {
                _currentState.UpdateState(Time.deltaTime);
            }
        }

        public void Init(AIStateContext context)
        {
            if (states != null)
            {
                foreach (var state in states)
                {
                    state.Init(context);
                }
            }
            
            SetState<DefaultAiState>();
        }

        public void SetState<T>() where T : AiCharacterState
        {
            if (states != null)
            {
                if (GetStateByType<T>(out var newState))
                {
                    if (_currentState)
                    {
                        _currentState.Exit();
                    }

                    _currentState = newState;
                    _currentState.Enter();
                }
            }
        }

        private bool GetStateByType<T>(out T searchingState) where T : AiCharacterState
        {
            if (states != null)
            {
                foreach (var state in states)
                {
                    if (state is T typedState)
                    {
                        searchingState = typedState;
                        return true;
                    }
                }
            }

            searchingState = null;
            return false;
        }
    }
}