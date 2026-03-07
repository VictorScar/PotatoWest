using System;
using System.Threading;
using PotatoWest._Logic._Configs;
using PotatoWest._Logic._Core;
using PotatoWest._Logic._Level._Scenarios;
using PotatoWest._Player;
using UnityEngine;

namespace PotatoWest._Logic._Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private LevelData levelData;
        [SerializeField] private PlayerSpawn playerSpawn;
        [SerializeField] private NPCSpawner npcSpawner;
        [SerializeField] private LevelScenario levelScenario;

        private CancellationTokenSource levelTokenSource;
        private PlayerPawn _player;

        private LevelInitData _initData;

        public PlayerPawn Player
        {
            get => _player;
            set => _player = value;
        }

    public void Init(LevelInitData data)
        {
            levelTokenSource = new CancellationTokenSource();
            _initData = data;
            
            npcSpawner.Init(this, levelData.SpawnerConfig);
            
            levelScenario.Init(new LevelScenarioData{NpcSpawner = npcSpawner, PlayerSpawn = playerSpawn,Level = this, GameServices = data.ServiceController,Config = data.Config});
            
            levelScenario.Run(levelTokenSource.Token);
        }
    }

    public struct LevelInitData
    {
        public GameConfig Config;
        public GameServices ServiceController;
    }


}