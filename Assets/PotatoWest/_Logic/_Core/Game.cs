using Cysharp.Threading.Tasks;
using PotatoWest._Logic._Configs;
using PotatoWest._Logic._Level;
using PotatoWest._Logic.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PotatoWest._Logic._Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameServices serviceController;
       
      
        private GameConfig _config;

        public void Init(GameConfig gameConfig)
        {
            DontDestroyOnLoad(gameObject);
            _config = gameConfig;
            serviceController.Init(gameConfig);
            StartGame();
           
        }

        private async UniTask StartGame()
        {
            await serviceController.LevelController.LoadGameScene();
            var level = serviceController.LevelController.StartLevel(0,0);
           
            level.Init(new LevelInitData{Config = _config, ServiceController = serviceController});
            var loadingScreen = serviceController.UISystem.GetScreen<LoadingScreen>();
            loadingScreen.Hide();
        }
    }
}