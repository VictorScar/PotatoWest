using PotatoWest._Logic._AI.Components._AIStates;
using UnityEngine;

namespace PotatoWest._Logic._AI.Components
{
    public class CharacterAIStateController : MonoBehaviour, IAIStateController
    {
        [SerializeField] private AiCharacterState[] states;
        private AiCharacterState _currentState;
        private int _stateNumber;

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
            _stateNumber = 0;

            if (states != null)
            {
                foreach (var state in states)
                {
                    state.Init(context);
                    state.StateController = this;
                }
            }
        }

        public void SetNextState()
        {
            if (states == null)
            {
                Debug.LogError("No assigned states in character");
                return;
            }

            if (_stateNumber >= 0 && _stateNumber < states.Length)
            {
                var state = states[_stateNumber];
                _stateNumber++;
                SetState(state);
            }
        }

        public void SetState<T>() where T : AiCharacterState
        {
            if (states != null)
            {
                if (GetStateByType<T>(out var newState))
                {
                    SetState(newState);
                }
            }
        }

        private void SetState(AiCharacterState newState)
        {
            if (newState != null)
            {
                if (_currentState)
                {
                    _currentState.Exit();
                }

                _currentState = newState;
                _currentState.Enter();
                //Debug.Log($"AI State is {_currentState.name}");
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