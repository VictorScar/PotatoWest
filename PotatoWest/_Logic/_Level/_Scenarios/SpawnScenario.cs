using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PotatoWest._Logic._Level._Scenarios
{
    public class SpawnScenario : LevelScenarioPart
    {
        [SerializeField] private float minSpawnTime = 5f;
        [SerializeField] private float maxSpawnTime = 15f;
        [SerializeField] private int maxSpawnCount = 20;

        private bool _toExit;
        private int _spawnCount;

        protected override UniTask OnBeforeScenario(CancellationToken token)
        {
            _toExit = false;
            _spawnCount = 0;
            return base.OnBeforeScenario(token);
        }

        protected override async UniTask RunInternal(CancellationToken token)
        {
            while (!_toExit || token.IsCancellationRequested)
            {
                var delay = Random.Range(minSpawnTime, maxSpawnTime+0.1f);
                await UniTask.WaitForSeconds(delay, cancellationToken:token);
                if (_data.NpcSpawner.SpawnActor())
                {
                    _spawnCount++;
                }
                
                if (_spawnCount >= maxSpawnCount)
                {
                    _toExit = true;
                }
            }
           
        }

        protected override void OnScenarioEnd()
        {
            _data.NpcSpawner.ClearSpawnenActors();
        }
    }
}
