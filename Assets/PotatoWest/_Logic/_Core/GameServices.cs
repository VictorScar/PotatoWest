using PotatoWest._Logic._Configs;
using PotatoWest._Logic._Core._GameMode;
using ScarFramework.UI;
using UnityEngine;

namespace PotatoWest._Logic._Core
{
    public class GameServices : MonoBehaviour
    {
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private LevelController levelController;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private GameModeController gameModeController;
        
        public UISystem UISystem => uiSystem;
        public LevelController LevelController => levelController;
        public PlayerController PlayerController => playerController;
        public GameModeController GameModeController => gameModeController;

        public void Init(GameConfig gameConfig)
        {
            uiSystem.Init();
            playerController.Init(gameConfig.PlayerConfig);
            gameModeController.Init(new GameModeData{CursorsConfig = gameConfig.CursorsConfig, InputController = playerController.InputController});
            levelController.Init(gameConfig.LevelsConfig);
        }
    }
}

