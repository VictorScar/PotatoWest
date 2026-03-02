using System;
using Cysharp.Threading.Tasks;
using PotatoWest._Logic._Configs;
using PotatoWest._Logic._Level;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PotatoWest._Logic._Core
{
    public class LevelController : MonoBehaviour
    {
        private LevelsConfig _config;
        private Level _currentLevel;
        private AsyncOperation _loading;

        public void Init(LevelsConfig levelsConfig)
        {
            _config = levelsConfig;
        }

        public async UniTask LoadGameScene()
        {
            await SceneManager.LoadSceneAsync("GameScene");
        }

        public Level StartLevel(int levelNumber, int levelStage)
        {
            if (_config.GetLevelData(levelNumber, out var levelData))
            {
                _currentLevel = Instantiate(levelData.LevelPrefab);
                return _currentLevel;
            }

            return null;
        }
    }
}