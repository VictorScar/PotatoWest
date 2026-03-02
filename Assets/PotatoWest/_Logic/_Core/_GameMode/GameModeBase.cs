using PotatoWest._Logic._Configs;
using UnityEngine;

namespace PotatoWest._Logic._Core._GameMode
{
    public abstract class GameModeBase : MonoBehaviour
    {
        public abstract void Init(GameModeData data);
   
        
        public abstract void Enter();
    
        public virtual void Exit()
        {
       
        }
    }

    public struct GameModeData
    {
        public InputController InputController;
        public CursorsConfig CursorsConfig;
    }
}
