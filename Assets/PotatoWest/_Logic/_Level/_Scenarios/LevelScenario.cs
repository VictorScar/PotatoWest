using System.Threading;
using Cysharp.Threading.Tasks;
using PotatoWest._Logic._Configs;
using PotatoWest._Logic._Core;
using PotatoWest._Logic._Scenarios;
using PotatoWest._Logic.UI;
using UnityEngine;
using PlayMode = PotatoWest._Logic._Core._GameMode.PlayMode;

namespace PotatoWest._Logic._Level._Scenarios
{
    public class LevelScenario : GameScenarioBase<LevelScenarioData>
    {
        [SerializeField] private Sprite scopeIcon;
       // private Vector2 scopeOffset = new Vector2(62.5f, 62.5f);
        [SerializeField] private LevelScenarioPart[] scenarioParts;
        private GameScreen _gameScreen;

        protected override void OnInit(LevelScenarioData scenarioData)
        {
            base.OnInit(scenarioData);
            if (scenarioParts != null)
            {
                foreach (var part in scenarioParts)
                {
                    part.Init(scenarioData);
                }
            }

            _gameScreen = Data.GameServices.UISystem.GetScreen<GameScreen>();
        }

        protected override async UniTask RunInternal(CancellationToken token)
        {
            if (scenarioParts != null)
            {
                SpawnPlayer();
                Data.GameServices.GameModeController.SetMode<PlayMode>();
                _gameScreen.Show();

                foreach (var part in scenarioParts)
                {
                    await part.Run(token);
                }

                Debug.Log("All part ended!");
                _gameScreen.Hide();
            }
        }

        private void SpawnPlayer()
        {
            var playerPawn = Data.GameServices.PlayerController.SpawnPawn(Data.PlayerSpawn.Position,
                Data.PlayerSpawn.Rotation, transform);


            playerPawn.Init(Data.Config.PlayerConfig.PawnConfig);

            Data.Level.Player = playerPawn;
        }

        protected override void OnScenarioEnd()
        {
        }
    }

    public struct LevelScenarioData : IScenarioData
    {
        public GameConfig Config;
        public GameServices GameServices;
        public PlayerSpawn PlayerSpawn;
        public NPCSpawner NpcSpawner;
        public Level Level;
    }
}