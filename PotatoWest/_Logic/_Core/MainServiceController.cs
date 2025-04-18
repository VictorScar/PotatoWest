using PotatoWest._Logic._Configs;
using ScarFramework.UI;
using UnityEngine;

namespace PotatoWest._Logic._Core
{
    public class MainServiceController : MonoBehaviour
    {
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private LevelController levelController;
        [SerializeField] private PlayerController playerController;

        public UISystem UISystem => uiSystem;
        public LevelController LevelController => levelController;
        public PlayerController PlayerController => playerController;

        public void Init(GameConfig gameConfig)
        {
            uiSystem.Init();
            levelController.Init(gameConfig.LevelsConfig);
            playerController.Init(gameConfig.PlayerConfig);
        }
    }
}

