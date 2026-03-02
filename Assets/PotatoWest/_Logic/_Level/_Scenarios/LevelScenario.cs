using System.Threading;
using Cysharp.Threading.Tasks;
using PotatoWest._Logic._Configs;
using PotatoWest._Logic._Core;
using PotatoWest._Logic._Scenarios;
using UnityEngine;
using PlayMode = PotatoWest._Logic._Core._GameMode.PlayMode;

namespace PotatoWest._Logic._Level._Scenarios
{
    public class LevelScenario : GameScenarioBase
    {
        [SerializeField] private Sprite scopeIcon;
        private Vector2 scopeOffset = new Vector2(62.5f,62.5f);
        [SerializeField] private LevelScenarioPart[] scenarioParts;
        protected LevelScenarioData _data;

        public void Init(LevelScenarioData levelScenarioData)
        {
            _data = levelScenarioData;

            if (scenarioParts != null)
            {
                foreach (var part in scenarioParts)
                {
                    part.Init(levelScenarioData);
                }
            }
        }

        protected override async UniTask RunInternal(CancellationToken token)
        {
            if (scenarioParts != null)
            {
                SpawnPlayer();
                _data.GameServices.GameModeController.SetMode<PlayMode>();
                
                foreach (var part in scenarioParts)
                {
                    await part.Run(token);
                }
                
                Debug.Log("All part ended!");
            }
        }

        private void SpawnPlayer()
        {
            var playerPawn = _data.GameServices.PlayerController.SpawnPawn(_data.PlayerSpawn.Position,
                _data.PlayerSpawn.Rotation, transform);
              

            playerPawn.Init(_data.Config.PlayerConfig.PawnConfig);

            _data.Level.Player = playerPawn;
        }

        protected override void OnScenarioEnd()
        {
         
        }
    }
    
    public struct LevelScenarioData
    {
        public GameConfig Config;
        public MainServiceController GameServices;
        public PlayerSpawn PlayerSpawn;
        public NPCSpawner NpcSpawner;
        public Level Level;
        }
}