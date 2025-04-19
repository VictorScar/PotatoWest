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

        public void Init(LevelInitData data)
        {
            levelTokenSource = new CancellationTokenSource();
            _initData = data;
            
            npcSpawner.Init(levelData.SpawnerConfig);
            
            _player = data.ServiceController.PlayerController.SpawnPawn(playerSpawn.Position,
                playerSpawn.Rotation, transform);

            _player.Init(data.Config.PlayerConfig.PawnConfig);
            
            levelScenario.Init(new LevelScenarioData{NpcSpawner = npcSpawner, Pawn = _player});
            
            levelScenario.Run(levelTokenSource.Token);
        }
    }

    public struct LevelInitData
    {
        public GameConfig Config;
        public MainServiceController ServiceController;
    }

    public struct LevelScenarioData
    {
        public NPCSpawner NpcSpawner;
        public PlayerPawn Pawn;
    }
}