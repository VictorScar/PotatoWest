using ScarFramework.UI;
using UnityEngine;

namespace PotatoWest._Logic._Core._GameMode
{
    public class PlayMode : GameModeBase
    {
        private GameModeData _data;
        
        public override void Init(GameModeData data)
        {
            _data = data;
        }

        public override void Enter()
        {
            Cursor.SetCursor(_data.CursorsConfig.PlayModeCursorData.CursorIcon.texture, _data.CursorsConfig.PlayModeCursorData.Offset, CursorMode.Auto);
            _data.InputController.IsEnable = true;
        }
    }
}
