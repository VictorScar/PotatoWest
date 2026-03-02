using PotatoWest._Logic._Core._GameMode;
using UnityEngine;

namespace PotatoWest._Logic._Core
{
    public class GameModeController : MonoBehaviour
    {
        [SerializeField] private GameModeBase[] modes;

        private GameModeBase _currentMode;

        public void Init(GameModeData gameModeData)
        {
            if (modes != null)
            {
                foreach (var mode in modes)
                {
                    mode.Init(gameModeData);
                }
            }
        }
        
        public void SetMode<T>() where T : GameModeBase
        {
            if (_currentMode)
            {
                _currentMode.Exit();
                _currentMode = null;
            }

            if (modes != null)
            {
                foreach (var mode in modes)
                {
                    if (mode is T typedMode)
                    {
                        _currentMode = typedMode;
                        _currentMode.Enter();
                    }
                }
            }
        
     
        }

  
    }
}
