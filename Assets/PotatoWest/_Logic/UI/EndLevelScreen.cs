using System;
using ScarFramework.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PotatoWest._Logic.UI
{
    public class EndLevelScreen : UIScreen
    {
        [SerializeField] private EndLevelScreenStateData winState;
        [SerializeField] private EndLevelScreenStateData loseState;
        [SerializeField] private Image bg;
        [SerializeField] private TMP_Text screenMessage;
        [SerializeField] private TMP_Text enemyKills;
        [SerializeField] private TMP_Text peacefulKills;
        [SerializeField] private UIClickableView restartBtn;
        [SerializeField] private UIClickableView continueBtn;
        [SerializeField] private UIClickableView exitBtn;

        protected override void OnInit()
        {
            base.OnInit();
            restartBtn?.Init();
        }

        public EndLevelData Data
        {
            set
            {
                if (value.IsWin)
                {
                    SetState(winState);
                }
                else
                {
                    SetState(loseState);
                }
            }
        }

        private void SetState(EndLevelScreenStateData state)
        {
            bg.color = state.MainColor;
            screenMessage.text = state.ScreenMsg;
        }
    }

    [Serializable]
    public struct EndLevelScreenStateData
    {
        public Color MainColor;
        public string ScreenMsg;
    }

    public struct EndLevelData
    {
        public bool IsWin;
    }
}
